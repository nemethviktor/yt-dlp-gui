using System.Diagnostics;
using System.Text;
using YtDlpGUI.Helpers;

namespace YtDlpGUI
{
    public partial class frmMain : Form
    {
        private const int MaxLogLength = 200_000;

        private static readonly string[] VideoFormats = ["mp4", "mkv", "webm"];

        // 0 = best available.
        private static readonly int[] VideoHeights = [0, 2160, 1440, 1080, 720, 480, 360];

        private bool nowLoading = false;
        private string languageCode = "en";
        private Process? downloadProcess;
        private bool downloadCancelled;

        public frmMain()
        {
            nowLoading = true;
            InitializeComponent();
            languageCode = HelperLocalisationResourceManager.NormaliseLanguageCode(languageCode: AppSettings.Current.LanguageCode);
            HelperLocalisationResourceManager.ApplyLanguage(languageCode: languageCode);
            rbt_Lang_hu.Checked = languageCode == "hu";
            rbt_Lang_en.Checked = languageCode == "en";
        }

        #region Events

        private void frmMain_Load(object sender, EventArgs e)
        {
            RestoreWindowBounds();
            cbx_DarkMode.Checked = AppSettings.Current.DarkMode;

            ReloadAllControlLabels(languageCode: languageCode);

            cbo_VideoFormat.Items.AddRange(VideoFormats);
            int formatIndex = Array.IndexOf(VideoFormats, AppSettings.Current.VideoFormat);
            cbo_VideoFormat.SelectedIndex = formatIndex >= 0 ? formatIndex : 0;
            PopulateQualityItems(selectedHeight: AppSettings.Current.VideoHeight);
            rbt_DownloadSetting_AudioOnly.Checked = AppSettings.Current.AudioOnly;
            rbt_DownloadSetting_VideoAsWell.Checked = !AppSettings.Current.AudioOnly;
            UpdateVideoOptionsEnabled();

            ofd_Main.FileName = string.Empty;
            ofd_Main.Filter = "Executable (*.exe)|*.exe";

            tbx_YTDLP_Location.Text = HelperToolLocator.Find("yt-dlp.exe", AppSettings.Current.YtDlpPath)
                ?? (AppSettings.Current.YtDlpPath != string.Empty
                    ? AppSettings.Current.YtDlpPath
                    : Path.Combine(AppContext.BaseDirectory, "yt-dlp.exe"));

            tbx_SaveWhere.Text = AppSettings.Current.SavePath != string.Empty
                ? AppSettings.Current.SavePath
                : Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            tbx_URL.Select();
            nowLoading = false;
        }

        private void ofd_Main_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tbx_YTDLP_Location.Text = ofd_Main.FileName;
        }

        private void btn_Locate_Click(object sender, EventArgs e)
        {
            _ = ofd_Main.ShowDialog();
        }

        private void btn_SaveWhere_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(tbx_SaveWhere.Text))
            {
                fbd_SaveWhere.SelectedPath = tbx_SaveWhere.Text;
            }

            if (fbd_SaveWhere.ShowDialog() == DialogResult.OK)
            {
                tbx_SaveWhere.Text = fbd_SaveWhere.SelectedPath;
            }
        }

        private async void btn_OK_Click(object sender, EventArgs e)
        {
            if (downloadProcess != null)
            {
                return;
            }

            string ytdlpLocation = tbx_YTDLP_Location.Text.Trim().Trim('"');
            if (ytdlpLocation == string.Empty)
            {
                _ = MessageBox.Show(Resources.msgb_MissingYTDLP_Location);
                return;
            }

            if (!File.Exists(ytdlpLocation))
            {
                _ = MessageBox.Show(Resources.msgb_YTDLPNotFound);
                return;
            }

            string url = tbx_URL.Text.Trim();
            if (url == string.Empty)
            {
                _ = MessageBox.Show(Resources.msgb_MissingURL);
                return;
            }

            // Also guarantees the URL cannot be mistaken for a command line option.
            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri? uri) || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
            {
                _ = MessageBox.Show(Resources.msgb_InvalidURL);
                return;
            }

            string saveWhere = tbx_SaveWhere.Text.Trim().Trim('"');
            try
            {
                _ = Directory.CreateDirectory(saveWhere);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or ArgumentException or NotSupportedException)
            {
                _ = MessageBox.Show(Resources.msgb_SaveFolderError);
                return;
            }

            bool audioOnly = rbt_DownloadSetting_AudioOnly.Checked;
            if (HelperToolLocator.Find("ffmpeg.exe", Path.Combine(Path.GetDirectoryName(ytdlpLocation) ?? string.Empty, "ffmpeg.exe")) == null
                && MessageBox.Show(Resources.msgb_FfmpegMissing, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            SaveSettings();

            ProcessStartInfo startInfo = new()
            {
                FileName = ytdlpLocation,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8,
                WorkingDirectory = saveWhere
            };

            // ArgumentList quotes every value, so spaces/quotes in paths or URLs cannot break out of the command.
            if (audioOnly)
            {
                startInfo.ArgumentList.Add("-x");
                startInfo.ArgumentList.Add("--audio-format");
                startInfo.ArgumentList.Add("mp3");
            }

            else
            {
                int height = SelectedVideoHeight();
                string format = VideoFormats[Math.Max(cbo_VideoFormat.SelectedIndex, 0)];
                string heightFilter = height > 0 ? $"[height<={height}]" : string.Empty;

                startInfo.ArgumentList.Add("-f");
                startInfo.ArgumentList.Add($"bv*{heightFilter}+ba/b{heightFilter}");
                // Resolution first, then prefer streams that fit the target container without re-encoding.
                startInfo.ArgumentList.Add("-S");
                startInfo.ArgumentList.Add(format switch
                {
                    "mp4" => "res,ext:mp4:m4a",
                    "webm" => "res,ext:webm:webm",
                    _ => "res"
                });
                startInfo.ArgumentList.Add("--merge-output-format");
                startInfo.ArgumentList.Add(format);
            }

            startInfo.ArgumentList.Add("--no-playlist");
            startInfo.ArgumentList.Add("--newline");
            startInfo.ArgumentList.Add("-P");
            startInfo.ArgumentList.Add(saveWhere);
            startInfo.ArgumentList.Add("--");
            startInfo.ArgumentList.Add(url);

            tbx_Log.Clear();
            AppendLog($"> {ytdlpLocation} {string.Join(' ', startInfo.ArgumentList)}");

            await RunDownloadAsync(startInfo);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (downloadProcess != null)
            {
                downloadCancelled = true;
                KillDownload();
                return;
            }

            Close();
        }

        private void rbt_DownloadSetting_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVideoOptionsEnabled();
        }

        private void btn_About_Click(object sender, EventArgs e)
        {
            using frmAbout about = new(languageCode: languageCode) { Icon = Icon };
            _ = about.ShowDialog(this);
        }

        private void cbx_DarkMode_CheckedChanged(object sender, EventArgs e)
        {
            if (!nowLoading)
            {
                AppSettings.Current.DarkMode = cbx_DarkMode.Checked;
                AppSettings.Current.Save();
                _ = MessageBox.Show(Resources.msgb_RestartRequired);
            }
        }

        private void rbt_Lang_CheckedChanged(object sender, EventArgs e)
        {
            if (nowLoading || sender is not RadioButton { Checked: true })
            {
                return;
            }

            languageCode = rbt_Lang_en.Checked ? "en" : "hu";
            AppSettings.Current.LanguageCode = languageCode;
            AppSettings.Current.Save();
            HelperLocalisationResourceManager.ApplyLanguage(languageCode: languageCode);
            ReloadAllControlLabels(languageCode: languageCode);
            PopulateQualityItems(selectedHeight: SelectedVideoHeight());
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            downloadCancelled = true;
            KillDownload();
            SaveSettings();
        }

        #endregion

        #region Controls/Labels

        private void ReloadAllControlLabels(string languageCode)
        {
            HelperLocalisationResourceManager.ApplyLabels(root: this, languageCode: languageCode);
        }

        #endregion

        #region Video options

        private int SelectedVideoHeight()
        {
            int index = cbo_VideoQuality.SelectedIndex;
            return index >= 0 && index < VideoHeights.Length ? VideoHeights[index] : 0;
        }

        private void PopulateQualityItems(int selectedHeight)
        {
            cbo_VideoQuality.Items.Clear();
            foreach (int height in VideoHeights)
            {
                _ = cbo_VideoQuality.Items.Add(height == 0
                    ? HelperLocalisationResourceManager.GetResourceValue(controlName: "opt_QualityBest", languageCode: languageCode)
                    : $"{height}p");
            }

            int index = Array.IndexOf(VideoHeights, selectedHeight);
            cbo_VideoQuality.SelectedIndex = index >= 0 ? index : 0;
        }

        private void UpdateVideoOptionsEnabled()
        {
            bool video = !rbt_DownloadSetting_AudioOnly.Checked;
            cbo_VideoFormat.Enabled = video;
            cbo_VideoQuality.Enabled = video;
            lbl_VideoFormat.Enabled = video;
            lbl_VideoQuality.Enabled = video;
        }

        #endregion

        #region Download

        private async Task RunDownloadAsync(ProcessStartInfo startInfo)
        {
            downloadCancelled = false;
            btn_OK.Enabled = false;

            int exitCode = -1;
            try
            {
                using Process process = new() { StartInfo = startInfo, EnableRaisingEvents = true };
                process.OutputDataReceived += (_, args) => AppendLogThreadSafe(args.Data);
                process.ErrorDataReceived += (_, args) => AppendLogThreadSafe(args.Data);

                downloadProcess = process;
                _ = process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await process.WaitForExitAsync();
                exitCode = process.ExitCode;
            }
            catch (Exception ex) when (ex is System.ComponentModel.Win32Exception or InvalidOperationException)
            {
                _ = MessageBox.Show(string.Format(Resources.msgb_StartFailed, ex.Message));
                return;
            }
            finally
            {
                downloadProcess = null;
                if (!IsDisposed)
                {
                    btn_OK.Enabled = true;
                }
            }

            if (IsDisposed)
            {
                return;
            }

            if (downloadCancelled)
            {
                AppendLog(Resources.msgb_DownloadCancelled);
            }
            else if (exitCode == 0)
            {
                AppendLog(Resources.msgb_DownloadDone);
            }
            else
            {
                AppendLog(string.Format(Resources.msgb_DownloadFailed, exitCode));
            }
        }

        private void KillDownload()
        {
            try
            {
                downloadProcess?.Kill(entireProcessTree: true);
            }
            catch (Exception ex) when (ex is InvalidOperationException or System.ComponentModel.Win32Exception)
            {
                // already exited
            }
        }

        private void AppendLogThreadSafe(string? line)
        {
            if (line == null || IsDisposed || !IsHandleCreated)
            {
                return;
            }

            try
            {
                _ = BeginInvoke(() => AppendLog(line));
            }
            catch (ObjectDisposedException)
            {
                // form closed meanwhile
            }
            catch (InvalidOperationException)
            {
                // handle destroyed meanwhile
            }
        }

        private void AppendLog(string line)
        {
            if (tbx_Log.TextLength > MaxLogLength)
            {
                tbx_Log.Text = tbx_Log.Text[(MaxLogLength / 2)..];
            }

            tbx_Log.AppendText(line + Environment.NewLine);
        }

        private void SaveSettings()
        {
            AppSettings settings = AppSettings.Current;
            settings.YtDlpPath = tbx_YTDLP_Location.Text.Trim().Trim('"');
            settings.SavePath = tbx_SaveWhere.Text.Trim().Trim('"');
            settings.DarkMode = cbx_DarkMode.Checked;
            settings.LanguageCode = languageCode;
            settings.AudioOnly = rbt_DownloadSetting_AudioOnly.Checked;
            settings.VideoFormat = VideoFormats[Math.Max(cbo_VideoFormat.SelectedIndex, 0)];
            settings.VideoHeight = SelectedVideoHeight();

            if (WindowState != FormWindowState.Minimized)
            {
                // RestoreBounds is the normal-state rectangle even while maximised.
                Rectangle bounds = WindowState == FormWindowState.Normal ? Bounds : RestoreBounds;
                settings.WindowLeft = bounds.Left;
                settings.WindowTop = bounds.Top;
                settings.WindowWidth = bounds.Width;
                settings.WindowHeight = bounds.Height;
            }

            settings.Save();
        }

        private void RestoreWindowBounds()
        {
            AppSettings settings = AppSettings.Current;
            if (settings.WindowLeft is not int left || settings.WindowTop is not int top
                || settings.WindowWidth is not int width || settings.WindowHeight is not int height
                || width < MinimumSize.Width || height < MinimumSize.Height)
            {
                return;
            }

            // Ignore saved positions that would now be off-screen (monitor unplugged, resolution changed).
            Rectangle saved = new(left, top, width, height);
            if (Screen.AllScreens.Any(screen => screen.WorkingArea.IntersectsWith(saved)))
            {
                StartPosition = FormStartPosition.Manual;
                Bounds = saved;
            }
        }

        #endregion
    }
}

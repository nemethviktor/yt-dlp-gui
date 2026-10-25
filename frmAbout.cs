using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using YtDlpGUI.Helpers;

namespace YtDlpGUI
{
    public partial class frmAbout : Form
    {
        private const string GitHubUrl = "https://github.com/nemethviktor/yt-dlp-gui";
        private const string YtDlpUrl = "https://github.com/yt-dlp/yt-dlp";

        // The build number is the number of days since this date (set in the csproj).
        private static readonly DateTime BuildEpoch = new(2000, 1, 1);

        public frmAbout(string languageCode)
        {
            InitializeComponent();

            HelperLocalisationResourceManager.ApplyLabels(root: this, languageCode: languageCode);
            Text = HelperLocalisationResourceManager.GetResourceValue(controlName: "frmAbout", languageCode: languageCode);

            Version version = Assembly.GetExecutingAssembly().GetName().Version ?? new Version(1, 0);
            int build = Math.Max(version.Build, 0);
            lbl_About_Version.Text = string.Format(
                CultureInfo.InvariantCulture,
                HelperLocalisationResourceManager.GetResourceValue(controlName: "fmt_AboutVersion", languageCode: languageCode),
                $"{version.Major}.{version.Minor}",
                build,
                BuildEpoch.AddDays(build));
        }

        private void lnk_About_GitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl(GitHubUrl);
        }

        private void lnk_About_YtDlp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenUrl(YtDlpUrl);
        }

        private static void OpenUrl(string url)
        {
            try
            {
                _ = Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Win32Exception)
            {
                // no default browser registered
            }
        }
    }
}

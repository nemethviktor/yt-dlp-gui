using System.Text.Json;

namespace YtDlpGUI.Helpers
{
    /// <summary>
    /// Local settings store: a JSON file at %LOCALAPPDATA%\YtDlpGUI\settings.json.
    /// </summary>
    internal sealed class AppSettings
    {
        private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

        private static AppSettings? current;

        internal static string FilePath { get; } =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "YtDlpGUI", "settings.json");

        internal static AppSettings Current => current ??= Load();

        public string YtDlpPath { get; set; } = string.Empty;
        public string SavePath { get; set; } = string.Empty;
        public bool DarkMode { get; set; }
        public string LanguageCode { get; set; } = string.Empty;
        public bool AudioOnly { get; set; } = true;
        public string VideoFormat { get; set; } = "mp4";
        public int VideoHeight { get; set; }

        // Last window bounds in a normal (not minimised/maximised) state; null until first saved.
        public int? WindowLeft { get; set; }
        public int? WindowTop { get; set; }
        public int? WindowWidth { get; set; }
        public int? WindowHeight { get; set; }

        private static AppSettings Load()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    return JsonSerializer.Deserialize<AppSettings>(File.ReadAllText(FilePath), JsonOptions) ?? new AppSettings();
                }
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or JsonException)
            {
                // unreadable or corrupt file: fall back to defaults, it is rewritten on the next save
                return new AppSettings();
            }

            return ImportLegacy();
        }

        /// <summary>
        /// One-time import of values stored by the old .NET user settings (Properties.Settings).
        /// </summary>
        private static AppSettings ImportLegacy()
        {
            AppSettings imported = new();
            try
            {
                Properties.Settings legacy = Properties.Settings.Default;
                imported.YtDlpPath = legacy.YTDLP_Path;
                imported.SavePath = legacy.Save_Path;
                imported.DarkMode = legacy.Dark_Mode;
                imported.LanguageCode = legacy.Lang_Code;
                imported.VideoFormat = string.IsNullOrEmpty(legacy.Video_Format) ? "mp4" : legacy.Video_Format;
                imported.VideoHeight = legacy.Video_Height;
            }
            catch (Exception ex) when (ex is System.Configuration.ConfigurationException or IOException or UnauthorizedAccessException)
            {
                // legacy store unreadable: start from defaults
            }

            return imported;
        }

        internal void Save()
        {
            try
            {
                _ = Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);

                // Write to a temp file and swap it in so a crash mid-write cannot corrupt the settings.
                string temp = FilePath + ".tmp";
                File.WriteAllText(temp, JsonSerializer.Serialize(this, JsonOptions));
                File.Move(temp, FilePath, overwrite: true);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                // settings are a convenience; never fail the app because they cannot be written
            }
        }
    }
}

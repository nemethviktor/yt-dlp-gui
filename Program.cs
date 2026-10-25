using YtDlpGUI.Helpers;

namespace YtDlpGUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // The colour mode must be set before the first window is created.
#pragma warning disable WFO5001 // experimental API
            Application.SetColorMode(AppSettings.Current.DarkMode ? SystemColorMode.Dark : SystemColorMode.Classic);
#pragma warning restore WFO5001

            Application.Run(new frmMain());
        }
    }
}

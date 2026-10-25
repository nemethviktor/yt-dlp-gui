namespace YtDlpGUI.Helpers
{
    internal static class HelperToolLocator
    {
        /// <summary>
        /// Looks for an executable in: the explicit candidate paths, the application folder, then PATH.
        /// </summary>
        internal static string? Find(string exeName, params string?[] candidatePaths)
        {
            foreach (string? candidate in candidatePaths)
            {
                if (!string.IsNullOrWhiteSpace(value: candidate) && File.Exists(path: candidate))
                {
                    return candidate;
                }
            }

            string inAppFolder = Path.Combine(AppContext.BaseDirectory, exeName);
            if (File.Exists(path: inAppFolder))
            {
                return inAppFolder;
            }

            string[] pathDirs = (Environment.GetEnvironmentVariable(variable: "PATH") ?? string.Empty)
                .Split(separator: Path.PathSeparator, options: StringSplitOptions.RemoveEmptyEntries);

            foreach (string dir in pathDirs)
            {
                try
                {
                    string full = Path.Combine(dir.Trim().Trim('"'), exeName);
                    if (File.Exists(path: full))
                    {
                        return full;
                    }
                }
                catch (ArgumentException)
                {
                    // malformed PATH entry
                }
            }

            return null;
        }
    }
}

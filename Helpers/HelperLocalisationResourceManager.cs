using System.Globalization;
using System.Resources;

namespace YtDlpGUI.Helpers
{
    internal static class HelperLocalisationResourceManager
    {
        internal static readonly string[] SupportedLanguages = ["hu", "en"];

        internal static string NormaliseLanguageCode(string? languageCode)
        {
            return SupportedLanguages.Contains(value: languageCode) ? languageCode! : "en";
        }

        /// <summary>
        /// Makes the typed <see cref="Resources"/> properties (message boxes etc.) use the given language.
        /// </summary>
        internal static void ApplyLanguage(string languageCode)
        {
            Resources.Culture = CultureInfo.GetCultureInfo(name: NormaliseLanguageCode(languageCode: languageCode));
        }

        /// <summary>
        /// Sets the text of every control below <paramref name="root"/> to the resource whose key equals its name.
        /// Controls without a resource key keep their current text.
        /// </summary>
        internal static void ApplyLabels(Control root, string languageCode)
        {
            foreach (Control control in GetAllControls(control: root))
            {
                string text = GetResourceValue(controlName: control.Name, languageCode: languageCode);

                if (text != string.Empty)
                {
                    control.Text = text;
                }
            }
        }

        private static IEnumerable<Control> GetAllControls(Control control)
        {
            IEnumerable<Control> controls = control.Controls.Cast<Control>();

            return controls.SelectMany(selector: GetAllControls)
                .Concat(second: controls);
        }

        /// <summary>
        /// Returns the resource whose key equals the control name, or an empty string if there is none.
        /// </summary>
        internal static string ReturnControlText(string controlName, string languageCode)
        {
            return GetResourceValue(controlName: controlName, languageCode: languageCode);
        }

        public static string GetResourceValue(string controlName, string languageCode)
        {
            try
            {
                return Resources.ResourceManager.GetString(
                    name: controlName,
                    culture: CultureInfo.GetCultureInfo(name: NormaliseLanguageCode(languageCode: languageCode)))
                    ?? string.Empty;
            }
            catch (MissingManifestResourceException)
            {
                return string.Empty;
            }
        }
    }
}

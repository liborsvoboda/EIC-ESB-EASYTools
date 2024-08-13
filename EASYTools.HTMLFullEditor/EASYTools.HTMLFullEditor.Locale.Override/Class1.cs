using EASYTools.HTMLFullEditor.Localization;
using System.Globalization;

namespace EASYTools.HTMLFullEditor.Locale.Override {
    public class Class1 : IResourceManager
    {
        public bool TryProvideString(string textKey, CultureInfo culture, out string localizedText)
        {
            // will override Bold, Italic and Underline text (for every language)
            switch (textKey)
            {
                case nameof(DefaultResources.Text_Bold):
                case nameof(DefaultResources.Text_Italic):
                case nameof(DefaultResources.Text_Underline):
                    localizedText = "Overriden!!!";
                    return true;

            }

            localizedText = null;
            return false;
        }
    }
}

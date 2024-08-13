using System.Globalization;
using EASYTools.HTMLFullEditor.Localization;

namespace EASYTools.HTMLFullEditor.Locale.Default
{
    /// <summary>
    /// Resource manager for allowing EASYTools.HTMLFullEditor to localize it's texts.
    /// </summary>
    public class ResourceManager : IResourceManager
    {
        public bool TryProvideString(string textKey, CultureInfo culture, out string localizedText)
        {
            localizedText = Resources.ResourceManager.GetString(textKey, culture);
            return !string.IsNullOrEmpty(localizedText);
        }
    }
}

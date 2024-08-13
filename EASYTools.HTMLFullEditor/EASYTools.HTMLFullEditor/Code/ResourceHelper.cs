using System;
using System.Windows;
using EASYTools.HTMLFullEditor.Properties;

namespace EASYTools.HTMLFullEditor.Code
{
    public static partial class ResourceHelper
    {
        /// <summary>
        /// Resources/Icons.xaml
        /// </summary>
        public static Lazy<ResourceDictionary> Icons = new Lazy<ResourceDictionary>(() =>
        {
            var icons = new ResourceDictionary();
            icons.Source = new Uri("/EASYTools.HTMLFullEditor;component/Resources/Icons.xaml", UriKind.RelativeOrAbsolute);
            return icons;
        });

        /// <summary>
        /// Resources/Styles.xaml
        /// </summary>
        internal static Lazy<ResourceDictionary> Styles = new Lazy<ResourceDictionary>(() =>
        {
            var icons = new ResourceDictionary();
            icons.Source = new Uri("/EASYTools.HTMLFullEditor;component/Resources/Styles.xaml", UriKind.RelativeOrAbsolute);
            return icons;
        });

        /// <summary>
        /// Get resource from Resources/Icons.xaml
        /// </summary>
        public static UIElement GetIcon(string name)
        {
            return (UIElement)Icons.Value[name];
        }

        /// <summary>
        /// Returns default empty HTML document. (used in <see cref="Interfaces.IBrowserControl.OpenDocument"/> when no string is passed)
        /// </summary>
        public static string GetDefaultHtmlDocument()
        {
            return Resources.Empty;
        }
    }
}

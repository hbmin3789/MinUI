using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MinUI.Core.Utils
{
    public class ThemeSelector : ResourceDictionary
    {
        private static ResourceDictionary _genericTheme;
        public static void InitTheme()
        {
            var dict = Application.Current.Resources.MergedDictionaries;
            _genericTheme = GetResourceDictionary("Generic.xaml");
            _genericTheme.MergedDictionaries.Clear();
            _genericTheme.MergedDictionaries.Add(GetResourceDictionary("MinUIPrimaryTheme.xaml"));
            dict.Add(_genericTheme);
        }

        public static ResourceDictionary GetResourceDictionary(string xamlName)
        {
            var uri = new Uri($"/MinUI.Core;component/Themes/{xamlName}",UriKind.Relative);
            return new ResourceDictionary{ Source = uri };
        }

        public static ResourceDictionary GetLightTheme()
        {
            return GetResourceDictionary("MinUIPrimaryTheme.xaml");
        }

        public static ResourceDictionary GetDarkTheme()
        {
            return GetResourceDictionary("MinUIDarkTheme.xaml");
        }
    }
}

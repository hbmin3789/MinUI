using MinUI.Core.Enummerables;
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
        private static ETheme _currentTheme;
        public static void InitTheme()
        {
            SetThemeLight();
        }

        public static void ToggleTheme()
        {
            if (_currentTheme == ETheme.Light)
            {
                SetThemeDark();
                _currentTheme = ETheme.Dark;
            }
            else
            {
                SetThemeLight();
                _currentTheme = ETheme.Light;
            }
        }

        public static void SetThemeLight()
        {
            if (_genericTheme == null)
            {
                var dict = Application.Current.Resources.MergedDictionaries;
                _genericTheme = GetResourceDictionary("Generic.xaml");
                _genericTheme.MergedDictionaries.Clear();
                _genericTheme.MergedDictionaries.Add(GetLightTheme());
                dict.Add(_genericTheme);
            }
            else 
            {
                var dict = Application.Current.Resources.MergedDictionaries;
                if (dict.Remove(_genericTheme))
                {
                    _genericTheme.MergedDictionaries.Clear();
                    _genericTheme.MergedDictionaries.Add(GetLightTheme());
                    dict.Add(_genericTheme);
                }
            }
            
        }
        public static void SetThemeDark()
        {
            if (_genericTheme == null)
            {
                var dict = Application.Current.Resources.MergedDictionaries;
                _genericTheme = GetResourceDictionary("Generic.xaml");
                _genericTheme.MergedDictionaries.Clear();
                _genericTheme.MergedDictionaries.Add(GetDarkTheme());
                dict.Add(_genericTheme);
            }
            else
            {
                var dict = Application.Current.Resources.MergedDictionaries;
                if (dict.Remove(_genericTheme))
                {
                    _genericTheme.MergedDictionaries.Clear();
                    _genericTheme.MergedDictionaries.Add(GetDarkTheme());
                    dict.Add(_genericTheme);
                }
            }
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

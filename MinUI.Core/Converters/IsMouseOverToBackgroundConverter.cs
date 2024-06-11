using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MinUI.Core.Converters
{
    public class IsMouseOverToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var brushName = (bool)value ? "ButtonMouseOverBrush" : "ButtonBackgroundBrush";
            return Application.Current.Resources[brushName] ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

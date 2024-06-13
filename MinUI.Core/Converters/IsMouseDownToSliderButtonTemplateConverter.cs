using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MinUI.Core.Converters
{
    internal class IsMouseDownToSliderButtonTemplateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isMouseDown = (bool)value;
            var resources = Application.Current.Resources;
            return isMouseDown ? resources["MouseDownSliderButtonTemplate"] : resources["DefaultSliderButtonTemplate"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

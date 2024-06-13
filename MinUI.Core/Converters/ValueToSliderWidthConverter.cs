using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MinUI.Core.Converters
{
    public class ValueToSliderWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Slider slider = (Slider)value;
            double val = (double)slider.Value;
            if (val <= 0)
            {
                return 0;
            }
            double width = (slider.Width / 100) * val;
            if (width <= slider.Height)
            {
                return slider.Height;
            }
            if (width >= 100)
            {
                return 100;
            }
            return width;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

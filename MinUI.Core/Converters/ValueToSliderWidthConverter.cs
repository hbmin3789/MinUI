using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MinUI.Core.Converters
{
    public class ValueToSliderWidthConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var BackgroundWidth = (double)values[0];
                double val = (double)values[1];
                double maxVal = (double)values[2];
                double minVal = (double)values[3];
                double newWidth = (BackgroundWidth * val) / (maxVal - minVal);
                if (val <= 0)
                {
                    return 0;
                }
                if (newWidth >= BackgroundWidth)
                {
                    return BackgroundWidth;
                }
                return newWidth;
            }
            catch
            {
                return 0;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

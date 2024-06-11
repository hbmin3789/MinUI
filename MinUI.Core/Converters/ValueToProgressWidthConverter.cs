using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MinUI.Core.Converters
{
    public class ValueToProgressWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ProgressBar progressBar = (ProgressBar)value;
            double val = (double)progressBar.Value;
            if (val <= 0)
            {
                return 0;
            }
            double width = (progressBar.Width / 100) * val;
            if (width <= progressBar.Height) 
            {
                return progressBar.Height;
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

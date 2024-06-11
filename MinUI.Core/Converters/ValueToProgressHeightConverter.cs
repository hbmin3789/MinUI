using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MinUI.Core.Converters
{
    public class ValueToProgressHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ProgressBar progressBar = (ProgressBar)value;
            double val = (double)progressBar.Value;
            if (val <= 0)
            {
                return 0;
            }
            double height = (progressBar.Height / 100) * val;
            if (height <= progressBar.Width) 
            {
                return progressBar.Width;
            }
            if (height >= 100)
            {
                return 100;
            }
            return height;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

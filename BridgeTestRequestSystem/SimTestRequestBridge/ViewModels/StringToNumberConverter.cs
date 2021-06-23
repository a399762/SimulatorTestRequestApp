using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SimTestRequestBridge.ViewModels
{

    public class StringToNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            NumberStyles numberStyles = System.Globalization.NumberStyles.Float;
            //Make the interface not display scientific notation
            return Decimal.Parse(value.ToString(), numberStyles);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //You can enter "." or ",", the principle is to make it report an error and not assign a value to the binding variable
            string result = (value.ToString().EndsWith(".") ? "." : value).ToString();
            result = (result.ToString().EndsWith(",") ? "," : result).ToString();
            //You can enter a decimal with 0 at the end, the principle is the same as above
            Regex re = new Regex("^([0-9]{1,}[.,][0-9]*0)$");
            result = re.IsMatch(result) ? "." : result;
            return result;
        }

    }
}

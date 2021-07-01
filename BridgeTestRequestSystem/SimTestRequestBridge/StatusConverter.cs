using SimBridge.Database;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SimTestRequestBridge
{
    public class StatusConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int TireTypeID = (int)values[0];
            IEnumerable<TireModelType> statuses = (IEnumerable<TireModelType>)values[1];

            return statuses.FirstOrDefault(x => x.TireModelTypeID == TireTypeID)?.Description;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}

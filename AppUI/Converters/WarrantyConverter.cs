using Avalonia.Data.Converters;
using ProjektP4.AppLogic.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektP4.AppUI.Converters
{


    public class WarrantyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is NonFoodProduct nfp ? $"{nfp.WarrantyPeriod} mies." : "-";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
    }
}

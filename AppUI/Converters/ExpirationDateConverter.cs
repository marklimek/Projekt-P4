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

    public class ExpirationDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is FoodProduct fp ? fp.ExpirationDate.ToString("dd.MM.yyyy") : "-";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
    }
}

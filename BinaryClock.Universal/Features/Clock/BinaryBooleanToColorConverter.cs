using System;
using Windows.UI;
using Windows.UI.Xaml.Data;

namespace BinaryClock.Universal.Features.Clock
{
    public class BinaryBooleanToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool b)
            {
                return b ? "#FF0505B6" : "#FF080914";
            }
            else
            {
                return Colors.Red.ToString();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

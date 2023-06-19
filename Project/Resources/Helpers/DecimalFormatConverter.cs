using System.Globalization;

namespace Project.Resources.Helpers
{
    public class DecimalFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is double amount ? amount % 1 == 0 ? amount.ToString("F0") : amount.ToString("F2") : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
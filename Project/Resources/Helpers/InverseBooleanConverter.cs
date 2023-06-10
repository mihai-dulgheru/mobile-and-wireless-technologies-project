using System.Globalization;

namespace Project.Resources.Helpers
{
    internal class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !((bool)value); // Invert the boolean value
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !((bool)value); // Invert the boolean value
        }
    }
}

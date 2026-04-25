using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PVSS.Helpers
{
    /// <summary>
    /// Converts a Uri (which may be null) to a BitmapImage, returning null for null input.
    /// This prevents ImageSourceConverter from throwing NotSupportedException on null values.
    /// </summary>
    public class NullImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            var uri = value as Uri;
            if (uri == null)
                return null;

            try
            {
                return new BitmapImage(uri);
            }
            catch
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

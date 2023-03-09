using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace NotesSomethingAAAA
{
    public class DaysLeftToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int daysLeft = (int)value;

            if (daysLeft <= 0)
            {
                return Brushes.Red;
            }
            else if (daysLeft <= (0.2 * Note.Days))
            {
                return Brushes.Yellow;
            }
            else
            {
                return Brushes.Green;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}

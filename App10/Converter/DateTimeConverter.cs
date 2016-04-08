using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace App10.Converter
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var allPartOfStringDate = (value as string).Split('-');

            var newDate = new DateTime(int.Parse(allPartOfStringDate[0]), int.Parse(allPartOfStringDate[1]), int.Parse(allPartOfStringDate[2]));

            return String.Format("{0:ddd, MMM d, yyyy}", newDate);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPF.Converters
{
    public class GetPreSenderMessage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "vitaly lox";
            return (value as List<Message>)[(value as List<Message>).Count - 2].Sender.Name.Split(' ')[0][0] + "" + (value as List<Message>)[(value as List<Message>).Count - 2].Sender.Name.Split(' ')[1][0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

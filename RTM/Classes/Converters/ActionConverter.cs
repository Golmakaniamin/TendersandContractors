using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace RTM.Classes.Converters
{
    class ActionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string c = (string)value;
            switch (c)
            {
                case "C":
                    return "ایجاد رکورد";
                case "D":
                    return "حذف رکورد";
                case "U":
                    return "ویرایش رکورد";
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

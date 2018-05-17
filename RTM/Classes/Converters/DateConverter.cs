using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace RTM
{
    class DateConverter :IValueConverter
    {


        public System.Object Convert(System.Object value, System.Type targetType, System.Object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            return ConvertDate(DateTime.Now);
        }

        public static string ConvertDate(DateTime date)
        {
            System.Globalization.PersianCalendar a = new System.Globalization.PersianCalendar();
            string temp = "";
            
            temp += a.GetHour(date) + ":" +(((a.GetMinute(date)/10) == 0)?("0"+a.GetMinute(date).ToString()):a.GetMinute(date).ToString()) + "     ";
            temp += a.GetYear(date).ToString() + "/" + a.GetMonth(date) + "/" + a.GetDayOfMonth(date);
            return temp;
        }

        public System.Object ConvertBack(System.Object value, System.Type targetType, System.Object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
    class DateConverterGrid : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return "";
            }
            DateTime date = (DateTime)value;
            System.Globalization.PersianCalendar a = new System.Globalization.PersianCalendar();
            string temp = "";
            if (a.GetHour(date) == 0 && a.GetMinute(date) == 0)
            {
                temp += a.GetYear(date).ToString() + "/" + a.GetMonth(date) + "/" + a.GetDayOfMonth(date);
                return temp;
            }
            temp += a.GetHour(date) + ":" + (((a.GetMinute(date) / 10) == 0) ? ("0" + a.GetMinute(date).ToString()) : a.GetMinute(date).ToString()) + "     ";
            temp += a.GetYear(date).ToString() + "/" + a.GetMonth(date) + "/" + a.GetDayOfMonth(date);
            return temp;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}

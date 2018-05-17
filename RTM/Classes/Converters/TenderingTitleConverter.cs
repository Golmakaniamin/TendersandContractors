using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace RTM.Classes.Converters
{
    class TenderingTitleConverter :IValueConverter
    {
        #region IValueConverter Members
        public static List<TenderingTitle> list = new List<TenderingTitle>();
        public static List<TenderingTitle> GetList()
        {
            try
            {
                if (list.Count == 0)
                    list = (from items in (new RTMEntities()).TenderingTitles select items).ToList();
            }
            catch (System.Exception ex)
            {

            }
            return list;
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            GetList();
            return (from items in list where items.TenderingTitleId == (int)value select items.Title).FirstOrDefault().ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

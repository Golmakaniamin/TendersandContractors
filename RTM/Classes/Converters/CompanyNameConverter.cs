using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace RTM.Classes.Converters
{
    class CompanyNameConverter : IValueConverter
    {
        #region IValueConverter Members
        public static List<Contractor> list = new List<Contractor>();
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            GetList();
            try
            {
            	return (from items in list where items.ContractorId == (int)value select items.CompanyName).FirstOrDefault().ToString();
            }
            catch (System.Exception ex)
            {
                return "";
            }
        }
        public static List<Contractor> GetList()
        {
            try
            {
                if (list.Count == 0)
                    list = (from items in (new RTMEntities()).Contractors select items).ToList();
            }
            catch (System.Exception ex)
            {

            }
            return list;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

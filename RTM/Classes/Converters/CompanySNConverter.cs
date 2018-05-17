using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace RTM.Classes.Converters
{
    class CompanySNConverter :IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            CompanyNameConverter.GetList();
            var list = CompanyNameConverter.list;
            return (from items in list where items.ContractorId == (int)value select items.NationalIdNumber).FirstOrDefault().ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

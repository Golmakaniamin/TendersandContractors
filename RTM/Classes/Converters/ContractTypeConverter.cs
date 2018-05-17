using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace RTM.Classes.Converters
{
    class ContractTypeConverter :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var t = (from items in en.ContractTypes where items.ContractTypeId == (int)value select items).FirstOrDefault();

                    return t.ContractType1;
                    
                }
            }
            catch (System.Exception ex)
            {
            	
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

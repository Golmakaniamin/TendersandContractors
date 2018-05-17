using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace RTM.Classes.Converters
{
    class IssuingReferenceConverter :IValueConverter
    {
        public static List<IssuingReference> list = new List<IssuingReference>();
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (list.Count == 0)
            {
                list = DataManagement.RetrieveIssuingReferences();
            }
            try
            {
               
                foreach (var item in list)
                {
                    if (item.IssuingReferenceId == (int)value)
                        return item.Title;
                }
                return "مرجع";
            }
            catch (System.Exception ex)
            {
                return "مرجع";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

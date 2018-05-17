using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace RTM.Classes.Converters
{
    class SubsystemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                int c = Int32.Parse((string)value);
                SubSystem s = (SubSystem)c;
                switch (s)
                {
                    case SubSystem.Contract:
                        return "قراردادها";
                    case SubSystem.Regulation:
                        return "آئين نامه";
                    case SubSystem.Tendering:
                        return "مناقصات";
                    case SubSystem.UserManagement:
                        return "مديريت کاربران";
                }
                return "";
            }
            catch (System.Exception ex)
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

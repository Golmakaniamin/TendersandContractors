using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace RTM.Classes.Converters
{
    class WarrantyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            int v = (int)value;
            switch (v)
            {
                case 1:
                    return "ضمانت نامه بانکی";
                case 2:
                    return "فیش واریزی";
                case 3:
                    return "اوراق مشارکت";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string run = value as string;
            if ("ضمانت نامه بانکی".Contains(run))
                return 1;
            if ("فیش واریزی".Contains(run))
                return 2;
            if ("اوراق مشارکت".Contains(run))
                return 3;
            else
                return 1;
        }
    }
}

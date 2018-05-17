using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace RTM.Classes.Converters
{
    class PositionConverter :IValueConverter
    {
        public static List<Position> PositionList = new List<Position>();
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (PositionList.Count == 0)
            {
                PositionList = DataManagement.RetrievePositions();
            }
            var result = (from items in PositionList where items.PositionId  == (int)value select items).FirstOrDefault();
            return result.PositionTitle;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

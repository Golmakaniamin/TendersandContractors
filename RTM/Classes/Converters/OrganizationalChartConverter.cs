using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace RTM.Classes
{
    class OrganizationalChartConverter : IValueConverter
    {
        public static List<OrganizationalChart> OrganizationalPositionList = new List<OrganizationalChart>();
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (OrganizationalPositionList.Count == 0)
                {
                    OrganizationalPositionList = DataManagement.RetrieveOrganizationChart();
                }
                var result = (from items in OrganizationalPositionList where items.ChartNodeId == (int)value select items).FirstOrDefault();
                return result.Title;
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

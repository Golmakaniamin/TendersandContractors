using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace RTM.Classes.Converters
{
    class TenderingRequestNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ContractorRequest c = DataManagement.RetrieveTenderingContractorRequest(new Tendering() { ContractorRequestId = (int)value });
            return c.RequestNumber;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class TenderingNoticeNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ContractorRequest c = DataManagement.RetrieveTenderingContractorRequest(new Tendering() { ContractorRequestId = (int)value });
            return c.NoticeNumber;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    
    class TenderingRequestingUnitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ContractorRequest c = DataManagement.RetrieveTenderingContractorRequest(new Tendering() { ContractorRequestId = (int)value });
            return (new OrganizationalChartConverter()).Convert(c.RequestingUnit,null,null,null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class TenderingProjectCodeUnitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ContractorRequest c = DataManagement.RetrieveTenderingContractorRequest(new Tendering() { ContractorRequestId = (int)value });
            return (new OrganizationalChartConverter()).Convert(c.RequestingUnit, null, null, null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

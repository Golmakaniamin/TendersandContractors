using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RTM.Classes;
namespace RTM.Report.Report3
{
    /// <summary>
    /// Interaction logic for Report3_Viewer.xaml
    /// </summary>
    public partial class Report3_Viewer : Page
    {
        public Meeting CurrentMeet { set; get; }
        public Tendering CurrentTender { set; get; }

        public Report3_Viewer()
        {
            InitializeComponent();
        }

        public Report3_Viewer( Meeting x , Tendering y)
        {
            InitializeComponent();
            CurrentMeet = x;
            CurrentTender = y;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void crystalReportsViewer1_Loaded(object sender, RoutedEventArgs e)
        {
            if (CurrentTender.StageId < (int)Stages.TenderingMeeting)
            {
                ErrorHandler.NotifyUser("ایجاد صورتجلسه توجیهی تا قبل از تایید نهایی درخواست مناقصه امکان پذیر نیست");
                return;
            }
            var report = new RTM.Report.Report3.Report3_Main();
            report.SetDatabaseLogon("ratec", "ratec");
            report.SetParameterValue("IdParam", CurrentMeet.MeetingId);
            report.SetParameterValue("MeetNumParam", CurrentMeet.MeetingId.ToString());
            report.SetParameterValue(1, DateConverter.ConvertDate((DateTime)(CurrentTender.BriefingSessionDate).Value.Date).Substring(4));
            report.SetParameterValue(2, DateConverter.ConvertDate((DateTime)(CurrentTender.RecievingDocumentsDate).Value.Date).Substring(4));
            report.SetParameterValue(3, DateConverter.ConvertDate((DateTime)(CurrentTender.RecievingDocumentDeadline).Value.Date).Substring(4));
            report.SetParameterValue(4, DateConverter.ConvertDate((DateTime)(CurrentTender.SuggestionRecieveDate).Value.Date).Substring(4));
            report.SetParameterValue(5, DateConverter.ConvertDate((DateTime)(CurrentTender.SuggestionOpenDate).Value.Date).Substring(4));
            string GarantyType;
            if (CurrentTender.StockWarranty == true)
                GarantyType = "اوراق مشارکت";
            else if (CurrentTender.LcWarranty == true)
                GarantyType = "ضمانتنامه بانکی";
            else if (CurrentTender.DraftWarranty == true)
                GarantyType = "فیش واریزی";
            else
                GarantyType = "";
            report.SetParameterValue(6, GarantyType);
            report.SetParameterValue("LocParam", CurrentTender.Location);
            report.SetParameterValue("PriceParam", CurrentTender.GuarantyPrice.ToString().Split('.')[0]);
            if ( CurrentTender.TenderingNumber!=null)
                report.SetParameterValue("TenderNumParam", CurrentTender.TenderingNumber);
            else
                report.SetParameterValue("TenderNumParam", "ندارد");
            if (CurrentMeet.MeetingDescription.Trim() == "" || CurrentMeet.MeetingDescription == null )
                report.SetParameterValue("NoteParam", "");
            else
                report.SetParameterValue("NoteParam", CurrentMeet.MeetingDescription);
            crystalReportsViewer1.ViewerCore.ReportSource = report;
        }
    }
}

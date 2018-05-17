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
namespace RTM.Report.Report5
{
    /// <summary>
    /// Interaction logic for Report5_Viewer.xaml
    /// </summary>
    public partial class Report5_Viewer : Page
    {
        public Meeting CurrentMeet { set; get; }
        public Tendering CurrentTender { set; get; }

        public Report5_Viewer()
        {
            InitializeComponent();
        }

        public Report5_Viewer( Meeting x , Tendering y)
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
            var report = new RTM.Report.Report5.Report5_Main();
            report.SetDatabaseLogon("ratec", "ratec");
            report.SetParameterValue(1, DateConverter.ConvertDate((DateTime)(CurrentMeet.MeetingDate)));
            report.SetParameterValue(2, DateConverter.ConvertDate((DateTime)(CurrentTender.RecievingDocumentsDate)));
            report.SetParameterValue(3, DateConverter.ConvertDate((DateTime)(CurrentTender.RecievingDocumentDeadline)));
            report.SetParameterValue(4, DateConverter.ConvertDate((DateTime)(CurrentTender.SuggestionRecieveDate)));
            report.SetParameterValue(5, DateConverter.ConvertDate((DateTime)(CurrentTender.SuggestionOpenDate)));
            string GarantyType;
            string RefrenceType;
            if (CurrentTender.StockWarranty == true)
                GarantyType = "اوراق مشارکت";
            else if (CurrentTender.LcWarranty == true)
                GarantyType = "ضمانتنامه بانکی";
            else if (CurrentTender.DraftWarranty == true)
                GarantyType = "فیش واریزی";
            else
                GarantyType = "";
            report.SetParameterValue(6, GarantyType);
            if (CurrentMeet.ExtendByApplicant == true)
                RefrenceType = "درخواست واحد متقاضی";
            else if (CurrentMeet.ExtendByCommittee == true)
                RefrenceType = "نظر کمیسیون";
            else
                RefrenceType = "";
            report.SetParameterValue(7, RefrenceType);
            report.SetParameterValue(8, DateConverter.ConvertDate((DateTime)(CurrentMeet.ExtendedRecieveDate)));
            crystalReportsViewer1.ViewerCore.ReportSource = report;
        }
    }
}

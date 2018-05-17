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
namespace RTM.Report.Report6
{
    /// <summary>
    /// Interaction logic for Report6_Viewer.xaml
    /// </summary>
    public partial class Report6_Viewer : Page
    {
        public Meeting CurrentMeet { set; get; }
        public Tendering CurrentTender { set; get; }
        public ContractorRequest CurrentReq { set; get; }
        public Report6_Viewer()
        {
            InitializeComponent();
        }

        public Report6_Viewer( Meeting x , Tendering y)
        {
            InitializeComponent();
            CurrentMeet = x;
            CurrentTender = y;
            CurrentReq = DataManagement.RetrieveTenderingContractorRequest(y);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void crystalReportsViewer1_Loaded(object sender, RoutedEventArgs e)
        {
            var report = new RTM.Report.Report6.Report6_Main();
            report.SetDatabaseLogon("ratec", "ratec");
            if (CurrentTender.TenderingNumber != null)
                report.SetParameterValue("TenderingNumParam", CurrentTender.TenderingNumber.ToString());
            else
                report.SetParameterValue("TenderingNumParam", "ندارد");
            report.SetParameterValue("TenderTitleParam", CurrentTender.TenderingTitle);
            report.SetParameterValue("OpenDateParam", DateConverter.ConvertDate((DateTime)(CurrentTender.SuggestionOpenDate).Value.Date).Substring(4));
            report.SetParameterValue("EstimateParam", CurrentReq.Estimatation);
            report.SetParameterValue("MeetId", CurrentMeet.MeetingId);
            crystalReportsViewer1.ViewerCore.ReportSource = report;
        }
    }
}

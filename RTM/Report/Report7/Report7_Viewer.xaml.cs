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
namespace RTM.Report.Report7
{
    /// <summary>
    /// </summary>
    public partial class Report7_Viewer : Page
    {
        public Tendering CurrentTender { set; get; }
        public ContractorRequest CurrentReq { set; get; }
        public Report7_Viewer()
        {
            InitializeComponent();
        }

        public Report7_Viewer(Tendering y)
        {
            InitializeComponent();
            CurrentTender = y;
            CurrentReq = DataManagement.RetrieveTenderingContractorRequest(y);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void crystalReportsViewer1_Loaded(object sender, RoutedEventArgs e)
        {
            var report = new RTM.Report.Report7.Report7_Main();
            report.SetDatabaseLogon("ratec", "ratec");
            report.SetParameterValue("TenderId", CurrentTender.TenderingId);
            if (CurrentTender.TenderingNumber != null)
                report.SetParameterValue("TenderingNumParam", CurrentTender.TenderingNumber.ToString());
            else
                report.SetParameterValue("TenderingNumParam", "ندارد");
            report.SetParameterValue("TenderTitleParam", CurrentTender.TenderingTitle);
            report.SetParameterValue("OpenDateParam", DateConverter.ConvertDate((DateTime)(CurrentTender.SuggestionOpenDate).Value.Date).Substring(4));
            report.SetParameterValue("EstimateParam", CurrentReq.Estimatation);
            report.SetParameterValue("Price", CurrentTender.GuarantyPrice);
            crystalReportsViewer1.ViewerCore.ReportSource = report;
        }
    }
}

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
namespace RTM.Report.PriceEvalReport
{
    /// <summary>
    /// </summary>
    public partial class PriceEval_Viewer : Page
    {
        public Tendering CurrentTender { set; get; }
        public Evaluation CurrentEval { set; get; }
        public PriceEval_Viewer()
        {
            InitializeComponent();
        }

        public PriceEval_Viewer(Tendering x,Evaluation y)
        {
            InitializeComponent();
            CurrentEval = y;
            CurrentTender = x;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void crystalReportsViewer1_Loaded(object sender, RoutedEventArgs e)
        {
            var report = new RTM.Report.PriceEvalReport.PriceEval_Main();
            report.SetDatabaseLogon("ratec", "ratec");
            report.SetParameterValue("TenderId", CurrentTender.TenderingId);
            report.SetParameterValue("EvalId", CurrentEval.EvaluationId);
            report.SetParameterValue("Date", DateConverter.ConvertDate((DateTime)(CurrentEval.MeetingDate).Value.Date).Substring(4));
            crystalReportsViewer1.ViewerCore.ReportSource = report;
        }
    }
}

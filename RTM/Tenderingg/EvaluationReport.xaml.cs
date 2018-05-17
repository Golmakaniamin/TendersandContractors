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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace RTM.Tenderingg
{
    /// <summary>
    /// Interaction logic for EvaluationReport.xaml
    /// </summary>
    public partial class EvaluationReport : Page
    {
        public Evaluation CurrentEval { set; get; }

        public EvaluationReport()
        {
            InitializeComponent();
        }

        public EvaluationReport(Evaluation x)
        {
            InitializeComponent();
            CurrentEval = x;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void crystalReportsViewer1_Loaded(object sender, RoutedEventArgs e)
        {
            var report = new RTM.Report.EvalRep();
            report.SetDatabaseLogon("ratec", "ratec");
            report.SetParameterValue("EvalId",CurrentEval.EvaluationId);
            report.SetParameterValue("Date", DateConverter.ConvertDate((DateTime)(CurrentEval.MeetingDate).Value.Date).Substring(4));
            report.SetParameterValue("Min", CurrentEval.MinimumScore);
            crystalReportsViewer1.ViewerCore.ReportSource = report;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {   
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

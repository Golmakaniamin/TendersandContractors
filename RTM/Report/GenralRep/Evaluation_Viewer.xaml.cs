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

namespace RTM.Report.GenralRep
{
    /// <summary>
    /// Interaction logic for Evaluation_Viewer.xaml
    /// </summary>
    public partial class Evaluation_Viewer : Page
    {
        public List<Evaluation> MyList { set; get; }
        public Evaluation_Viewer(List<Evaluation> x)
        {
            MyList = x;
            InitializeComponent();
        }

        private void crystalReportsViewer1_Loaded(object sender, RoutedEventArgs e)
        {
            var report = new RTM.Report.GenralRep.Evaluations_();
            report.SetDatabaseLogon("ratec", "ratec");
            var result = RTM.Classes.ReportQueries.Reports.SearchEvaluationReport(MyList);
            report.SetDataSource(result);
            crystalReportsViewer1.ViewerCore.ReportSource = report;
        }
    }
}

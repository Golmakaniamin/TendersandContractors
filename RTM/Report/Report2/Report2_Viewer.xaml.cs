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
namespace RTM.Report.Report2
{
    /// <summary>
    /// Interaction logic for Report2_Viewer.xaml
    /// </summary>
    public partial class Report2_Viewer : Page
    {
        public ContractorRequest Current { set; get; }

        public Report2_Viewer()
        {
            InitializeComponent();
        }

        public Report2_Viewer( ContractorRequest x )
        {
            InitializeComponent();
            Current = x;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void crystalReportsViewer1_Loaded(object sender, RoutedEventArgs e)
        {
            var report = new RTM.Report.Report2.Report2_Main();
            try
            {
                report.SetDatabaseLogon("ratec", "ratec");
                report.SetParameterValue(0, Current.ContractorRequestId);
                report.SetParameterValue(1, DateConverter.ConvertDate((DateTime)(((Current.RequestDate).Value).Date)).Substring(4));
                if (Current.HasCEOAccepted == true)
                    report.SetParameterValue(2, "موافقت");
                else
                    report.SetParameterValue(2, "مخالفت");
                if (Current.CeoNote!=null)
                    report.SetParameterValue("NoteParam", Current.CeoNote);
                else
                    report.SetParameterValue("NoteParam", " ");
                if (Current.Estimatation != null)
                    report.SetParameterValue("EstimateParam", Current.Estimatation);
                else
                    report.SetParameterValue("EstimateParam", "0");
                crystalReportsViewer1.ViewerCore.ReportSource = report;
            }
            catch
            {
                return;
            }
          
        }
    }
}

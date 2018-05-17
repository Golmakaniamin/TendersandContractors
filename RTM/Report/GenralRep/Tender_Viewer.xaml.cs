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
    /// Interaction logic for Tender_Viewer.xaml
    /// </summary>
    public partial class Tender_Viewer : Page
    {
        public List<Tendering> MyList { set; get; }
        public Tender_Viewer(List<Tendering> x)
        {
            MyList = x;
            InitializeComponent();
            crystalReportsViewer1.Owner = Window.GetWindow(this);
            this.Loaded += new RoutedEventHandler(Tender_Viewer_Loaded);

        }
       

        void Tender_Viewer_Loaded(object sender, RoutedEventArgs e)
        {
            crystalReportsViewer1.Owner = Window.GetWindow(this);
        }

        private void crystalReportsViewer1_Loaded(object sender, RoutedEventArgs e)
        {
            var report = new RTM.Report.GenralRep.Tenders_();
            report.SetDatabaseLogon("ratec", "ratec");
            var result = RTM.Classes.ReportQueries.Reports.SearchTenderingReport(MyList);
            report.SetDataSource(result);
            crystalReportsViewer1.ViewerCore.ReportSource = report;
        }
    }
}

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
using CrystalDecisions.Shared;
namespace RTM.Report.GenralRep
{
    /// <summary>
    /// Interaction logic for Download_Viewer.xaml
    /// </summary>
    public partial class Download_Viewer : Page
    {
        public List<TenderingFileDownload> MyList;
        public Download_Viewer(List <TenderingFileDownload> x)
        {
            InitializeComponent();
            MyList = x;
        }

        private void crystalReportsViewer1_Loaded(object sender, RoutedEventArgs e)
        {
            var report = new RTM.Report.GenralRep.WebDocRecieve();
            //report.SetDatabaseLogon("ratec", "ratec");
            ConnectionInfo crConnection = new ConnectionInfo();
            crConnection.ServerName = @"GIS-SERVER";
            crConnection.DatabaseName = "ratec";
            crConnection.UserID = "ratec";
            crConnection.Password = "ratec";
            CrystalDecisions.CrystalReports.Engine.Tables tables = report.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                CrystalDecisions.Shared.TableLogOnInfo tableLogonInfo = table.LogOnInfo;
                tableLogonInfo.ConnectionInfo = crConnection;
                table.ApplyLogOnInfo(tableLogonInfo);
            }
            foreach (TenderingFileDownload t in MyList)
            {
                t.PersianDate = DateConverter.ConvertDate(t.date);
            }
            report.SetDataSource(MyList);
            crystalReportsViewer1.ViewerCore.ReportSource = report;
        }
    }
}

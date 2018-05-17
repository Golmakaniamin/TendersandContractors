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
namespace RTM.Report.GenralRep
{
    /// <summary>
    /// Interaction logic for Log_Viewer.xaml
    /// </summary>



    public partial class Log_Viewer : Page
    {
        DateTime? fromdate, todate;
        string sub;
        public Log_Viewer(DateTime? from,DateTime? to,string su)
        {
            fromdate = from;
            todate = to;
            sub = su;
            InitializeComponent();
        }

        private void crystalReportsViewer1_Loaded(object sender, RoutedEventArgs e)
        {
            var report = new RTM.Report.GenralRep.Log_();
            var en = new RTMEntities();
            report.SetDatabaseLogon("ratec", "ratec");


            var result = (from item in en.Logs
                          from users in en.Users
                          from pos in en.Positions
                          where item.Subsystem == sub &&
                          item.UserId == users.UserId &&
                          users.PositionId == pos.PositionId &&
                          (fromdate == null || item.Date >= fromdate) &&
                          (todate == null || item.Date <= todate)

                          select new LogV
                          {
                              Date = (DateTime) item.Date,
                              Action  = (string)item.Action,
                              Description ="",
                              MachineName = (string)item.MachineName,
                              Subsystem  = (string)item.Subsystem,
                              UserId = (int) users.UserId,
                              Name = (string)users.Name,
                              Family =(string) users.Family,
                              PositionTitle = (string)pos.PositionTitle,
                          }).ToList();

            foreach (var x in result)
            {
                x.Description = ((new DateConverterGrid()).Convert((DateTime)x.Date,null,null,null)).ToString();
            }

            report.SetDataSource(result);
            crystalReportsViewer1.ViewerCore.ReportSource = report;
        }


    }

    public class LogV
    {
        public DateTime Date;
        public string Action;
        public string Description;
        public string MachineName;
        public string Subsystem;
        public int UserId;
        public string Name;
        public string Family;
        public string PositionTitle;
    }
}

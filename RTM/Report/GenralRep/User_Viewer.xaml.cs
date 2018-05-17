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
    /// Interaction logic for User_Viewer.xaml
    /// </summary>
    /// 
    public partial class User_Viewer : Page
    {
        List<User> list = new List<User>();
        public User_Viewer(List<User> l)
        {
            list = l;
            InitializeComponent();
        }

        private void crystalReportsViewer1_Loaded(object sender, RoutedEventArgs e)
        {
            var report = new RTM.Report.GenralRep.Users_();
            var en = new RTMEntities();
            report.SetDatabaseLogon("ratec", "ratec");
            var result = (
            from items in list
            from orgs in en.OrganizationalCharts
            from pos in en.Positions

            where orgs.ChartNodeId == items.OrganizationPosition &&
            pos.PositionId == items.PositionId
            select new us
            {
                UserId = items.UserId,
                Name = (string)items.Name,
                Family = (string)items.Family,
                SocialNumber = (string)items.SocialNumber,
                OrganizationPosition = (int)items.OrganizationPosition,
                PositionId = (int)items.PositionId,
                Status = (string)items.Status,
                PhoneNumber = (string)items.PhoneNumber,
                Title = (string)orgs.Title,
                PositionTitle = (string)pos.PositionTitle
            }).ToList();


            report.SetDataSource(result);

            crystalReportsViewer1.ViewerCore.ReportSource = report;
        }
    }

    public class us
    {
        public int UserId;
        public string Name;
        public string Family;
        public string SocialNumber;
        public int OrganizationPosition;
        public int PositionId;
        public string Status;
        public string PhoneNumber;
        public string Title;
        public string PositionTitle;
    }
}

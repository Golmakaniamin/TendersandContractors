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
    /// Interaction logic for Contractor_Viewer.xaml
    /// </summary>
    /// public
    /// 

    public partial class Contractor_Viewer : Page
    {
        public List<Contractor> MyList { set; get; }
        public Contractor_Viewer(List<Contractor> x)
        {
            MyList = x;
            InitializeComponent();
            crystalReportsViewer1.Owner = new MainWindow() ;

        }

        private void crystalReportsViewer1_Loaded(object sender, RoutedEventArgs e)
        {
            var Entity = new RTMEntities();
            var report = new RTM.Report.GenralRep.Contractors_();
            ////////Login Info
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
            ////////



            //report.SetDatabaseLogon("ratec", "ratec");


            var result = (from items in MyList
                         select new cc
                             {
                                 CompanyName = items.CompanyName!=null?(string)items.CompanyName:"-",
                                 NationalIdNumber = items.NationalIdNumber != null ? (string)items.NationalIdNumber : "-",
                                 CompanyType = items.CompanyType != null ? (string)items.CompanyType : "-",
                                 Telephone = items.Telephone!=null?(string)items.Telephone:"-",
                                 Fax = items.Fax!=null?(string)items.Fax:"-",
                                 CeoEmailAddress = items.CeoEmailAddress!=null?(string)items.CeoEmailAddress:"-",
                                 CompanyField1 = items.CompanyField1!=null?(string)items.CompanyField1:"-",
                                 CompanyBase1 = items.CompanyBase1!=null?(int)items.CompanyBase1:5,
                                 Design = items.Design!=null?(bool)items.Design:false,
                                 Procurement = items.Procurement!=null?(bool)items.Procurement:false,
                                 BuildAndOperation =items.BuildAndOperation!=null?(bool)items.BuildAndOperation:false,
                                 Finance = items.Finance!=null?(bool)items.Finance:false,
                                 ContractorId = (int)items.ContractorId,

                             }).ToList();
            report.SetDataSource(result);
            crystalReportsViewer1.ViewerCore.ReportSource = report;
        }
    }
    public class cc
    {
        public string CompanyName;
        public string NationalIdNumber;
        public string CompanyType;
        public string Telephone;
        public string Fax;
        public string CeoEmailAddress;
        public string CompanyField1;
        public int CompanyBase1;
        public bool Design;
        public bool Procurement;
        public bool BuildAndOperation;
        public bool Finance;
        public int ContractorId;
    }
}

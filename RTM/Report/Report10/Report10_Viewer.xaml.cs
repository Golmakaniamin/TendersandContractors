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

namespace RTM.Report.Report10
{
    /// <summary>
    /// Interaction logic for Report10_Viewer.xaml
    /// </summary>
    public partial class Report10_Viewer : Page
    {
        public Tendering Current { set; get; }
        public TenderingResult CurrentResult { set; get; }
        public Report10_Viewer(Tendering x,TenderingResult y)
        {
            Current = x;
            CurrentResult = y;
            InitializeComponent();
        }

        private void crystalReportsViewer1_Loaded(object sender, RoutedEventArgs e)
        {
            var report = new RTM.Report.Report10.TenderResult();
            report.SetDatabaseLogon("ratec", "ratec");
            ContractorRequest z = RTM.Classes.DataManagement.RetrieveTenderingContractorRequest(Current);
            report.SetParameterValue("ReqID",z.ContractorRequestId) ;
            report.SetParameterValue("DateParam", DateConverter.ConvertDate((DateTime)(((z.RequestDate).Value).Date)).Substring(4));
            report.SetParameterValue("DateParam1", DateConverter.ConvertDate((DateTime)(((CurrentResult.Date).Value).Date)).Substring(4));
            if (CurrentResult.Renewal == true)
            {
                report.SetParameterValue("Result", "تجدید مناقصه");
                report.SetParameterValue("Co1", "-----");
                report.SetParameterValue("Co2", "-----");
                report.SetParameterValue("Nat1","-----");
                report.SetParameterValue("Nat2","-----");
                report.SetParameterValue("Bid1",0);
                report.SetParameterValue("Bid2",0);
                if (CurrentResult.RenewalNote == null)
                    report.SetParameterValue("Note", "");
                else
                    report.SetParameterValue("Note", CurrentResult.RenewalNote);
            }
            else
            {
                var Entity = new RTMEntities();
                var x = (from n in Entity.Contractors where n.ContractorId == CurrentResult.FirstContractorWinnerId select n).FirstOrDefault();
                var y = (from n in Entity.Contractors where n.ContractorId == CurrentResult.SecondContractorWinnerId select n).FirstOrDefault();
                report.SetParameterValue("Result", "اعلام برنده");
                if (x==null)
                    report.SetParameterValue("Co1","----");
                else
                    report.SetParameterValue("Co1" , x.CompanyName);
                
                if (y==null)
                    report.SetParameterValue("Co2", "----");
                else
                    report.SetParameterValue("Co2" , y.CompanyName);

                if (x == null)
                    report.SetParameterValue("Nat1", "----");
                else
                    report.SetParameterValue("Nat1", x.NationalIdNumber);
                
                if (y==null)
                    report.SetParameterValue("Nat2" , "----");
                else
                    report.SetParameterValue("Nat2", y.NationalIdNumber);

                if (x==null)
                    report.SetParameterValue("Bid1", 0);
                else if (CurrentResult.FirstBid == null)
                {
                    RTM.Classes.ErrorHandler.NotifyUser("قیمت ها به درستی ثبت نشده");
                    return;
                }
                else
                    report.SetParameterValue("Bid1", CurrentResult.FirstBid);

                if (y==null)
                    report.SetParameterValue("Bid2", 0);
                else if (CurrentResult.SecondBid == null)
                {
                    RTM.Classes.ErrorHandler.NotifyUser("قیمت ها به درستی ثبت نشده");
                    return;
                }
                else
                    report.SetParameterValue("Bid2", CurrentResult.SecondBid);
                if (CurrentResult.Notes == null)
                    report.SetParameterValue("Note", "");
                else
                    report.SetParameterValue("Note", CurrentResult.Notes);
            }

            
            crystalReportsViewer1.ViewerCore.ReportSource = report;
        }
    }
}

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
namespace RTM.Report.Havale
{
    /// <summary>
    /// Interaction logic for Havale_Viewer.xaml
    /// </summary>
    public partial class Havale_Viewer : Page
    {
        public Contract CurrentContract { set; get; }
        public PaymentDraft CurrentDraft { set; get; }
        public Boolean HaveTrans { set; get; }
        PaymentDraftRep report = new RTM.Report.Havale.PaymentDraftRep();
        public Havale_Viewer(Contract x , PaymentDraft y , Boolean haveTrans)
        {
            CurrentContract = x;
            CurrentDraft = y;
            HaveTrans = haveTrans;
            InitializeComponent();
        }

        private void crystalReportsViewer1_Loaded(object sender, RoutedEventArgs e)
        {
            var Entity = new RTMEntities();
            ////////Login Info
            ConnectionInfo crConnection = new ConnectionInfo();
            crConnection.ServerName = @"Gis-Server";
            crConnection.DatabaseName = "ratec";
            crConnection.UserID = "ratec";
            crConnection.Password = "ratec";
            //crConnection.ServerName = @".";
            //crConnection.DatabaseName = "ratec";
            //crConnection.UserID = "sa";
            //crConnection.Password = "admin-91";
            CrystalDecisions.CrystalReports.Engine.Tables tables = report.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                CrystalDecisions.Shared.TableLogOnInfo tableLogonInfo = table.LogOnInfo;
                tableLogonInfo.ConnectionInfo = crConnection;
                table.ApplyLogOnInfo(tableLogonInfo);
            }
            ////////
            var x = (from n in Entity.OrganizationalCharts where n.ChartNodeId == CurrentContract.SupervisingUnitHigher select n).FirstOrDefault();
            CalculateExtrasContract();
            //report.SetDatabaseLogon("ratec", "ratec");
            report.SetParameterValue("ContractId", CurrentContract.Contractid);
            report.SetParameterValue("DraftId", CurrentDraft.PaymentDraftId);
            report.SetParameterValue("Date", DateConverter.ConvertDate((DateTime)(((CurrentContract.ContractDate).Value).Date)).Substring(4));

            if (Convert.ToString(CurrentDraft.PayableAmount) != string.Empty)
                report.SetParameterValue("Amount", CurrentDraft.PayableAmount);
            else
                report.SetParameterValue("Amount", 0);

            if ( x!=null )
                report.SetParameterValue("Supervisor", x.Title);
            else
                report.SetParameterValue("Supervisor", "-");
            ////////////////////////////////////////////////////////////////////////// you have a problem here in your code 
            decimal B;
            if (CurrentDraft.EmployerInsurancePercentage != 0 || CurrentDraft.EmployerInsurancePercentage != null)
                B = ((((decimal)CurrentDraft.CurrentSituationDraft) - ((decimal)CurrentDraft.PerviousSituationDraft)) * (((decimal)(CurrentDraft.EmployerInsurancePercentage)) / 100));                
            else
                B =  ((((decimal)CurrentDraft.CurrentSituationDraft) - ((decimal)CurrentDraft.PerviousSituationDraft)));

            report.SetParameterValue("Bimeh",B);
            report.SetParameterValue("HaveTrans", HaveTrans);
            // added by naseri
            PNumberTString dd = new PNumberTString();
            decimal Subtract = (((decimal)CurrentDraft.CurrentSituationDraft) - ((decimal)CurrentDraft.PerviousSituationDraft));
            report.SetParameterValue("Subtract",Subtract);
            try
            {
                report.SetParameterValue("NumToWord", dd.num2str(Convert.ToString(Convert.ToInt64(CurrentDraft.PayableAmount))));
            }
            catch(Exception)
            {}
            if (!HaveTrans)
            {
                report.SetParameterValue("User", string.Empty);
            }
            // added by naseri
            crystalReportsViewer1.ViewerCore.ReportSource = report;
        }
        private void CalculateExtrasContract()
        {
            using (var en = new RTMEntities())
            {
                var complements = (
                                  from items in en.ContractDocFileRelations
                                  where items.ContractId == CurrentContract.Contractid &&
                                      (items.ContractDocId == 1 || items.ContractDocId == 2)
                                  select items.FileId).ToList();
                var lastPercentage = (
                                    from items in en.ContractFiles
                                    where complements.Contains(items.FileId)
                                             && items.Is25Percent == true
                                    select items).ToList().LastOrDefault();
                if (lastPercentage != null)
                {
                    report.SetParameterValue("25Num", lastPercentage.NotificationNumber);
                    report.SetParameterValue("25Date", DateConverter.ConvertDate((DateTime)(lastPercentage.NotificationDate).Value.Date).Substring(4));
                }
                else 
                {
                    report.SetParameterValue("25Num", "-");
                    report.SetParameterValue("25Date", "-");
                }
                
                double? SumPercentage = (double?)(
                                    from items in en.ContractFiles
                                    where complements.Contains(items.FileId)
                                             && items.Is25Percent == true
                                    select items.Percent).ToList().Sum();
                SumPercentage = SumPercentage *(double?) CurrentContract.ContractBudget / 100;
                report.SetParameterValue("25Price",SumPercentage==null?0:SumPercentage);
                double? amount = (double?)(
                                    from items in en.ContractFiles
                                    where complements.Contains(items.FileId)
                                             && items.IsExtend == true
                                    select items.Amount).ToList().Sum();

                report.SetParameterValue("CompletePrice",amount==null?0:amount);
                var lastComplement = (
                                    from items in en.ContractFiles
                                    where complements.Contains(items.FileId)
                                             && items.IsExtend == true
                                    select items).ToList().LastOrDefault();
                if (lastComplement != null)
                {
                    report.SetParameterValue("CompleteNum", lastComplement.NotificationNumber);
                    report.SetParameterValue("CompleteDate", DateConverter.ConvertDate((DateTime)(lastComplement.AttachedDate).Value.Date).Substring(4));
                }
                else
                {
                    report.SetParameterValue("CompleteNum", "-");
                    report.SetParameterValue("CompleteDate", "-");
                }

                report.SetParameterValue("PrintDate", DateConverter.ConvertDate((DateTime)(CurrentDraft.Date).Value.Date).Substring(4));
                if (CurrentDraft.ModelTitle==null)
                    report.SetParameterValue("ModelTitle", "-");
                else
                    report.SetParameterValue("ModelTitle", CurrentDraft.ModelTitle);

                var consultant = (from n in en.Contractors where n.ContractorId == CurrentContract.ConsultantId select n).FirstOrDefault();
                if (consultant == null)
                    report.SetParameterValue("Consultant", "-");
                else
                    report.SetParameterValue("Consultant", consultant.CompanyName);

                if (CurrentDraft.Notes == null || CurrentDraft.Notes.Trim()=="")
                    report.SetParameterValue("NoteParam", "-");
                else
                    report.SetParameterValue("NoteParam", CurrentDraft.Notes);

                if (CurrentContract.ContractTtile == null || CurrentContract.ContractTtile.Trim() == "")
                    report.SetParameterValue("ContractTitle", "-");
                else
                    report.SetParameterValue("ContractTitle", CurrentContract.ContractTtile);

                report.SetParameterValue("User", "صادرکننده : " + UserData.CurrentUser.Name + " " + UserData.CurrentUser.Family);                
            }
        }
    }
}

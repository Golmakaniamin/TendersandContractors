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

namespace RTM.Tendering1
{
    /// <summary>
    /// Interaction logic for UI18RegisterPriceOffer.xaml
    /// </summary>
    public partial class UI18RegisterPriceOffer : Page
    {
        public Tendering CurrentTendering { set; get; }
        private List<Bid> list = new List<Bid>();
        public UI18RegisterPriceOffer(Tendering t)
        {
            CurrentTendering = t;
            InitializeComponent();
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateBidsList()
        {
            var cr = DataManagement.RetrieveTenderingContractorRequest(CurrentTendering);
            foreach (var item in list)
            {
                
                double money = (double)item.Bid1;
                item.Coefficient = money / (double)cr.Estimatation;
                double pm = (1 - (double)item.Coefficient) * 100;
                if (pm > 0)
                {
                    item.Minus = pm;
                    item.Plus = 0;
                }
                else
                {
                    item.Plus = -pm;
                    item.Minus = 0;
                }
                double i = 0;
                if(Double.TryParse(ZaribTxt.Text, out i))
                    item.ImpactCoefficient = i;
                
                //var x = ((double)item.Bid1 * 100) / (100 - (i * (100 - (double)item.QualityScore)));
                //item.BalancedPrice = (decimal)x;
            }
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!CheckValidInputs(list))
                    return;
                UpdateBidsList();
                double i = 0;
                Double.TryParse(ZaribTxt.Text, out i);
                DataManagement.UpdateBids(list, CurrentTendering,i);
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["SuccessfulSave"]);
                DataManagement.UpdateTenderingStage(CurrentTendering, Stages.Bid);
            }
            catch
            {
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["FailedSave"]);
            }
        }
        private void AddEvaluationScore()
        {
            try
            {
                
                var req = DataManagement.RetrieveTenderingContractorRequest(CurrentTendering);
                var t = DataManagement.SearchTenderings("", "", req.NoticeNumber, "", "", null, null, null, null, null, null, null, null, "", null, null, true).FirstOrDefault();
                if (t != null)
                {
                    var x = DataManagement.SearchEvaluations(null, null, req.NoticeNumber, null, null, null, null, null, null).FirstOrDefault();

                    var temp = DataManagement.RetrieveEvaluationContractorsWithScoreSum(x.EvaluationId);
                    foreach (var item in temp)
                    {
                        var xxx = (from items in list where items.ContractorId == item.contractor.ContractorId select items).FirstOrDefault();
                        //if(xxx.QualityScore == null)
                        xxx.QualityScore = item.totalScore;
                    }
                }
            }
            catch (System.Exception ex)
            {
                
            }
        }
        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            Header.CurrentRequest = DataManagement.RetrieveTenderingContractorRequest(CurrentTendering);
            list = DataManagement.RetrieveBids(CurrentTendering);
            dataGrid.ItemsSource = list;
            dataGrid.Items.Refresh();
            if (list.Count > 0)
            {
                var temp = list.FirstOrDefault();
                ZaribTxt.Text = temp.ImpactCoefficient.ToString();
            }
            AddEvaluationScore();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (! UserData.CurrentAccessRight.TenderingDelete)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, TenderingIndex.Bidding, null, null, this.layoutRoot);
        }

        private void OpenFileBtn_Click(object sender, RoutedEventArgs e)
        {
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.Bidding, null, null, this.layoutRoot);
        }

        private void SesionRecordAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!UserData.CurrentAccessRight.TenderingWrite)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.Bidding, null, null, this.layoutRoot);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.TenderingType != "محدود دو مرحله اي" && CurrentTendering.TenderingType != "عمومي دو مرحله اي")
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            if (!UserData.CurrentAccessRight.TenderingWrite)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.BiddingCommitteeMeeting, null, null, this.layoutRoot);
        }

        private void OpenFile1_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.TenderingType != "محدود دو مرحله اي" && CurrentTendering.TenderingType != "عمومي دو مرحله اي")
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.BiddingCommitteeMeeting, null, null, this.layoutRoot);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.TenderingType != "محدود دو مرحله اي" && CurrentTendering.TenderingType != "عمومي دو مرحله اي")
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            if (!UserData.CurrentAccessRight.TenderingDelete)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, TenderingIndex.BiddingCommitteeMeeting, null, null, this.layoutRoot);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            
            if (CurrentTendering.TenderingType != "محدود دو مرحله اي" && CurrentTendering.TenderingType != "عمومي دو مرحله اي" && CurrentTendering.HasQualityEvaluation==false)
            {
                ErrorHandler.ShowErrorMessage("این مناقصه ارزیابی کیفی ندارد");
                return;
            }
            if (!UserData.CurrentAccessRight.TenderingWrite)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.TechincalCommitteeMeeting, null, null, this.layoutRoot);
        }

        private void OpenFile2_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.TenderingType != "محدود دو مرحله اي" && CurrentTendering.TenderingType != "عمومي دو مرحله اي" && CurrentTendering.HasQualityEvaluation == false)
            {
                ErrorHandler.ShowErrorMessage("این مناقصه ارزیابی کیفی ندارد");
                return;
            }
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.TechincalCommitteeMeeting, null, null, this.layoutRoot);
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.TenderingType != "محدود دو مرحله اي" && CurrentTendering.TenderingType != "عمومي دو مرحله اي" && CurrentTendering.HasQualityEvaluation == false)
            {
                ErrorHandler.ShowErrorMessage("این مناقصه ارزیابی کیفی ندارد");
                return;
            }
            if (!UserData.CurrentAccessRight.TenderingDelete)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, TenderingIndex.TechincalCommitteeMeeting, null, null, this.layoutRoot);
        }

        private void PriceTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox Tmp = (TextBox)sender;
            foreach (char x in Tmp.Text)
            {
                if (!char.IsDigit(x))
                {
                    ErrorHandler.NotifyUser("این فیلد فقط شامل مقادیر عددی است");
                    Tmp.Text = "";
                    return;
                }
            }
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.StageId < (int)Stages.Bid)
            {
                ErrorHandler.NotifyUser("ابتدا به ثبت پیشنهادها بپردازید");
                return;
            }
            else
            {
                NavigationHandler.NavigateToPage(this, new RTM.Report.Report8.Report8_Viewer(CurrentTendering));
            }
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var text = e.EditingElement as TextBox;
            var date = e.EditingElement as DatePicker;

            if (text != null)
            {
                if (text.Text == "" || text.Text == null)
                {
                    ErrorHandler.ShowErrorMessage(e.Column.Header.ToString() + " باید پر شود");
                    e.Cancel = true;
                    return;
                }
                return;
            }
            else if (date != null)
            {
                if (date.SelectedDate == null)
                {
                    ErrorHandler.ShowErrorMessage(e.Column.Header.ToString() + " باید انتخاب  شود");
                    e.Cancel = true;
                    return;
                }
                return;
            }
        }
        public bool CheckValidInputs(List<Bid> list)
        {
            try
            {
                UpdateBidsList();
            }
            catch (System.Exception ex)
            {
                return false;	
            }
            bool hasError = false;
            Bid errorItem = null;
            string response = "";
            foreach (var item in list)
            {
                var x = item as Bid;


                if (x.Bid1 ==null)
                {
                    response += "مبلغ پیشنهادی";
                    hasError = true;
                    errorItem = x;
                    break;
                }
                //else if (x.QualityScore > 100 || x.QualityScore < 0)
                //{
                //    response += "امتیاز فنی";
                //    hasError = true;
                //    errorItem = x;
                //    break;
                //}
                //else if (x.Coefficient == null || x.Coefficient <= 0)
                //{
                //    response += "ضریب";
                //    hasError = true;
                //    errorItem = x;
                //    break;
                //}
                //else if (x.ImpactCoefficient == null )
                //{
                //    response += "ضریب تأثیر";
                //    hasError = true;
                //    errorItem = x;
                //    break;
                //}
                //else if (x.QualityScore == null || x.QualityScore <0)
                //{
                //    response += "امتیاز فنی";
                //    hasError = true;
                //    errorItem = x;
                //    break;
                //}
                
            }
            if (hasError)
            {
                dataGrid.SelectedItem = errorItem;
                ErrorHandler.ShowErrorMessage(response + " صحیح وارد نشده است.");
                return false;
            }
            return true;

        }


    }
}

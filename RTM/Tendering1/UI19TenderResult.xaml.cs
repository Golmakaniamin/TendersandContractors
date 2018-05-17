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
    /// Interaction logic for UI19TenderResult.xaml
    /// </summary>
    public partial class UI19TenderResult : Page
    {

        public Tendering CurrentTendering;
        public TenderingResult CurrentResult = null;
        private List<Bid> bids = new List<Bid>();
        public UI19TenderResult()
        {
            InitializeComponent();
        }

        public UI19TenderResult(Tendering t)
        {

            CurrentTendering = t;
            CurrentResult = DataManagement.SearchOrCreateTenderingResult(CurrentTendering);
            InitializeComponent();
        }

        private void page_loaded(object sender, RoutedEventArgs e)
        {
           Header.CurrentRequest = DataManagement.RetrieveTenderingContractorRequest(CurrentTendering);
            if (ResetTenderRadio.IsChecked == false)
                WinnerRadio.IsChecked = true;
            FirstWinnerCom.ItemsSource = DataManagement.RetrieveContractorsWhoSubmitPacket(CurrentTendering);
            SecondWinnerCom.ItemsSource = DataManagement.RetrieveContractorsWhoSubmitPacket(CurrentTendering);
            this.DataContext = CurrentResult;
            if (CurrentResult.Renewal == false)
            {
                WinnerRadio.IsChecked = true;
            }
            if (CurrentResult.FirstContractorWinnerId == null)
            {
                using (var en = new RTMEntities())
                {
                    bids = (from items in en.Bids where items.TenderingId == CurrentTendering.TenderingId orderby items.Bid1 select items).ToList();
                    if (bids.Count == 0)
                        return;
                    int c1 = bids[0].ContractorId;
                    CurrentResult.FirstContractorWinnerId = c1;
                    if (bids.Count == 1)
                        return;
                    else if ((bids[1].Bid1 - bids[0].Bid1) > CurrentTendering.GuarantyPrice)
                        return;
                    int c2 = bids[1].ContractorId;
                    CurrentResult.SecondContractorWinnerId = c2;
                }
            }
        }



        private void WinnerRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (!IsInitialized)
                return;
            FirstWinnerCom.IsEnabled = true;
            FirstCompanyCodeTxt.IsEnabled = true;
            FirstOfferPriceTxt.IsEnabled = true;
            FirstDescriptionTxt.IsEnabled = true;
            SecOfferPriceTxt.IsEnabled = true;
            SecCompanyCodeTxt.IsEnabled = true;
            SecondWinnerCom.IsEnabled = true;
        }

        private void WinnerRadio_Unchecked(object sender, RoutedEventArgs e)
        {

            if (!IsInitialized)
                return;
            FirstWinnerCom.IsEnabled = false;
            FirstCompanyCodeTxt.IsEnabled = false;
            FirstOfferPriceTxt.IsEnabled = false;
            FirstDescriptionTxt.IsEnabled = false;
            SecOfferPriceTxt.IsEnabled = false;
            SecCompanyCodeTxt.IsEnabled = false;
            SecondWinnerCom.IsEnabled = false;
        }

        private void ResetTenderRadio_Checked(object sender, RoutedEventArgs e)
        {

            if (!IsInitialized)
                return;
            SecDescriptionTxt.IsEnabled = true;
        }

        private void ResetTenderRadio_Unchecked(object sender, RoutedEventArgs e)
        {

            if (!IsInitialized)
                return;
            SecDescriptionTxt.IsEnabled = false;
        }




        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("این سند به تایید نهایی رسیده است");
                return;
            }
            if (WinnerRadio.IsChecked == false && ResetTenderRadio.IsChecked == false)
            {
                ErrorHandler.NotifyUser("نتیجه مناقصه مشخص نشده است");
                return;
            }
            if (DateDP.SelectedDate == null)
            {
                ErrorHandler.NotifyUser("تاریخ جلسه مشخص نشده است");
                return;
            }
            if (bids.Count > 1)
            {
                CurrentResult.FirstBid = decimal.Parse(FirstOfferPriceTxt.Text);
                try
                {
                    CurrentResult.SecondBid = decimal.Parse(SecOfferPriceTxt.Text);
                }
                catch (Exception eddd)
                {
                    CurrentResult.SecondBid = 0;
                }
            }
            DataManagement.UpdateTenderingResult(CurrentResult);
            DataManagement.UpdateTenderingStage(CurrentTendering, Stages.Result);
            ErrorHandler.NotifyUser("ثبت با موفقیت انجام شد");
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!UserData.CurrentAccessRight.TenderingWrite)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.Result, null, null, this.layoutRoot);
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!UserData.CurrentAccessRight.TenderingDelete)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, TenderingIndex.Result, null, null, this.layoutRoot);
        }

        private void ShowBtn_Click(object sender, RoutedEventArgs e)
        {
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.Result, null, null, this.layoutRoot);
        }

        private void PermanentBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UserData.CurrentAccessRight.TenderingPermanentWrite != true)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            if (CurrentTendering.PermanentRecord == false)
            {
                if (ErrorHandler.PromptUserForPermision("ثبت دائم صورت گیرد ؟") == MessageBoxResult.Yes)
                {
                    CurrentTendering.PermanentRecord = true;
                    DataManagement.UpdateTendering(CurrentTendering);
                    ErrorHandler.NotifyUser("سند به ثبت نهایی رسید");
                }
            }
            else
            {
                ErrorHandler.NotifyUser("سند قبلا به ثبت نهایی رسیده است ");
            }
        }

        public object SelectedConntractorInfo(Contractor c)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var res = (from contractor in en.Contractors
                               from bid in en.Bids
                               where contractor.ContractorId == c.ContractorId &&
                               contractor.ContractorId == bid.ContractorId &&
                               bid.TenderingId == CurrentTendering.TenderingId
                               select new
                               {
                                   //Plus = bid.Plus,
                                   //Minus = bid.Minus,
                                   Coeffecient = bid.Coefficient,
                                   SN = contractor.NationalIdNumber,
                                   Price = bid.Bid1
                               }
                                   ).FirstOrDefault();
                    return res;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        private void FirstWinnerCom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (FirstWinnerCom.SelectedIndex != -1)
            //    FirstCompanyCodeTxt.Text = (FirstWinnerCom.SelectedItem as Contractor).NationalIdNumber;
            if (FirstWinnerCom.SelectedIndex == -1)
                return;
            FirstWinnerDataContext.DataContext = SelectedConntractorInfo(FirstWinnerCom.SelectedItem as Contractor);

        }

        private void SecondWinnerCom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (SecondWinnerCom.SelectedIndex != -1)
            //    SecCompanyCodeTxt.Text = (SecondWinnerCom.SelectedItem as Contractor).NationalIdNumber;

            if (SecondWinnerCom.SelectedIndex == -1)
                return;
            SecondWinnerDataContext.DataContext = SelectedConntractorInfo(SecondWinnerCom.SelectedItem as Contractor);
        }

        private void SecPlusTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CalcBtn_Click(object sender, RoutedEventArgs e)
        {
            //if (FirstOfferFactorTxt.Text == "" || SecOfferFactorTxt.Text == "" || double.Parse(FirstOfferFactorTxt.Text)>100 || double.Parse(SecOfferFactorTxt.Text)>100)  
            //{
            //    ErrorHandler.NotifyUser("ضریب پیشنهادی درست وارد نشده است");
            //    return;
            //}
            //FirstPlusTxt.Text = FirstMinusTxt.Text = (double.Parse(FirstOfferFactorTxt.Text) * double.Parse(FirstOfferPriceTxt.Text)/100).ToString();
            //SecPlusTxt.Text = SecMinusTxt.Text = (double.Parse(SecOfferFactorTxt.Text) * double.Parse(SecOfferPriceTxt.Text)/100).ToString();

        }

        private void SecMinusTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SecOfferPriceTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            if (DateDP.SelectedDate == null)
            {
                ErrorHandler.NotifyUser("تاریخ جلسه مشخص نشده است");
                return;
            }
            NavigationHandler.NavigateToPage(this, new RTM.Report.Report10.Report10_Viewer(CurrentTendering, CurrentResult));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            SecondWinnerCom.SelectedIndex = -1;
            SecondWinnerDataContext.DataContext = null;
            //SecOfferPriceTxt.Text = "";
            //SecCompanyCodeTxt.Text = "";
        }







    }
}

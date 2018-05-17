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
    /// Interaction logic for UI4.xaml
    /// </summary>
    public partial class UI4HoldingTenderSesion : Page
    {
        private ContractorRequest CurrentReq;

        public Tendering CurrentTendering;
        public bool Mode { set; get; }
        public UI4HoldingTenderSesion()
        {
            InitializeComponent();
        }

        public UI4HoldingTenderSesion(Tendering x, ContractorRequest y , bool mode=false)
        {
            Mode = mode;
            CurrentTendering = x;
            CurrentReq = y;
            InitializeComponent();
            try
            {
                foreach (var item in CurrentTendering.UserTenderingMembers)
                {
                    Grid2.Items.Add(item);
                }
            }
            catch (System.Exception ex)
            {
            	
            }
        }

        private void SuperVisionCom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddFileBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.RequestPermanentCheck == true)
            {
                ErrorHandler.NotifyUser("سند به تایید نهایی رسیده است");
                return;
            }
            if (JustificationSesionCheck.IsChecked == true &&JustificationSesionDP.SelectedDate==null ) { label29_Copy.Foreground = new SolidColorBrush(Colors.Red); } else { label29_Copy.Foreground = new SolidColorBrush(Colors.Black); }
            if (bondCheck.IsChecked == false && BankGaurantyCheck.IsChecked == false && PaidBillCheck.IsChecked == false) { label14.Foreground = new SolidColorBrush(Colors.Red); } else { label14.Foreground = new SolidColorBrush(Colors.Black); }
            if (TurnNomsCom.Text == "") { label11_Copy1.Foreground = new SolidColorBrush(Colors.Red); } else { label11_Copy1.Foreground = new SolidColorBrush(Colors.Black); }
            if (ParticipationGaurantyTxt.Text == "") { label10_Copy.Foreground = new SolidColorBrush(Colors.Red); } else { label10_Copy.Foreground = new SolidColorBrush(Colors.Black); }
            if (DocForSellCheck.IsChecked == true && DocSellPriceTxt.Text == "") { label33.Foreground = new SolidColorBrush(Colors.Red); } else { label33.Foreground = new SolidColorBrush(Colors.Black); }
            if (RecDP.SelectedDate==null) { DP1.Foreground = new SolidColorBrush(Colors.Red); } else { DP1.Foreground = new SolidColorBrush(Colors.Black); }
            if (RecEndDP.SelectedDate == null) { DP2.Foreground = new SolidColorBrush(Colors.Red); } else { DP2.Foreground = new SolidColorBrush(Colors.Black); }
            if (OffersDeadlineDP.SelectedDate == null) { DP3.Foreground = new SolidColorBrush(Colors.Red); } else { DP3.Foreground = new SolidColorBrush(Colors.Black); }
            if (OpeningOffersDP.SelectedDate == null) { DP4.Foreground = new SolidColorBrush(Colors.Red); } else { DP4.Foreground = new SolidColorBrush(Colors.Black); }
            if (HoldingSesionDP.SelectedDate == null) { label4.Foreground = new SolidColorBrush(Colors.Red); } else { label4.Foreground = new SolidColorBrush(Colors.Black); }
            if (HoldingSesionDP.SelectedDate == null || OpeningOffersDP.SelectedDate == null || OffersDeadlineDP.SelectedDate == null || RecEndDP.SelectedDate == null || RecDP.SelectedDate == null || (bondCheck.IsChecked == false && BankGaurantyCheck.IsChecked == false && PaidBillCheck.IsChecked == false) || (JustificationSesionCheck.IsChecked == true && JustificationSesionDP.SelectedDate == null) || ParticipationGaurantyTxt.Text == "" || (DocForSellCheck.IsChecked == true && DocSellPriceTxt.Text == ""))
            {
                ErrorHandler.NotifyUser("برخی از اطلاعات ضروری وارد نشده است");
                return;
            }
            if ( HoldingSesionDP.SelectedDate < CurrentReq.RequestDate || RecDP.SelectedDate < HoldingSesionDP.SelectedDate  || RecEndDP.SelectedDate < RecDP.SelectedDate || OffersDeadlineDP.SelectedDate < RecEndDP.SelectedDate || OpeningOffersDP.SelectedDate < OffersDeadlineDP.SelectedDate || (JustificationSesionCheck.IsChecked==true && JustificationSesionDP.SelectedDate < HoldingSesionDP.SelectedDate))
            {
                ErrorHandler.NotifyUser("توالی زمانی در تاریخ های وارد شده در صفحه وجود ندارد؛لطفا آنها را تصحیح کنید");
                return;
            }
            try
            {
                CurrentReq.TenderingType = CurrentTendering.TenderingType;
                DataManagement.UpdateContractorRequest(CurrentReq);
                CurrentTendering.RecievingDocumentDeadline = new DateTime(CurrentTendering.RecievingDocumentDeadline.Value.Year, CurrentTendering.RecievingDocumentDeadline.Value.Month, CurrentTendering.RecievingDocumentDeadline.Value.Day, 14, 30, 0);
                DataManagement.UpdateTendering(CurrentTendering, Grid2.Items.Cast<User>().ToList());
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["SuccessfulSave"]);
                DataManagement.UpdateTenderingStage(CurrentTendering, Stages.TenderingMeeting);
            }
            catch
            {
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["FailedSave"]);
            }
        }

        private void JustificationSesionCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (!IsInitialized)
                return;
            JustificationMinTxt.IsEnabled = true;
            JustificationHourTxt.IsEnabled = true;
            JustificationSesionDP.IsEnabled = true;
        }

        private void JustificationSesionCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!IsInitialized)
                return;
            JustificationMinTxt.IsEnabled = false;
            JustificationHourTxt.IsEnabled = false;
            JustificationSesionDP.IsEnabled = false;
        }

        private void DocForSellCheck_Checked(object sender, RoutedEventArgs e)
        {
            if (!IsInitialized)
                return;
            DocSellPriceTxt.IsEnabled = true;
        }

        private void DocForSellCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!IsInitialized)
                return;
            DocSellPriceTxt.IsEnabled = false;
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchMemberBtn_Click(object sender, RoutedEventArgs e)
        {
            var name = (NameTxt.Text.Trim() == "") ? null : NameTxt.Text;
            var family = (FamilyTxt.Text.Trim() == "") ? null : FamilyTxt.Text;
            var position = (PositionCom.Text.Trim() == "") ? null : PositionCom.Text;
            var t = DataManagement.SearchUsers(name, family, position, null);
            Grid1.ItemsSource = t;
        }

        private void ParticipationGaurantyTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            TenderTypeCom.ItemsSource = new List<string> { "عمومي يک مرحله اي", "عمومي دو مرحله اي", "محدود يک مرحله اي", "محدود دو مرحله اي", "ترک تشريفات", "انحصاري", "بين المللي" };
            PositionCom.ItemsSource = DataManagement.RetrievePositions();
            if (Grid2.Items.Count > 0)
                return;
            //foreach (var item in DataManagement.RetrieveTenderingCommittee())
            //{
            //    Grid2.Items.Add(item);
            //}
            this.DataContext = CurrentTendering;
            try
            {
                var temp = (from items in (new RTMEntities()).UserTenderingMembers where items.TenderingId == CurrentTendering.TenderingId select items.UserId).ToList();
                var temp2 = (from items in (new RTMEntities()).Users where temp.Contains(items.UserId) select items).ToList();
                foreach (var item in temp2)
                {
                    Grid2.Items.Add(item);
                }

            }
            catch (System.Exception ex)
            {

            }
            Header.CurrentRequest = CurrentReq;

            if (Mode)
            {
                label1.Content = "جلسه کمیسیون ترک تشریفات";
                TenderTypeCom.IsEnabled = false;
                TurnNomsCom.Visibility = Visibility.Hidden;
                MinScore.Visibility = Visibility.Hidden;
                HasQualityTestCheck.Visibility = Visibility.Hidden;
                label3.Visibility = Visibility.Hidden;
                label6.Visibility = Visibility.Hidden;
                label32_Copy2.Visibility = Visibility.Hidden;
            }
        }

        private void AddMemberBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid1.SelectedIndex != -1 && Grid2.Items.IndexOf(Grid1.SelectedItem) == -1)
            {
                var x = from items in Grid2.Items.Cast<User>()
                        where items.UserId == (Grid1.SelectedItem as User).UserId
                        select items;
                if (x.Count() > 0)
                    return;
                Grid2.Items.Add(Grid1.SelectedItem);
            }
        }

        private void DeleteMemberBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid2.SelectedIndex != -1)
                Grid2.Items.Remove(Grid2.SelectedItem);
        }

        private void RefreshMemberBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid1.ItemsSource = null;
            Grid2.Items.Clear();
        }

        private void ShowBtn_Click(object sender, RoutedEventArgs e)
        {
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.CommitteDicision, null, null, this.layoutRoot);
        }

        private void UploadBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.RequestPermanentCheck == true)
            {
                ErrorHandler.NotifyUser("سند به تایید نهایی رسیده است");
                return;
            }
            if (!UserData.CurrentAccessRight.TenderingWrite)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.CommitteDicision, null, null, this.layoutRoot);
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!UserData.CurrentAccessRight.TenderingDelete)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, TenderingIndex.CommitteDicision, null, null, this.layoutRoot);
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.StageId < (int)Stages.TenderingMeeting)
            {
                ErrorHandler.NotifyUser("ابتدا جلسه را ثبت نمایید");
                return;
            }
                NavigationHandler.NavigateToPage(this, new Report.Report1.Report1_Viewer(CurrentTendering));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.RequestPermanentCheck == true)
            {
                ErrorHandler.NotifyUser("سند به تایید نهایی رسیده است");
                return;
            }
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, TenderingIndex.CommitteDicision, null, null, this.layoutRoot);
        }

        private void ParticipationGaurantyTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox Tmp = (TextBox)sender;
            foreach (char x in Tmp.Text)
            {
                if (!char.IsDigit(x) && x != ',')
                {
                    ErrorHandler.NotifyUser("این فیلد فقط شامل مقادیر عددی است");
                    Tmp.Text = "";
                    return;
                }
            }
        }

        private void DocSellPriceTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox Tmp = (TextBox)sender;
            foreach (char x in Tmp.Text)
            {
                if (!char.IsDigit(x) && x != ',')
                {
                    ErrorHandler.NotifyUser("این فیلد فقط شامل مقادیر عددی است");
                    Tmp.Text = "";
                    return;
                }
            }
        }

        private void TurnNomsCom_LostFocus(object sender, RoutedEventArgs e)
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

        private void CompanySelectBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPage(this, new RTM.Tendering1.ContractorSelection(CurrentTendering));
        }

        private void TenderTypeCom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (TenderTypeCom.SelectedIndex)
            {
                case 2:
                case 3:
                case 4:
                case 5:
                    CompanySelectBtn.IsEnabled = true;
                    break;
                case 0:
                case 1:
                case 6:
                    CompanySelectBtn.IsEnabled = false;
                    break;
            }
        }

      
    }
}

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
    /// Interaction logic for UI3PresidentOrder.xaml
    /// </summary>
    public partial class UI3PresidentOrder : Page
    {
        public ContractorRequest CurrentReq;
        public Tendering CurrentTendering;

        
        public UI3PresidentOrder(ContractorRequest x)
        {
            CurrentReq = x;
            InitializeComponent();
            NextNoticeBtn.Visibility = Visibility.Hidden;
        }
        public UI3PresidentOrder(ContractorRequest x,bool TenderingNotice)
        {
            CurrentReq = x;
            InitializeComponent();
            label9.Visibility = Visibility.Hidden;
            TenderTypeCom.Visibility = Visibility.Hidden;
            PageTitle.Content = "* طبق دستور مدیر کل با درخواست فراخوان ارزیابی";
            TenderAgreeRadio.Content = "موافقت می گردد";
            TenderDisagreeRadio.Content = "مخالفت می گردد";
            CompanySelectBtn.Visibility = Visibility.Hidden;
        }
        private void SuperVisionCom_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private void TenderAgreeRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (!this.IsInitialized)
                return;
            TenderTypeCom.IsEnabled = true;
            TenderDisagreeRadio.IsChecked = false;
        }

        private void TenderAgreeRadio_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!this.IsInitialized)
                return;
            TenderTypeCom.IsEnabled = false;
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.RequestPermanentCheck == true)
            {
                ErrorHandler.NotifyUser("سند به تایید نهایی رسیده است");
                return;
            }

            if (!FilingManager.HasTenderingFile(CurrentTendering.TenderingId, TenderingIndex.CeoOrder, null, null, this.layoutRoot))
            {
                ErrorHandler.ShowErrorMessage("بارگذاری تصویر برای ثبت الزامی است.");
                return;
            }

            try
            {
                DataManagement.UpdateContractorRequest(CurrentReq);
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["SuccessfulSave"]);
                
                CurrentTendering.TenderingType = TenderTypeCom.Text;
                DataManagement.UpdateTendering(CurrentTendering);
                DataManagement.UpdateTenderingStage(CurrentTendering, Stages.CEO);
            }
            catch
            {
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["FailedSave"]);
            }
        }

        private void TenderDisagreeRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (!this.IsInitialized)
                return;
            TenderAgreeRadio.IsChecked = false;
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            TenderTypeCom.ItemsSource = new List<string> { "عمومي يک مرحله اي", "عمومي دو مرحله اي", "محدود يک مرحله اي", "محدود دو مرحله اي", "ترک تشريفات", "انحصاري", "بين المللي" };
            if(CurrentReq.HasCEOAccepted == true)
                TenderAgreeRadio.IsChecked = true;
            else
                TenderAgreeRadio.IsChecked = false;
            CurrentTendering = DataManagement.RetrieveContractorRequestTendering(CurrentReq);
            Header.CurrentRequest = CurrentReq;
            this.DataContext = CurrentReq;
            if (CurrentReq.HasCEOAccepted == false)
            {
                TenderDisagreeRadio.IsChecked = true;
            }

        }

        private void AddPicBtn_Click(object sender, RoutedEventArgs e)
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
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.CeoOrder, null, null, this.layoutRoot);
        }

        private void ShowPicBtn_Click(object sender, RoutedEventArgs e)
        {
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.CeoOrder, null, null, this.layoutRoot);
        }

        private void DelPicBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.RequestPermanentCheck == true)
            {
                ErrorHandler.NotifyUser("سند به تایید نهایی رسیده است");
                return;
            }
            if (!UserData.CurrentAccessRight.TenderingDelete)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, TenderingIndex.CeoOrder, null, null, this.layoutRoot);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPage(this, new RTM.Report.Report2.Report2_Viewer(CurrentReq));
        }

        private void CompanySelectBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPage(this, new RTM.Tendering1.ContractorSelection(CurrentTendering));
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            var c = DataManagement.RetrieveTenderingContractorRequest(CurrentTendering); 
            //if (c.HasCEOAccepted==null)
            //{
            //    ErrorHandler.NotifyUser("ابتدا دستور مدیر کل را ثبت کنید");
            //    return;
            //}
            NavigationHandler.NavigateToPage(this, new RTM.Notices.CreateNotices(CurrentTendering));
        }
    }
}

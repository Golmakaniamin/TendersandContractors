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
    /// Interaction logic for UI2CreditControl.xaml
    /// </summary>
    public partial class UI2CreditControl : Page
    {
        public ContractorRequest CurrentReq;
        public Tendering CurrentTendering { set; get; }
        public UI2CreditControl()
        {
            InitializeComponent();
        }

        public UI2CreditControl(ContractorRequest x , Tendering y)
        {
            CurrentReq = x;
            CurrentTendering = y;
            InitializeComponent();
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.RequestPermanentCheck == true)
            {
                ErrorHandler.NotifyUser("سند به تایید نهایی رسیده است");
                return;
            }
            
            if (CreditSourceTxt.Text == "" && QualifiedRadio.IsChecked == true) { label2.Foreground = new SolidColorBrush(Colors.Red); } else { label2.Foreground = new SolidColorBrush(Colors.Black); }
            if (CreditSourceCodeTxt.Text == "" && QualifiedRadio.IsChecked == true) { label5.Foreground = new SolidColorBrush(Colors.Red); } else { label5.Foreground = new SolidColorBrush(Colors.Black); }
            if (CreditControlNomTxt.Text == "" ) { label10.Foreground = new SolidColorBrush(Colors.Red); } else { label10.Foreground = new SolidColorBrush(Colors.Black); }
            if (CreditControlerManCom.SelectedIndex == -1 ) { label12.Foreground = new SolidColorBrush(Colors.Red); } else { label12.Foreground = new SolidColorBrush(Colors.Black); }
            if (CreditControlDP.SelectedDate==null) { label11.Foreground = new SolidColorBrush(Colors.Red); } else { label11.Foreground = new SolidColorBrush(Colors.Black); }
            if (ReqDateDP.SelectedDate == null) { label9.Foreground = new SolidColorBrush(Colors.Red); } else { label9.Foreground = new SolidColorBrush(Colors.Black); }
          
            if ( ReqDateDP.SelectedDate == null || CreditControlDP.SelectedDate==null || (QualifiedRadio.IsChecked == true && (CreditSourceTxt.Text == "" || ((QualifiedRadio.IsChecked == true && CreditSourceCodeTxt.Text == "") || CreditControlNomTxt.Text == "" || CreditControlerManCom.SelectedIndex == -1)) || (QualifiedRadio.IsChecked == false && DisqualifiedRadio.IsChecked == false)))
            { 
                ErrorHandler.NotifyUser("برخی از اطلاعات ضروری وارد نشده است");
                return;
            }

            if (ReqDateDP.SelectedDate > CreditControlDP.SelectedDate)
            {
                ErrorHandler.NotifyUser("تاریخ درخواست باید قبل از تاریخ کنترل باشد");
                return;
            }

            try
            {
                DataManagement.UpdateContractorRequest(CurrentReq);
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["SuccessfulSave"]);
                DataManagement.UpdateTenderingStage(CurrentTendering, Stages.CreditControl);
            }
            catch
            {
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["FailedSave"]);
            }
        }

        private void QualifiedRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (!this.IsInitialized)
                return;
            CreditControlNomTxt.IsEnabled = true;
            CreditSourceCodeTxt.IsEnabled = true;
            CreditSourceTxt.IsEnabled = true;
            CreditControlDP.IsEnabled = true;
            ReqDateDP.IsEnabled = true;
            CreditControlerManCom.IsEnabled = true;
            DisqualifiedRadio.IsChecked = false;
        }

        private void QualifiedRadio_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!this.IsInitialized)
                return;
            CreditSourceCodeTxt.IsEnabled = false;
            CreditSourceTxt.IsEnabled = false;
        }

        private void DisqualifiedRadio_Checked(object sender, RoutedEventArgs e)
        {
            QualifiedRadio.IsChecked = false;
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
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.CreditControl, null, null, this.layoutRoot);
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            CreditControlerManCom.ItemsSource = from items in DataManagement.SearchUsers(null, null, null, null) select new {
                Family = items.Family+" "+items.Name,
                UserId = items.UserId
            };
            if (CurrentReq.HasFunding == true)
            {
                QualifiedRadio.IsChecked = true;
            }
            else
            {
                DisqualifiedRadio.IsChecked = true;
            }
            CurrentTendering = DataManagement.RetrieveContractorRequestTendering(CurrentReq);
            Header.CurrentRequest = CurrentReq;
            this.DataContext = CurrentReq;
        }

        private void ShowPicBtn_Click(object sender, RoutedEventArgs e)
        {
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.CreditControl, null, null, this.layoutRoot);
        }

        private void DelPicBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.RequestPermanentCheck == true )
            {
                ErrorHandler.NotifyUser("سند به تایید نهایی رسیده است");
                return;
            }
            if (!UserData.CurrentAccessRight.TenderingDelete)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, TenderingIndex.CreditControl, null, null, this.layoutRoot);
        }

        private void DescriptionTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

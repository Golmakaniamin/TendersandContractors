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
using System.Threading.Tasks;
namespace RTM.Contracts
{
    /// <summary>
    /// Interaction logic for TransfersManagement.xaml
    /// </summary>
    public partial class TransfersManagement : Page
    {
        public Contract CurrentContract { set; get; }
        //public PaymentDraft CurrentDraft { set; get; }

        public TransfersManagement()
        {
            InitializeComponent();
        }

        public TransfersManagement(Contract x)
        {
            CurrentContract = x;
            InitializeComponent();
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Grid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DescriptionTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DisqualifiedRadio_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentContract.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("سند به ثبت نهایی رسیده است");
                return;
            }
            NavigationHandler.NavigateToPage(this, new NewPaymentTransfer(CurrentContract));
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            var source = DataManagement.RetrievePaymentDrafts(CurrentContract);
            if (CurrentContract != null)
                dataGrid.ItemsSource = source;
            Header.CurrentContract = CurrentContract;
            TotalPrice.Text = ((decimal)(DataManagement.ContractTotalAmount(CurrentContract))).ToString("N0");
            try
            {
                Karkard.Text = ((decimal)(source.Max(s => s.CurrentSituationDraft))).ToString("N0");
                PayableTotal.Text = ((decimal)(source.Sum(s => s.PayableAmount))).ToString("N0");
                Progress.Text = ((decimal)((double)source.Max(s => s.CurrentSituationDraft) * 100 / DataManagement.ContractTotalAmount(CurrentContract))).ToString("F2");
            }
            catch (System.Exception ex)
            {

            }
        }

        private void BrowseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentContract.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("سند به ثبت نهایی رسیده است");
                return;
            }
            FileDataObject d = FilingManager.GetFileDataObject(); // check if the file is empty or the selected item is nulland return
            if (d == null)
                return;
            var f = new PaymentFile()
            {
                Index = 1,
                Name = d.FileName,
                FileContent = d.FileContent,
                AttachedDate = DateTime.Now,
                FileGuid = Guid.NewGuid(),
                PaymentDraftId = (dataGrid.SelectedItem as PaymentDraft).PaymentDraftId
            };
            DataManagement.AddPaymentDraftFile(f);
            ErrorHandler.NotifyUser("فایل ثبت شد");

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentContract.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("سند به ثبت نهایی رسیده است");
                return;
            }
            FileDataObject d = FilingManager.GetFileDataObject(); // check if the file is empty or the selected item is nulland return
            if (d == null)
                return;
            var f = new PaymentFile()
            {
                Index = 2,
                Name = d.FileName,
                FileContent = d.FileContent,
                AttachedDate = DateTime.Now,
                FileGuid = Guid.NewGuid(),
                PaymentDraftId = (dataGrid.SelectedItem as PaymentDraft).PaymentDraftId
            };
            DataManagement.AddPaymentDraftFile(f);
            ErrorHandler.NotifyUser("فایل ثبت شد");
        }


        private void ViewPre_Click(object sender, RoutedEventArgs e)
        {
            BusyIndicator busy = new BusyIndicator();
            var x = dataGrid.SelectedItem as PaymentDraft;
            layoutRoot.Children.Add(busy);
            Task.Factory.StartNew(delegate
            {
                try
                {
                    FileDataObject temp = DataManagement.RetrievePaymentDraftFile(x.PaymentDraftId, 1);
                    OpenFileHandler.OpenFileFromByte(temp.FileContent, temp.FileName);
                    temp = null;
                }
                catch (System.Exception ex)
                {
                    ErrorHandler.ShowErrorMessage(Errors.NoFile);
                }
            }).ContinueWith(delegate
            {
                this.layoutRoot.Children.Remove(busy);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void ViewEnd_Click(object sender, RoutedEventArgs e)
        {
            BusyIndicator busy = new BusyIndicator();
            var x = dataGrid.SelectedItem as PaymentDraft;
            layoutRoot.Children.Add(busy);
            Task.Factory.StartNew(delegate
            {
                try
                {
                    FileDataObject temp = DataManagement.RetrievePaymentDraftFile(x.PaymentDraftId, 2);
                    OpenFileHandler.OpenFileFromByte(temp.FileContent, temp.FileName);
                    temp = null;

                }
                catch (System.Exception ex)
                {
                    ErrorHandler.ShowErrorMessage(Errors.NoFile);
                }
            }).ContinueWith(delegate
            {
                this.layoutRoot.Children.Remove(busy);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentContract.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("سند به ثبت نهایی رسیده است");
                return;
            }
            if (dataGrid.SelectedIndex == -1)
            {
                ErrorHandler.ShowErrorMessage(Errors.NotSelected);
                return;
            }
            NavigationHandler.NavigateToPage(this, new NewPaymentTransfer(dataGrid.SelectedItem as PaymentDraft));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CurrentContract.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("سند به ثبت نهایی رسیده است");
                return;
            }
            if (UserData.CurrentUser.PaymentDraftCommittee==false)
            {
                ErrorHandler.NotifyUser(Errors.OperationNotAllowed);
                return;
            }
            var t = dataGrid.SelectedItem as PaymentDraft;
            if (t.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("این سند قبلا به تایید نهایی رسیده است");
                return;
            }
            if (ErrorHandler.PromptUserForPermision("ثبت نهایی صورت گیرد ؟") == MessageBoxResult.No)
                return;
            t.PermanentRecord = true;
            ErrorHandler.NotifyUser("سند به تایید نهایی رسید");
            DataManagement.UpdatePaymentDrafts(t);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedIndex == -1 || dataGrid.ItemsSource == null)
            {
                ErrorHandler.NotifyUser(Errors.NotSelected);
                return;
            }
            var x = dataGrid.SelectedItem as PaymentDraft;
            NavigationHandler.NavigateToPage(this, new RTM.Report.Havale.Havale_Viewer(CurrentContract,x,true));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedIndex == -1 || dataGrid.ItemsSource == null)
            {
                ErrorHandler.NotifyUser(Errors.NotSelected);
                return;
            }
            var x = dataGrid.SelectedItem as PaymentDraft;
            NavigationHandler.NavigateToPage(this,new RTM.Report.Havale.Havale_Viewer(CurrentContract, x,false));
        }
    }
}

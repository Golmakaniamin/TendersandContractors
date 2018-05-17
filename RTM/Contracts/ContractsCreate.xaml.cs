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
    /// Interaction logic for ContractsCreate1.xaml
    /// </summary>
    public partial class ContractsCreate : Page
    {
        public Contract CurrentContract = new Contract();


        private List<ContractFile> percentList = new List<ContractFile>();
        private List<ContractFile> otherList = new List<ContractFile>();
        private BusyIndicator busy = new BusyIndicator();
        public ContractsCreate()
        {
            CurrentContract = new Contract() { IsTendering = false };
            InitializeComponent();
        }
        public ContractsCreate(Contract c)
        {
            CurrentContract = c;

            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (comboBox2.ItemsSource == null)
                comboBox2.ItemsSource = DataManagement.SearchContractors(null, null, null, null, null).OrderBy(s=>s.CompanyName);
            if (PartnerCom.ItemsSource == null)
                PartnerCom.ItemsSource = DataManagement.SearchContractors(null, null, null, null, null).OrderBy(s => s.CompanyName);
            if (SupervisionUnitCom.ItemsSource == null)
                SupervisionUnitCom.ItemsSource = DataManagement.RetrieveOrganizationChart();
            if (SupervisionSystemCom.ItemsSource == null)
                SupervisionSystemCom.ItemsSource = DataManagement.RetrieveOrganizationChart();
            if (Eng1Com.ItemsSource == null)
                Eng1Com.ItemsSource = DataManagement.SearchUsers(null, null, null, null).OrderBy(s => s.Family);
            if (Eng2Com.ItemsSource == null)
                Eng2Com.ItemsSource = DataManagement.SearchUsers(null, null, null, null).OrderBy(s => s.Family);
            if (TypeCom.ItemsSource == null)
                TypeCom.ItemsSource = DataManagement.RetrieveContractType();

            dataGrid.ItemsSource = DataManagement.RetrieveContractFiles(CurrentContract.Contractid, ContractIndex._25Percent);
            dataGrid1.ItemsSource = DataManagement.RetrieveContractFiles(CurrentContract.Contractid, ContractIndex.ComplementOrExtend);
            this.DataContext = CurrentContract;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
                return;
            DataManagement.CreateContract(CurrentContract);
            ErrorHandler.NotifyUser("ثبت با موفقیت انجام شد");
            SaveBtn.IsEnabled = false;
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LocationCom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (UserData.CurrentUser.PaymentDraftCommittee == false)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
                
            if (EditBtn.IsEnabled == false)
            {
                ErrorHandler.NotifyUser("سند تا کنون به ثبت نرسیده است");
                return;
            }
            else if (CurrentContract.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("سند قبلا به ثبت نهایی رسیده است");
                return;
            }
            else
            {
                if (Validate())
                    return;
                CurrentContract.PermanentRecord = true;
                DataManagement.UpdateContract(CurrentContract);
                ErrorHandler.NotifyUser("سند به ثبت نهایی رسید");
            }
        }

        private void DocsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EditBtn.IsEnabled == false && SaveBtn.IsEnabled == true)
            {
                ErrorHandler.NotifyUser("برای دسترسی پس از تکمیل سند و ثبت آن از طریق جستجو وارد شوید");
                return;
            }
            NavigationHandler.NavigateToPage(this, new ContractDocuments(CurrentContract), true);
        }

        private void DraftsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EditBtn.IsEnabled == false)
            {
                ErrorHandler.NotifyUser("برای دسترسی پس از تکمیل سند و ثبت آن از طریق جستجو وارد شوید");
                return;
            }
                NavigationHandler.NavigateToPage(this, new TransfersManagement(CurrentContract), true);
        }



        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TenderCheck_Checked(object sender, RoutedEventArgs e)
        {
            TenderNumberTxt.IsEnabled = false;
            TenderNumberTxt.Text = "";
            CurrentContract.TenderingSystemCode = null;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentContract.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("سند به ثبت نهایی رسیده است");
                return;
            }
            if (Validate())
                return;
            DataManagement.UpdateContract(CurrentContract);
            ErrorHandler.NotifyUser("ثبت با موفقیت انجام شد");
        }

        private void BrowseBtn2_Click(object sender, RoutedEventArgs e)
        {
            if (EditBtn.IsEnabled == false)
            {
                ErrorHandler.NotifyUser("برای بارگذاری فایل  پس از تکمیل سند و ثبت آن از طریق جستجو وارد شوید");
                return;
            }
            if (dataGrid.SelectedIndex == -1)
                return;
            if ((dataGrid.SelectedItem as ContractFile).FileId > 0)
                return;
            if (CurrentContract.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("سند به ثبت نهایی رسیده است");
                return;
            }
            FileDataObject temp = FilingManager.GetFileDataObject();
            if (temp == null)
                return;
            ContractFile t = dataGrid.SelectedItem as ContractFile;
            t.FileContent = temp.FileContent;
            t.Name = temp.FileName;
            t.AttachedDate = DateTime.Now;
            t.Is25Percent = true;
            DataManagement.AddContractFile(CurrentContract.Contractid, ContractIndex._25Percent, t);

        }

        private void BrowseBtn1_Click(object sender, RoutedEventArgs e)
        {
            if (EditBtn.IsEnabled == false)
            {
                ErrorHandler.NotifyUser("برای بارگذاری فایل  پس از تکمیل سند و ثبت آن از طریق جستجو وارد شوید");
                return;
            }
            if (dataGrid1.SelectedIndex == -1)
                return;
            if ((dataGrid1.SelectedItem as ContractFile).FileId > 0)
                return;
            if (CurrentContract.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("سند به ثبت نهایی رسیده است");
                return;
            }
            FileDataObject temp = FilingManager.GetFileDataObject();
            if (temp == null)
                return;
            ContractFile t = dataGrid1.SelectedItem as ContractFile;
            t.FileContent = temp.FileContent;
            t.Name = temp.FileName;
            t.AttachedDate = DateTime.Now;
            DataManagement.AddContractFile(CurrentContract.Contractid, ContractIndex.ComplementOrExtend, t);
            ErrorHandler.NotifyUser(Errors.Saved);
        }
        private void ViewFile(object sender, RoutedEventArgs e)
        {
            var x = dataGrid.SelectedItem as ContractFile;
            layoutRoot.Children.Add(busy);
            Task.Factory.StartNew(delegate
            {
                try
                {
                    OpenFileHandler.OpenFileFromByte(DataManagement.RetrieveContractFile(x), x.Name);
                }
                catch (System.Exception ex)
                {
                    ErrorHandler.ShowErrorMessage("در حال حاضر امکان دسترسی به این فایل وجود ندارد");
                }
            }).ContinueWith(delegate
            {
                this.layoutRoot.Children.Remove(busy);
            }, TaskScheduler.FromCurrentSynchronizationContext());


        }
        private void ViewFile1(object sender, RoutedEventArgs e)
        {
            var x = dataGrid1.SelectedItem as ContractFile;
            layoutRoot.Children.Add(busy);
            Task.Factory.StartNew(delegate
            {
                try
                {
                    OpenFileHandler.OpenFileFromByte(DataManagement.RetrieveContractFile(x), x.Name);
                }
                catch (System.Exception ex)
                {
                    ErrorHandler.ShowErrorMessage("در حال حاضر امکان دسترسی به این فایل وجود ندارد");
                }
            }).ContinueWith(delegate
            {
                this.layoutRoot.Children.Remove(busy);
            }, TaskScheduler.FromCurrentSynchronizationContext());


        }
        private void DeleteFile1(object sender, RoutedEventArgs e)
        {
            //if (DeleteBtn.IsEnabled == false)
            //{
            //    ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
            //}
            if (UserData.CurrentAccessRight.ContractDelete != true)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            else if (ErrorHandler.PromptUserForPermision("این فایل حذف شود ؟") == MessageBoxResult.Yes)
            {
                var x = dataGrid1.SelectedItem as ContractFile;
                Task.Factory.StartNew(delegate
                {
                    DataManagement.DeleteContractFile(x.FileId);
                }).ContinueWith(delegate
                {
                    otherList = DataManagement.RetrieveContractFiles(CurrentContract.Contractid, ContractIndex.ComplementOrExtend);
                    dataGrid1.ItemsSource = otherList;
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }
        private void DeleteFile(object sender, RoutedEventArgs e)
        {
            //if (DeleteBtn.IsEnabled == false)
            //{
            //    ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
            //}
            if (UserData.CurrentAccessRight.ContractDelete != true)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            else if (ErrorHandler.PromptUserForPermision("این فایل حذف شود ؟") == MessageBoxResult.Yes)
            {
                var x = dataGrid.SelectedItem as ContractFile;
                Task.Factory.StartNew(delegate
                {
                    DataManagement.DeleteContractFile(x.FileId);
                }).ContinueWith(delegate
                {
                    percentList = DataManagement.RetrieveContractFiles(CurrentContract.Contractid, ContractIndex._25Percent);
                    dataGrid.ItemsSource = percentList;
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }


        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }




        private void TenderNumberTxt_LostFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var t = UniqueConstraints.ExistTenderingNumber(TenderNumberTxt.Text, CurrentContract);
            if (t == null)
            {
                ErrorHandler.ShowErrorMessage(Errors.NotFoundTendering);
                CurrentContract.TenderingSystemCode = "";
            }
            else
            {
                ErrorHandler.NotifyUser(Errors.FoundTendering);
                CurrentContract.ContractTtile = t.TenderingTitle;
                var c = DataManagement.RetrieveTenderingContractorRequest(t);
                CurrentContract.SupervisingUnit = c.RequestingUnit;
                CurrentContract.SupervisingUnitHigher = c.SupervisionId;
                try
                {
                    var res = DataManagement.SearchOrCreateTenderingResult(t);
                    CurrentContract.ContractorId = res.FirstContractorWinnerId;
                    CurrentContract.ContractBudget = (from items in DataManagement.RetrieveBids(t) where items.ContractorId == CurrentContract.ContractorId select items).FirstOrDefault().Bid1;

                }
                catch (System.Exception ex)
                {

                }
            }
        }

        private void CNumberTxt_LostFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (UniqueConstraints.ValidContractNumber(CNumberTxt.Text, CurrentContract) == false)
            {
                ErrorHandler.ShowErrorMessage(Errors.InvalidNumber);
                CurrentContract.ContractNumber = "";
                //CNumberTxt.Focus();
            }
        }

        private void TenderCheck_Checked_1(object sender, RoutedEventArgs e)
        {
            TenderNumberTxt.IsEnabled = true;
        }


        public bool Validate()
        {
            if (TenderCheck.IsChecked == true && TenderNumberTxt.Text == "") { l0.Foreground = new SolidColorBrush(Colors.Red); } else { l0.Foreground = new SolidColorBrush(Colors.Black); }
            if (CNumberTxt.Text == "") { l1.Foreground = new SolidColorBrush(Colors.Red); } else { l1.Foreground = new SolidColorBrush(Colors.Black); }
            if (TitleTxt.Text == "") { l2.Foreground = new SolidColorBrush(Colors.Red); } else { l2.Foreground = new SolidColorBrush(Colors.Black); }
            if (datePicker2.Text == "") { l3.Foreground = new SolidColorBrush(Colors.Red); } else { l3.Foreground = new SolidColorBrush(Colors.Black); }
            if (PeymanNumberTxt.Text == "") { l4.Foreground = new SolidColorBrush(Colors.Red); } else { l4.Foreground = new SolidColorBrush(Colors.Black); }
            if (PriceTxt.Text == "") { l5.Foreground = new SolidColorBrush(Colors.Red); } else { l5.Foreground = new SolidColorBrush(Colors.Black); }
            if (datePicker4.Text == "") { l6.Foreground = new SolidColorBrush(Colors.Red); } else { l6.Foreground = new SolidColorBrush(Colors.Black); }
            if (datePicker3.Text == "") { l7.Foreground = new SolidColorBrush(Colors.Red); } else { l7.Foreground = new SolidColorBrush(Colors.Black); }
            if (textBox9.Text == "") { l8.Foreground = new SolidColorBrush(Colors.Red); } else { l8.Foreground = new SolidColorBrush(Colors.Black); }
            if (CNumberTxt.Text == "" || TitleTxt.Text == "" || datePicker2.Text == "" || PeymanNumberTxt.Text == "" || PriceTxt.Text == "" || datePicker4.Text == "" || datePicker3.Text == "" || textBox9.Text == "" || TenderCheck.IsChecked == true && TenderNumberTxt.Text == "")
            {
                ErrorHandler.NotifyUser("مشکل در اطلاعات وارد شده");
                return true;
            }
            if (datePicker2.SelectedDate > datePicker4.SelectedDate)
            {
                ErrorHandler.NotifyUser(Errors.DatesMismatch);
                return true;
            }
            return false;
        }

        private void PriceTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PriceTxt_KeyDown(object sender, KeyEventArgs e)
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

        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Delete:
                    comboBox2.Text = string.Empty;
                    break;
            }
        }

        private void TypeCom_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Delete:
                    TypeCom.Text = string.Empty;
                    break;
            }
        }

        private void LocationCom_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Delete:
                    LocationCom.Text = string.Empty;
                    break;
            }
        }

        private void SupervisionUnitCom_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Delete:
                    SupervisionUnitCom.Text = string.Empty;
                    break;
            }
        }

        private void SupervisionSystemCom_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Delete:
                    SupervisionSystemCom.Text = string.Empty;
                    break;
            }
        }

        private void Eng1Com_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Delete:
                    Eng1Com.Text = string.Empty;
                    break;
            }
        }

        private void Eng2Com_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Delete:
                    Eng2Com.Text = string.Empty;
                    break;
            }
        }

        private void PartnerCom_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Delete:
                    PartnerCom.Text = string.Empty;
                    break;
            }
        }
    }
}

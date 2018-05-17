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
using System.ComponentModel;
using System.Threading.Tasks;

namespace RTM.UserManagement
{
    /// <summary>
    /// Interaction logic for Contractors.xaml
    /// </summary>
    public partial class Contractors : Page
    {
        public BackgroundWorker bw = new BackgroundWorker();
        public Contractors()
        {

            InitializeComponent();

        }
        BusyIndicator busy = new BusyIndicator();
        public Contractor CurrentCont = new Contractor();
        private List<ContractorFile> fileList = new List<ContractorFile>();
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            fileList = DataManagement.RetrieveContractorFile(CurrentCont.ContractorId, (int)DocType.SelectedValue);
            dataGrid.ItemsSource = fileList;
            try
            {
                this.layoutRoot.Children.Remove(busy);
            }
            catch (System.Exception ex)
            {

            }
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            int fileId = 0;
            try
            {
                //////////////////////////////////////////////////////////////////////////
                dynamic o = e.Argument;
                int documentId = (int)o.documentId;
                int contractorId = (int)o.contractorId;
                string version = (string)o.version;
                if (contractorId <= 0)
                {
                    ErrorHandler.ShowErrorMessage("ابتدا اطلاعات پيمانکار را ثبت کنيد");
                    return; // error has occured contractor should be submited before commiting chnages
                }
                //////////////////////////////////////////////////////////////////////////
                string fileLocation = OpenFileHandler.OpenFileToUpload();
                byte[] fileContent = OpenFileHandler.GetFileFromLocation(fileLocation);
                string fileName = System.IO.Path.GetFileName(fileLocation);
                fileId = DataManagement.AddContractorFile(fileName, version, contractorId, documentId, fileContent);
                fileContent = null;
                GC.Collect();
                
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("ثبت فایل با موفقیت انجام نشد لطفا دوباره سعی کنید!");
            }
        }

        
        public Contractors(Contractor x)
        {
            InitializeComponent();
            CurrentCont = x;
            LoadCurrentContractor();
        }

        private void LoadCurrentContractor()
        {
            CoName.Text = CurrentCont.CompanyName;
            CommercialName.Text = CurrentCont.CommercialName;
            RegNumTxt.Text = CurrentCont.RecordNumber;
            CompanyType.Text = CurrentCont.CompanyType;
            CoPhoneTxt.Text = CurrentCont.Telephone;
            PostCodetxt.Text = CurrentCont.PostalCode;
            FaxTxt.Text = CurrentCont.Fax;
            StateTxt.Text = CurrentCont.Province;
            CityTxt.Text = CurrentCont.City;
            AddressTxt.Text = CurrentCont.Address;
            NationalId.Text = CurrentCont.NationalIdNumber;
            FNameTxt.Text = CurrentCont.CeoName;
            LNamrTxt.Text = CurrentCont.CeoFamily;
            CellTxt.Text = CurrentCont.CeoMobilePhone;
            EmailTxt.Text = CurrentCont.CeoEmailAddress;
            PhoneTxt.Text = CurrentCont.CeoTelephone;
            ContTick.IsChecked = CurrentCont.IsContractor;
            ConsTick.IsChecked = CurrentCont.IsConsultant;
            TypeTick1.IsChecked = CurrentCont.Design;
            TypeTick2.IsChecked = CurrentCont.BuildAndOperation;
            TypeTick3.IsChecked = CurrentCont.Procurement;
            TypeTick4.IsChecked = CurrentCont.Finance;
            Reshte1.Text = CurrentCont.CompanyField1;
            Reshte2.Text = CurrentCont.CompanyField2;
            Base1.Text = CurrentCont.CompanyBase1.ToString();
            Base2.Text = CurrentCont.CompanyBase2.ToString();
            TaxTxt.Text = CurrentCont.TaxNumber;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CoName.Text == "") { l1.Foreground = new SolidColorBrush(Colors.Red); } else { l1.Foreground = new SolidColorBrush(Colors.Black); }
            if (NationalId.Text == "") { l2.Foreground = new SolidColorBrush(Colors.Red); } else { l2.Foreground = new SolidColorBrush(Colors.Black); }
            if (RegNumTxt.Text == "") { l3.Foreground = new SolidColorBrush(Colors.Red); } else { l3.Foreground = new SolidColorBrush(Colors.Black); }
            if (CompanyType.SelectedIndex == -1) { l4.Foreground = new SolidColorBrush(Colors.Red); } else { l4.Foreground = new SolidColorBrush(Colors.Black); }
            if (AddressTxt.Text == "") { l5.Foreground = new SolidColorBrush(Colors.Red); } else { l5.Foreground = new SolidColorBrush(Colors.Black); }
            if (EmailTxt.Text == "") { l6.Foreground = new SolidColorBrush(Colors.Red); } else { l6.Foreground = new SolidColorBrush(Colors.Black); }
            if (FaxTxt.Text == "") { l7.Foreground = new SolidColorBrush(Colors.Red); } else { l7.Foreground = new SolidColorBrush(Colors.Black); }
            if (CoPhoneTxt.Text == "") { l8.Foreground = new SolidColorBrush(Colors.Red); } else { l8.Foreground = new SolidColorBrush(Colors.Black); }
            if (FNameTxt.Text == "") { l9.Foreground = new SolidColorBrush(Colors.Red); } else { l9.Foreground = new SolidColorBrush(Colors.Black); }
            if (LNamrTxt.Text == "") { l10.Foreground = new SolidColorBrush(Colors.Red); } else { l10.Foreground = new SolidColorBrush(Colors.Black); }
            if (ContTick.IsChecked == false && ConsTick.IsChecked == false) { l11.Foreground = new SolidColorBrush(Colors.Red);} else { l11.Foreground = new SolidColorBrush(Colors.Black);}
            if (TypeTick1.IsChecked == false && TypeTick2.IsChecked == false && TypeTick3.IsChecked == false && TypeTick4.IsChecked == false) { l12.Foreground = new SolidColorBrush(Colors.Red); } else { l12.Foreground = new SolidColorBrush(Colors.Black); }
            if (AddressTxt.Text == "" || NationalId.Text == "" || FaxTxt.Text == "" || EmailTxt.Text == "" || CoName.Text == "" || CompanyType.SelectedIndex == -1 || CoPhoneTxt.Text == "" || FNameTxt.Text == "" || LNamrTxt.Text == "" || RegNumTxt.Text == "" || (ContTick.IsChecked == false && ConsTick.IsChecked == false) || TypeTick1.IsChecked == false && TypeTick2.IsChecked == false && TypeTick3.IsChecked == false)
            {
                ErrorHandler.NotifyUser("برخی اطلاعات ضروری وارد نشده اند");
                return;
            }
            CurrentCont.ContractorId = DataManagement.CreateContractor(CoName.Text,CommercialName.Text, CompanyType.Text, StateTxt.Text, CityTxt.Text,
                    AddressTxt.Text, PostCodetxt.Text, null, CoPhoneTxt.Text, FaxTxt.Text, FNameTxt.Text, LNamrTxt.Text,
                    "social number", EmailTxt.Text, PhoneTxt.Text, CellTxt.Text, (bool)ContTick.IsChecked, (bool)ConsTick.IsChecked, (bool)TypeTick1.IsChecked,
                    (bool)TypeTick2.IsChecked, (bool)TypeTick3.IsChecked, Reshte1.Text, Reshte2.Text, Int32.Parse(Base1.Text), Int32.Parse(Base2.Text),
                    false, false, null, false, null, false, null,
                    false, null, false, null, null, RegNumTxt.Text, NationalId.Text, (bool)TypeTick1.IsChecked, (bool)TypeTick2.IsChecked, (bool)TypeTick3.IsChecked, false);
            if (CurrentCont.ContractorId != -1)
            {
                SaveBtn.IsEnabled = false;
                MessageBox.Show("ثبت شد");

            }
            else
            {
                MessageBox.Show("عملیات موفقیت آمیز نبود");
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CoName.Text == "") { l1.Foreground = new SolidColorBrush(Colors.Red); } else { l1.Foreground = new SolidColorBrush(Colors.Black); }
            if (NationalId.Text == "") { l2.Foreground = new SolidColorBrush(Colors.Red); } else { l2.Foreground = new SolidColorBrush(Colors.Black); }
            if (RegNumTxt.Text == "") { l3.Foreground = new SolidColorBrush(Colors.Red); } else { l3.Foreground = new SolidColorBrush(Colors.Black); }
            if (CompanyType.SelectedIndex == -1) { l4.Foreground = new SolidColorBrush(Colors.Red); } else { l4.Foreground = new SolidColorBrush(Colors.Black); }
            if (AddressTxt.Text == "") { l5.Foreground = new SolidColorBrush(Colors.Red); } else { l5.Foreground = new SolidColorBrush(Colors.Black); }
            if (EmailTxt.Text == "") { l6.Foreground = new SolidColorBrush(Colors.Red); } else { l6.Foreground = new SolidColorBrush(Colors.Black); }
            if (FaxTxt.Text == "") { l7.Foreground = new SolidColorBrush(Colors.Red); } else { l7.Foreground = new SolidColorBrush(Colors.Black); }
            if (CoPhoneTxt.Text == "") { l8.Foreground = new SolidColorBrush(Colors.Red); } else { l8.Foreground = new SolidColorBrush(Colors.Black); }
            if (FNameTxt.Text == "") { l9.Foreground = new SolidColorBrush(Colors.Red); } else { l9.Foreground = new SolidColorBrush(Colors.Black); }
            if (LNamrTxt.Text == "") { l10.Foreground = new SolidColorBrush(Colors.Red); } else { l10.Foreground = new SolidColorBrush(Colors.Black); }
            if (ContTick.IsChecked == false && ConsTick.IsChecked == false) { l11.Foreground = new SolidColorBrush(Colors.Red); } else { l11.Foreground = new SolidColorBrush(Colors.Black); }
            if (TypeTick1.IsChecked == false && TypeTick2.IsChecked == false && TypeTick3.IsChecked == false && TypeTick4.IsChecked == false) { l12.Foreground = new SolidColorBrush(Colors.Red); } else { l12.Foreground = new SolidColorBrush(Colors.Black); }
            if (AddressTxt.Text == "" || NationalId.Text == "" || FaxTxt.Text == "" || EmailTxt.Text == "" || CoName.Text == "" || CompanyType.SelectedIndex == -1 || CoPhoneTxt.Text == "" || FNameTxt.Text == "" || LNamrTxt.Text == "" || RegNumTxt.Text == "" || (ContTick.IsChecked == false && ConsTick.IsChecked == false) || TypeTick1.IsChecked == false && TypeTick2.IsChecked == false && TypeTick3.IsChecked == false)
            {
                ErrorHandler.NotifyUser("برخی اطلاعات ضروری وارد نشده اند");
                return;
            }
            
            int? x =null;
            int? y =null;
            try
            {
                x = Int32.Parse(Base1.Text);
            }
            catch (System.Exception ex)
            {
            	
            }
            try
            {
                y = Int32.Parse(Base2.Text);
            }
            catch (System.Exception ex)
            {
            	
            }
            DataManagement.EditContractor(CurrentCont.ContractorId, CoName.Text, CommercialName.Text, CompanyType.Text, StateTxt.Text, CityTxt.Text, AddressTxt.Text, PostCodetxt.Text, null, CoPhoneTxt.Text, FaxTxt.Text, FNameTxt.Text, LNamrTxt.Text, "social number", EmailTxt.Text, PhoneTxt.Text, CellTxt.Text, (bool)ContTick.IsChecked, (bool)ConsTick.IsChecked, (bool)TypeTick1.IsChecked, (bool)TypeTick2.IsChecked, (bool)TypeTick3.IsChecked, Reshte1.Text, Reshte2.Text,x ,y, false, true, null, false, null, false, null,
                    false, null, false, null, null, RegNumTxt.Text, NationalId.Text, (bool)TypeTick1.IsChecked, (bool)TypeTick2.IsChecked, (bool)TypeTick3.IsChecked, (bool)TypeTick4.IsChecked, false,TaxTxt.Text);
            ErrorHandler.NotifyUser("ویرایش انجام شد لطفا به صفحه قبل برگردید");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            DocType.ItemsSource = DataManagement.RetrieveContractorDocuments();

            var e2 = new RTMEntities();
            dataGrid.ItemsSource = fileList;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ErrorHandler.PromptUserForPermision("آیا این شرکت حذف شود ؟") == MessageBoxResult.Yes)
            {
                DataManagement.DeleteContractor(CurrentCont.ContractorId);
                ErrorHandler.NotifyUser("پیمانکار مورد نظر حذف شد لطفا به صفحه قبلی برگردید");
            }
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddFile(object sender, RoutedEventArgs e)
        {


        }

        private void ViewFile(object sender, RoutedEventArgs e)
        {
            var x = dataGrid.SelectedItem as ContractorFile;
            AddBusyIndicator();
            Task.Factory.StartNew(delegate
            {
                try
                {
                    OpenFileHandler.OpenFileFromByte(DataManagement.RetrieveContractorFile(x), x.Name);
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

        private void DocType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            fileList = DataManagement.RetrieveContractorFile(CurrentCont.ContractorId, (int)DocType.SelectedValue);
            dataGrid.ItemsSource = fileList;
        }

        private void AddBusyIndicator()
        {
            busy.SetValue(Grid.RowSpanProperty, 6);
            busy.SetValue(Grid.ColumnSpanProperty, 6);
            layoutRoot.Children.Add(busy);
        }
        private void BrowseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(VersionTxt.Text))
            {
                ErrorHandler.ShowErrorMessage("محتوای ورژن پر نشده است");
                return;
            }
            AddBusyIndicator();
            bw.RunWorkerAsync(new
            {
                documentId = (int)DocType.SelectedValue,
                contractorId = CurrentCont.ContractorId,
                version = VersionTxt.Text
            });
        }

        private void DeleteFile(object sender, RoutedEventArgs e)
        {
            if (DeleteBtn.IsEnabled == false)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
            }
            else if (UserData.CurrentAccessRight.TenderingDelete != true)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            else if (ErrorHandler.PromptUserForPermision("این فایل حذف شود ؟") == MessageBoxResult.Yes)
            {
                var x = dataGrid.SelectedItem as ContractorFile;
                Task.Factory.StartNew(delegate
                {
                    DataManagement.DeleteContractorFile(x.FileId);
                }).ContinueWith(delegate
                {
                    fileList = DataManagement.RetrieveContractorFile(CurrentCont.ContractorId, (int)DocType.SelectedValue);
                    dataGrid.ItemsSource = fileList;
                },TaskScheduler.FromCurrentSynchronizationContext());
            }
            

        }
    }
}

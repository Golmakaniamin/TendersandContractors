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

namespace RTM.Regulations
{
    /// <summary>
    /// Interaction logic for _ٔRegulationsPage1.xaml
    /// </summary>
    public partial class RegulationsPage1 : Page
    {
        public Regulation CurrentRegulation { set; get; }
        private BusyIndicator busy = new BusyIndicator();
        public RegulationsPage1()
        {
            CurrentRegulation = new Regulation();       
            InitializeComponent();
            //
            //datePicker1.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(datePicker1_SelectedDateChanged);
        }
        public RegulationsPage1(Regulation regulation)
        {
            CurrentRegulation = regulation;
            InitializeComponent();
            Grid.ItemsSource = DataManagement.RetrieveRegulationFile(CurrentRegulation.RegulationId);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ActingCom.ItemsSource = DataManagement.RetrieveOrganizationChart();
            ReferenceCom.ItemsSource = DataManagement.RetrieveIssuingReferences();
            if (CurrentRegulation.RegulationId == 0)
            {
                BrowseBtn.IsEnabled = false;
                VersionTxt.IsEnabled = false;
            }
        }

        void datePicker1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.Items.Count == 0)
            {
                ErrorHandler.NotifyUser("فایلی ثیت نشده است");
                return;
            }
            if (CurrentRegulation.PermanentRecord == false)
            {
                if (ErrorHandler.PromptUserForPermision("ثبت دائم صورت گیرد ؟") == MessageBoxResult.Yes)
                {
                    CurrentRegulation.PermanentRecord = true;
                    DataManagement.UpdateRegulation(CurrentRegulation);
                    ErrorHandler.NotifyUser("سند به ثبت نهایی رسید");
                }
            }
            else
            {
                ErrorHandler.NotifyUser("سند قبلا به ثبت نهایی رسیده است ");
            }
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            var x = Grid.SelectedItem as RegulationFile;
            this.layoutRoot.Children.Add(busy);
            Task.Factory.StartNew(delegate
            {
                try
                {
                    OpenFileHandler.OpenFileFromByte(DataManagement.RetrieveRegulationFile(x), x.Name);
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

        private void BrowseBtn_Click(object sender, RoutedEventArgs e) //multi tasking required
        {
            if (CurrentRegulation.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("سند به ثبت نهایی رسیده است ");
                return;
            }
            if (VersionTxt.Text.Trim() == "")
            {
                ErrorHandler.ShowErrorMessage("ابتدا ورژن فایل را وارد کنید");
                return;
            }
            string fileLocation = OpenFileHandler.OpenFileToUpload();
            if (fileLocation == null)
            {
                ErrorHandler.NotifyUser("فایلی انتخاب نشد");
                return;
            }
            else
            {
                try
                {
                    layoutRoot.Children.Add(busy);
                    int a = CurrentRegulation.RegulationId;
                    string text = VersionTxt.Text;
                    Task.Factory.StartNew(delegate
                    {
                        byte[] fileContent = OpenFileHandler.GetFileFromLocation(fileLocation);
                        string fileName = System.IO.Path.GetFileName(fileLocation);
                        int fileId = DataManagement.AddRegulationFile(fileName, fileContent,text , a);
                        fileContent = null;
                        GC.Collect();
                        ErrorHandler.NotifyUser("فایل با موفقیت ثبت شد.");
                    }).ContinueWith(delegate
                    {
                        Grid.ItemsSource = DataManagement.RetrieveRegulationFile(CurrentRegulation.RegulationId);
                        layoutRoot.Children.Remove(busy);
                    },TaskScheduler.FromCurrentSynchronizationContext());
                }
                catch
                {
                    ErrorHandler.NotifyUser("ثبت فایل موفقیت آمیز نبود");
                }
            }

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TitleTxt.Text=="")
            {
                ErrorHandler.NotifyUser("عنوان وارد نشده است");
            }
            else if (datePicker1.Text=="")
            {
                ErrorHandler.NotifyUser("تاریخ صدور وارد نشده است ");
            }
            else
            {
                try
                {
                    DataManagement.CreateRegulation(CurrentRegulation);
                    SaveBtn.IsEnabled = false;
                    BrowseBtn.IsEnabled = true;
                    VersionTxt.IsEnabled = true;
                    ErrorHandler.NotifyUser("ثبت با موفقیت انجام شد، پس از ضمیمه کردن فایل ها به صفحه ی قبل برگردید");
                }
                catch
                {
                    ErrorHandler.NotifyUser("ثبت موفقیت آمیز نبود، دوباره سعی کنید");
                }
            }
        }

       

        private void DeleteFile_Click(object sender, RoutedEventArgs e)
        {
            if (TypeCom.IsEnabled == false)
                return;
            if (UserData.CurrentAccessRight.RegulationDelete != true)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            else if (CurrentRegulation.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("سند به ثبت نهایی رسیده است ");
                return;
            }
            else if (ErrorHandler.PromptUserForPermision("این فایل حذف شود ؟") == MessageBoxResult.Yes)
            {
                var x = Grid.SelectedItem as RegulationFile;
                Task.Factory.StartNew(delegate
                {
                    DataManagement.DeleteRegulationFile(x.FileId);

                }).ContinueWith(delegate
                {
                    Grid.ItemsSource = DataManagement.RetrieveRegulationFile(CurrentRegulation.RegulationId);
                },TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentRegulation.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("این سند به تایید نهایی رسیده است");
                return;
            }
            if (TitleTxt.Text == "")
            {
                ErrorHandler.NotifyUser("عنوان وارد نشده است");
                return;
            }
            else if (datePicker1.Text == "")
            {
                ErrorHandler.NotifyUser("تاریخ صدور وارد نشده است ");
                return;
            } 
            try
            {
                DataManagement.UpdateRegulation(CurrentRegulation);
                ErrorHandler.NotifyUser("ویرایش موفقیت آمیز بود");
            }
            catch
            {
                ErrorHandler.NotifyUser("ویرایش انجام نشد");
            }
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}

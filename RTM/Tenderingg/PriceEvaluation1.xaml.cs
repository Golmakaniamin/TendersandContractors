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
namespace RTM.Tenderingg
{
    /// <summary>
    /// Interaction logic for PriceEvaluation1.xaml
    /// </summary>
    public partial class PriceEvaluation1 : Page
    {
        public Tendering CurrentTender { set; get; }
        private BusyIndicator busy = new BusyIndicator();
        public Evaluation CurrentEvaluation = null;
        public PriceEvaluation1(Evaluation e)
        {
            CurrentEvaluation = e;
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DescTxt.Text=="") { l1.Foreground = new SolidColorBrush(Colors.Red); } else { l1.Foreground = new SolidColorBrush(Colors.Black); }
            if (DescTxt.Text == "")
            {
                ErrorHandler.NotifyUser("برخی اطلاعات ضروری وارد نشده اند");
                return;
            }

            try
            {
                DataManagement.UpdateEvaluation(CurrentEvaluation);
                ErrorHandler.NotifyUser("ثبت موفقیت آمیز بود");
            }
            catch
            {
                ErrorHandler.NotifyUser("ثبت با شکست مواجه شد");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var t = DataManagement.SearchTenderings("", "", CurrentEvaluation.TenderingNumber, "", "").FirstOrDefault();
            CurrentTender = t;
            dataGrid.ItemsSource = DataManagement.RetrieveBids(t);
            Header.CurrentRequest = DataManagement.RetrieveTenderingContractorRequest(t);
            this.DataContext = CurrentEvaluation;
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UserData.CurrentAccessRight.TenderingPermanentWrite == false)
            {
                ErrorHandler.NotifyUser("عملیات امکان پذیر نمی باشد.");
                return;
            }

            if (CurrentEvaluation.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("اين سند قبلا به تأييد نهايي رسيده است.");
                return;
            }
            
            if (ErrorHandler.PromptUserForPermision("ثبت دائم صورت گیرد ؟") == MessageBoxResult.Yes)
            {

                CurrentEvaluation.PermanentRecord = true;
                DataManagement.UpdateEvaluation(CurrentEvaluation);
            }
            else
            {
                ErrorHandler.ShowErrorMessage("عمليات با موفقيت انجام نشد.");
            }
        }
        private void AddBusyIndicator()
        {
            layoutRoot.Children.Add(busy);
        }
        private void AddFile_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentEvaluation.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("اين سند به تأييد نهايي رسيده است.");
                return;
            }
            AddBusyIndicator();
            string fileName = "";
            Task.Factory.StartNew(delegate
            {
                string fileLocation = OpenFileHandler.OpenFileToUpload();

                byte[] fileContent = OpenFileHandler.GetFileFromLocation(fileLocation);
                fileName = System.IO.Path.GetFileName(fileLocation);
                //fileName = OpenFileHandler.UploadFileToServer(String.Format(@"Evaluations\{0}\", currentEval), "اضافه کردن فایل صورت جلسه");
                if (fileName != "")
                    if (DataManagement.AddEvaluationFile(fileName, fileContent, CurrentEvaluation.EvaluationId) != -1)
                    {
                        ErrorHandler.NotifyUser("ثبت با موفقیت انجام شد");
                        
                    }
                    else
                        ErrorHandler.ShowErrorMessage("در حال حاضر امکان ثبت فایل وجود ندارد.");
            }).ContinueWith(delegate
            {
                this.layoutRoot.Children.Remove(busy);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void OpenFileBtn_Click(object sender, RoutedEventArgs e)
        {
            var x = DataManagement.HasEvaluationFileLocation(CurrentEvaluation.EvaluationId);
            if (x == null)
            {
                ErrorHandler.NotifyUser("فایل پیوست ندارد");
                return;
            }
            AddBusyIndicator();
            Task.Factory.StartNew(delegate
            {
                try
                {
                    OpenFileHandler.OpenFileFromByte(DataManagement.RetrieveEvaluationFile(CurrentEvaluation.EvaluationId), x);
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

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentEvaluation.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("اين سند به تأييد نهايي رسيده است.");
                return;
            }
            var x = DataManagement.HasEvaluationFileLocation(CurrentEvaluation.EvaluationId);
            if (x == null)
            {
                ErrorHandler.NotifyUser("فایل پیوست ندارد");
                return;
            }
            if (ErrorHandler.PromptUserForPermision("این فایل حذف شود ؟") == MessageBoxResult.No)
            {
                return;
            }
            AddBusyIndicator();
            Task.Factory.StartNew(delegate
            {
                try
                {
                    DataManagement.DeleteEvaluationFile(CurrentEvaluation.EvaluationId);
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

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentEvaluation.Description==null || CurrentEvaluation.Description.Trim() == "")
            {
                ErrorHandler.NotifyUser("شرحی برای جلسه ثبت نشده است");
                return;
            }
            else
                NavigationHandler.NavigateToPage(this,new RTM.Report.PriceEvalReport.PriceEval_Viewer(CurrentTender,CurrentEvaluation));
        }
    }
}

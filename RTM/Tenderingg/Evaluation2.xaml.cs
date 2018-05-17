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
    /// Interaction logic for Evaluation2.xaml
    /// </summary>
    public partial class Evaluation2 : Page
    {
        public int Mode = 0;
        private int contractorId = 0;
        public Evaluation currentEval = null;
        private List<EvalStandardScore> standardList = new List<EvalStandardScore>();
        private List<ContractorWithTotalScore> contractorList = new List<ContractorWithTotalScore>();
        private BusyIndicator busy = new BusyIndicator();
        private bool HasAddedDocument = false;

        //private List<EvalStandardScore> defaultStandardList = new List<EvalStandardScore>();
        public Evaluation2()
        {
            InitializeComponent();
        }
        public Evaluation2(int mode, Evaluation currentEval)
        {
            InitializeComponent();
            Mode = mode;
            this.currentEval = currentEval;
            if (DataManagement.HasEvaluationFileLocation(currentEval.EvaluationId)!=null)
            {
                HasFile.Content = "فایل ثبت شده دارد";
                HasAddedDocument = true;
            }
            LoadPage();
        }
        private void LoadPage()
        {
            contractorList = DataManagement.RetrieveEvaluationContractorsWithScoreSum(currentEval.EvaluationId).OrderByDescending(s => s.totalScore).ToList(); ;
            Grid.ItemsSource = contractorList;
        }




        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Grid.ItemsSource == null || Grid.SelectedIndex == -1)
                return;
            contractorId = (Grid.SelectedItem as ContractorWithTotalScore).contractor.ContractorId;
            if (standardList.Count > 0 && (Grid.SelectedItem as ContractorWithTotalScore).totalScore == null)
            {
                standardList = (
                               from items in standardList
                               select new EvalStandardScore
                               {
                                   Title = items.Title,
                                   Score = 0,
                                   StandardId = items.StandardId,
                                   Weight = items.Weight

                               }).ToList();

            }
            else
            {
                standardList = DataManagement.RetrieveEvalStandarsDataGrid(contractorId, currentEval.EvaluationId, (Mode == 1) ? true : false, (Mode == 2) ? true : false);
            }

            dataGrid1.ItemsSource = standardList;
        }



        private void UpdateContractorTotalScore()
        {
            var x = Grid.SelectedItem as ContractorWithTotalScore;
            if (x == null)
            {
                dataGrid1.ItemsSource = null;
                ErrorHandler.ShowErrorMessage("یک شرکت را انتخاب کنید");
                return;
            }
            x.totalScore = DataManagement.RetrieveContractorUpdatedScore(x.contractor.ContractorId, currentEval.EvaluationId);
            Grid.ItemsSource = null;
            contractorList = contractorList.OrderByDescending(s => s.totalScore).ToList();
            Grid.ItemsSource = contractorList;
            Grid.SelectedItem = x;
        }

        private bool CheckScoresValidity()
        {
            int weights = 0;
            foreach (var item in standardList)
            {
                if (item.Score > 100)
                    return false;
                weights += item.Weight;
            }
            if (weights != 100)
                return false;
            return true;
        }

        private void AddFile_Click(object sender, RoutedEventArgs e)
        {
            if (currentEval.PermanentRecord == true)
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
                    if (DataManagement.AddEvaluationFile(fileName, fileContent, currentEval.EvaluationId) != -1)
                    {
                        ErrorHandler.NotifyUser("ثبت با موفقیت انجام شد");
                        HasAddedDocument = true;
                    }
                    else
                        ErrorHandler.ShowErrorMessage("در حال حاضر امکان ثبت فایل وجود ندارد.");
            }).ContinueWith(delegate
            {
                this.layoutRoot.Children.Remove(busy);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void AddBusyIndicator()
        {
            layoutRoot.Children.Add(busy);
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var x = DataManagement.HasEvaluationFileLocation(currentEval.EvaluationId);
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
                    OpenFileHandler.OpenFileFromByte(DataManagement.RetrieveEvaluationFile(currentEval.EvaluationId),x);
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
            if (currentEval.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("اين سند به تأييد نهايي رسيده است.");
                return;
            }
            var x = DataManagement.HasEvaluationFileLocation(currentEval.EvaluationId);
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
                    DataManagement.DeleteEvaluationFile(currentEval.EvaluationId);
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

        private void EditBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (currentEval.PermanentRecord == true && UserData.CurrentAccessRight.SysAdmin == false)
            {
                ErrorHandler.NotifyUser("این سند قبلا ثبت نهایی شده است");
                return;
            }
            if (MinTxt.Text == "")
            {
                ErrorHandler.NotifyUser("حداقل امتیاز وارد نشده است");
                return;
            }

            if (CheckScoresValidity())
            {
                DataManagement.SubmitEvaluationScoreWeight(standardList, currentEval.EvaluationId, contractorId);
                UpdateContractorTotalScore();
                DataManagement.EditEvaluationForm(currentEval.EvaluationId, RecordDescriptionTxt.Text);
                ErrorHandler.NotifyUser("ویرایش با موفقیت انجام شد");
            }
            else
            {
                ErrorHandler.ShowErrorMessage("امتیازها(یا) وزن های وارد شده صحیح نیستند");
            }
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UserData.CurrentAccessRight.TenderingPermanentWrite == false)
                ErrorHandler.NotifyUser("عملیات امکان پذیر نمی باشد.");
            else
            {
                try
                {
                    if (currentEval.PermanentRecord == true)
                    {
                        ErrorHandler.NotifyUser("اين سند قبلا به تأييد نهايي رسيده است.");
                        return;
                    }
                    if (MinTxt.Text == "")
                    {
                        ErrorHandler.NotifyUser("حداقل امتیاز وارد نشده است");
                        return;
                    }
                    if (HasAddedDocument == false)
                    {
                        ErrorHandler.NotifyUser("فایلی ضمیمه نشده است");
                        return;
                    }
                    if (ErrorHandler.PromptUserForPermision("ثبت دائم صورت گیرد ؟") == MessageBoxResult.Yes)
                    {
                        if (DataManagement.ConfirmEvaluation(currentEval.EvaluationId) == currentEval.EvaluationId)
                        {
                            currentEval.PermanentRecord = true;
                            ErrorHandler.NotifyUser("ثبت دائم با موفقيت انجام شد.");
                        }
                    }

                    else
                    {
                        ErrorHandler.ShowErrorMessage("عمليات با موفقيت انجام نشد.");
                    }
                }
                catch (System.Exception ex)
                {

                }
            }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (currentEval.PermanentRecord == true)
                {
                    ErrorHandler.NotifyUser("اين سند تأييد تهایی شده است");
                    return;
                }
                NavigationHandler.NavigateToPage(this, new RTM.Tenderingg.EvaluationReport(currentEval));
            }
            catch (System.Exception ex)
            {

            }
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sum = standardList.Sum(s => s.Weight);
            SumTxt.Content = sum.ToString();
        }

        

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RecordDescriptionTxt.Text = currentEval.Description;
            MinTxt.Text = currentEval.MinimumScore.ToString();
        }

        


    }
}

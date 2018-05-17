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
using RTM.Tendering1;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace RTM.Notices
{
    /// <summary>
    /// Interaction logic for CreateNotice.xaml
    /// </summary>
    public partial class CreateNotices : Page
    {
        public Tendering CurrentTendering;
        public Notice CurrentNotice;
        private BusyIndicator busy = new BusyIndicator();
        public CreateNotices(Tendering t)
        {
            CurrentTendering = t;
            CurrentNotice = DataManagement.SearchOrCreateNotice(CurrentTendering);
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.RequestPermanentCheck == true)
            {
                ErrorHandler.NotifyUser(Errors.Permanented);
                return;
            }
            if (NoticeDate.SelectedDate == null || PresenDeadlineDP.SelectedDate == null)
            {
                ErrorHandler.NotifyUser("موارد ضروری را وارد کنید");
                return;
            }
            if (NoticeDate.SelectedDate > PresenDeadlineDP.SelectedDate)
            {
                ErrorHandler.NotifyUser("توالی تاریخ ها رعایت شود");
                return;
            }
            DataManagement.UpdateTendering(CurrentTendering);
            ErrorHandler.NotifyUser(Errors.Saved);

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = CurrentTendering;
        }

        private void SaveAddInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SaveBtn.IsEnabled == true)
                NavigationHandler.NavigateToPage(this, new UI7RegisterAds(CurrentNotice,CurrentTendering));
            else
                NavigationHandler.NavigateToPageWithMode(this, new UI7RegisterAds(CurrentNotice,CurrentTendering), NavigationMethod.ViewMode, SubSystem.Tendering);
        }

        private void PermanentBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.RequestPermanentCheck == true)
            {
                ErrorHandler.NotifyUser(Errors.Permanented);
                return;
            }
            var t = DataManagement.SearchEvaluations(null, null, CurrentTendering.TenderingNumber, null, null, null, null, null,null).FirstOrDefault();
            if ( MessageBoxResult.No == MessageBox.Show("ثبت نهایی صورت بگیرد ؟","اخطار",MessageBoxButton.YesNo))
                return;
            CurrentTendering.RequestPermanentCheck = true;
            CurrentTendering.PermanentRecord = true;
            var currentReq = DataManagement.RetrieveTenderingContractorRequest(CurrentTendering);
            CurrentTendering.TenderingNumber = DataManagement.GenerateNoticeSystemCode(CurrentTendering,currentReq );
            currentReq.NoticeNumber = CurrentTendering.TenderingNumber;
            DataManagement.UpdateContractorRequest(currentReq);
            
            if(DataManagement.UpdateTendering(CurrentTendering)!=null)
            ErrorHandler.NotifyUser(Errors.PermanentRecord);
            else
            {
                ErrorHandler.ShowErrorMessage(Errors.FailedSave);
            }
        }

        private void OpenFileBtn_Click(object sender, RoutedEventArgs e)
        {
            var t = DataManagement.SearchEvaluations(null, null, CurrentTendering.TenderingNumber, null, null, null, null, null,null).FirstOrDefault();
            if (t == null || CurrentTendering.TenderingNumber == "" ||  CurrentTendering.TenderingNumber == null)
            {
                ErrorHandler.ShowErrorMessage("ارزیابی کیفی صورت نگرفته است");
                return;

            }
            var t2 = DataManagement.RetrieveEvaluationFile(t.EvaluationId);
            var x = DataManagement.HasEvaluationFileLocation(t.EvaluationId);
            if (x == null )
            {
                ErrorHandler.NotifyUser("صورتجلسه ارزیابی کیفی تا کنون ثبت نشده است");
                return;
            }
       
            layoutRoot.Children.Add(busy);
            Task.Factory.StartNew(delegate
            {
                try
                {
                    OpenFileHandler.OpenFileFromByte(DataManagement.RetrieveEvaluationFile(t.EvaluationId), x);
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
    }
}

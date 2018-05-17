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
    /// Interaction logic for UI8ExtendSesion.xaml
    /// </summary>
    public partial class UI8ExtendSesion : Page
    {
        public List<Meeting> MeetingList = new List<Meeting>();
        public Tendering CurrentTendering;
        public Meeting CurrentMeeting;

        private MeetingTypes MeetingType;
        private TenderingIndex applicant;
        private TenderingIndex committee;
        private TenderingIndex meeting;

        public UI8ExtendSesion()
        {
            InitializeComponent();
        }

        public UI8ExtendSesion(Tendering t,MeetingTypes type)
        {
            CurrentTendering = t;
            MeetingType = type;
            CurrentMeeting = new Meeting() { MeetingDate=DateTime.Now};
            InitializeComponent();
        }


        private void CommissionVoteRadio_Unchecked(object sender, RoutedEventArgs e)
        {
            CommVoteAddBtn.IsEnabled = false;
            CommVoteShowBtn.IsEnabled = false;
            CommDelBtn.IsEnabled = false;
        }

        private void CommissionVoteRadio_Checked(object sender, RoutedEventArgs e)
        {
            CommVoteAddBtn.IsEnabled = true;
            CommVoteShowBtn.IsEnabled = true;
            CommDelBtn.IsEnabled = true;
        }

        private void ApplicantReq_Checked(object sender, RoutedEventArgs e)
        {
            AppReqAddBtn.IsEnabled = true;
            AppReqShowBtn.IsEnabled = true;
            AppDelBtn.IsEnabled = true;
        }

        private void ApplicantReq_Unchecked(object sender, RoutedEventArgs e)
        {
            AppReqAddBtn.IsEnabled = false;
            AppReqShowBtn.IsEnabled = false;
            AppDelBtn.IsEnabled = false;
        }

        private void SesionRecordAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMeeting.MeetingId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            if (!UserData.CurrentAccessRight.TenderingWrite)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId,meeting, null, null, this.layoutRoot, null, CurrentMeeting.MeetingId);
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            switch (MeetingType)
            {
                case MeetingTypes.PacketExtendingMeeting:
                    applicant = TenderingIndex.ExtendMeetingApplicant;
                    committee = TenderingIndex.ExtendMeetingCommittee;
                    meeting = TenderingIndex.ExtendMeeting;
                    PageTitle.Content = "جلسه تمدید تسلیم پاکات";
                    break;
                case MeetingTypes.DocExtendingMeeting:
                    applicant = TenderingIndex.ExtendDocMeetingApplicant;
                    committee = TenderingIndex.ExtendDocMeetingCommittee;
                    meeting = TenderingIndex.ExtendDocMeeting;
                    PageTitle.Content = "جلسه تمدید ارائه اسناد";
                    break;
            }
            MeetingList = DataManagement.RetrieveMeetings(CurrentTendering,MeetingType);
            MC.ItemsSource = MeetingList;
            this.DataContext = CurrentMeeting;
            Header.CurrentRequest = DataManagement.RetrieveTenderingContractorRequest(CurrentTendering);
            SaveBtn.IsEnabled = false;
        }

        private void MC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MC.SelectedIndex == -1)
                return;
            CurrentMeeting = MC.SelectedItem as Meeting;
            this.DataContext = CurrentMeeting;
            if(CurrentMeeting.ExtendByApplicant)
                ApplicantReqRadio.IsChecked = true;
            if(CurrentMeeting.ExtendByCommittee)
                CommissionVoteRadio.IsChecked = true;
            SaveBtn.IsEnabled = true;
        }

        private void CommVoteAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMeeting.MeetingId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, committee, null, null, this.layoutRoot, null, CurrentMeeting.MeetingId);
        }

        private void CommVoteShowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMeeting.MeetingId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, committee, null, null, this.layoutRoot, null, CurrentMeeting.MeetingId);
        }

        private void CommDelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMeeting.MeetingId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, committee, null, null, this.layoutRoot, null, CurrentMeeting.MeetingId);
        }

        private void AppReqAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMeeting.MeetingId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, applicant, null, null, this.layoutRoot, null, CurrentMeeting.MeetingId);
        }

        private void AppReqShowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMeeting.MeetingId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, applicant, null, null, this.layoutRoot, null, CurrentMeeting.MeetingId);
        }

        private void AppDelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMeeting.MeetingId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, applicant, null, null, this.layoutRoot, null, CurrentMeeting.MeetingId);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RecordDateDP.SelectedDate == null || RecordDescriptionTxt.Text == "" || RecordDescriptionTxt.Text == "" || (ApplicantReqRadio.IsChecked == false && CommissionVoteRadio.IsChecked == false))
            {
                ErrorHandler.NotifyUser("برخی از اطلاعات ضروری وارد نشده است");
                return;
            }
            //if(!FilingManager.HasTenderingFile(CurrentTendering.TenderingId, committee, null, null, this.layoutRoot, null, CurrentMeeting.MeetingId)
            //    && !FilingManager.HasTenderingFile(CurrentTendering.TenderingId, applicant, null, null, this.layoutRoot, null, CurrentMeeting.MeetingId))
            //{
            //    ErrorHandler.ShowErrorMessage("بارگذاری فایل درخواست برای ثبت الزامی است.");
            //    return;
            //}
            if (CurrentMeeting.MeetingId == 0)
            {
                try
                {
                    CurrentMeeting.MeetingType = (int)MeetingType;
                    CurrentMeeting.TenderingId = CurrentTendering.TenderingId;
                    DataManagement.CreateMeeting(CurrentMeeting);
                    ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["SuccessfulSave"]);
                    MC.IsEnabled = true;
                    MeetingList = DataManagement.RetrieveMeetings(CurrentTendering, MeetingType);
                    MC.ItemsSource = MeetingList;
                }
                catch
                {
                    ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["FailedSave"]);
                }
            }
            else
            {
                try
                {
                    DataManagement.UpdateMeeting(CurrentMeeting);
                    ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["SuccessfulSave"]);
                    MC.IsEnabled = true;
                    MeetingList = DataManagement.RetrieveMeetings(CurrentTendering, MeetingType);
                    MC.ItemsSource = MeetingList;
                }
                catch
                {
                    ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["FailedSave"]);
                }
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMeeting.MeetingId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, meeting, null, null, this.layoutRoot, null, CurrentMeeting.MeetingId);
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMeeting.MeetingId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            if (!UserData.CurrentAccessRight.TenderingDelete)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, meeting, null, null, this.layoutRoot, null, CurrentMeeting.MeetingId);
        }

        private void PrintBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (CurrentMeeting.MeetingId == 0)
            {
                ErrorHandler.NotifyUser("ابتدا جلسه را ثبت کنید");
                return;
            }
            NavigationHandler.NavigateToPage(this, new Report.Report4.Report4_Viewer(CurrentMeeting,CurrentTendering));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = null;
            CurrentMeeting = new Meeting();
            this.DataContext = CurrentMeeting;
            MC.SelectedIndex = -1;
            SaveBtn.IsEnabled = true;
            MC.IsEnabled = false;
        }
    }
}

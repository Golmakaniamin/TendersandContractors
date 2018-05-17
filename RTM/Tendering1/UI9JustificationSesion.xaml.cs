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
    /// Interaction logic for UI9.xaml
    /// </summary>
    public partial class UI9JustificationSesion : Page
    {
        private const MeetingTypes MeetingType = MeetingTypes.BriefingMeeting;
        public Tendering CurrentTendering { set; get; }
        public Meeting CurrentMeeting { set; get; }
        public UI9JustificationSesion( Tendering x )
        {
            CurrentTendering = x;
            CurrentMeeting = new Meeting();
            CurrentMeeting = DataManagement.SearchOrCreateMeeting(CurrentTendering, MeetingType);
            InitializeComponent();
        }
        public UI9JustificationSesion()
        {
            InitializeComponent();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.Items.Count == 0)
            {
                label12.Foreground = new SolidColorBrush(Colors.Red);
                ErrorHandler.NotifyUser("برخی از اطلاعات ضروری وارد نشده است");
                return;
            }
            else { label12.Foreground = new SolidColorBrush(Colors.Black); }
            DataManagement.UpdateMeeting(CurrentMeeting);
            DataManagement.UpdateMeetingUserParticipants(dataGrid2.Items.Cast<User>().ToList(), CurrentMeeting);
            DataManagement.UpdateJustificationMeetingContractors(dataGrid4.Items.Cast<Contractor>().ToList(), CurrentMeeting);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            //if (dataGrid1.Items.Count == 0)
            //{
            //    label12.Foreground = new SolidColorBrush(Colors.Red);
            //    ErrorHandler.NotifyUser("برخی از اطلاعات ضروری وارد نشده است");
            //    return;
            //}
            //else { label12.Foreground = new SolidColorBrush(Colors.Black);}
            if (RecordDateDP.SelectedDate==null)
            {
                label32.Foreground = new SolidColorBrush(Colors.Red);
                ErrorHandler.NotifyUser("برخی از اطلاعات ضروری وارد نشده است");
                return;
            }
            else { label32.Foreground = new SolidColorBrush(Colors.Black); }

            if (RecordDescriptionTxt.Text=="")
            {
                label19.Foreground = new SolidColorBrush(Colors.Red);
                ErrorHandler.NotifyUser("برخی از اطلاعات ضروری وارد نشده است");
                return;
            }
            else { label19.Foreground = new SolidColorBrush(Colors.Black); }

            try
            {
                DataManagement.UpdateMeeting(CurrentMeeting);
                DataManagement.UpdateMeetingUserParticipants(dataGrid2.Items.Cast<User>().ToList(), CurrentMeeting);
                DataManagement.UpdateJustificationMeetingContractors(dataGrid4.Items.Cast<Contractor>().ToList(), CurrentMeeting);
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["SuccessfulSave"]);
            }
            catch
            {
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["FailedSave"]);
            }
        }

        private void MemberSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            var name = (NameTxt.Text.Trim() == "") ? null : NameTxt.Text;
            var family = (FamilyTxt.Text.Trim() == "") ? null : FamilyTxt.Text;
            var position = (PositionCom.Text.Trim() == "") ? null : PositionCom.Text;
            var t = DataManagement.SearchUsers(name, family, position, null);
            dataGrid1.ItemsSource = t;
        }

        private void MemberAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedIndex != -1 && dataGrid2.Items.IndexOf(dataGrid1.SelectedItem) == -1)
            {
                var x = from items in dataGrid2.Items.Cast<User>()
                        where items.UserId == (dataGrid1.SelectedItem as User).UserId
                        select items;
                if (x.Count() > 0)
                    return;
                dataGrid2.Items.Add(dataGrid1.SelectedItem);
            }
        }

        private void RefreshMemberBtn_Click(object sender, RoutedEventArgs e)
        {
            dataGrid1.ItemsSource = null;
            dataGrid2.Items.Clear();
        }

        private void DeleteMemberBtn_Click(object sender, RoutedEventArgs e)
        {

            if (dataGrid2.SelectedIndex != -1)
                dataGrid2.Items.Remove(dataGrid2.SelectedItem);
        }

        private void CntrctrSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            var name = (CompanyNameTxt.Text.Trim() == "") ? null : CompanyNameTxt.Text;
            var social = (SocialNumberTxt.Text.Trim() == "") ? null : SocialNumberTxt.Text;
            var t = DataManagement.SearchContractors(name, social, null, true, null);
            dataGrid3.ItemsSource = t;
        }

        private void CntrctrAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid3.SelectedIndex != -1 && dataGrid4.Items.IndexOf(dataGrid3.SelectedItem) == -1)
            {
                var x = from items in dataGrid4.Items.Cast<Contractor>()
                        where items.ContractorId == (dataGrid3.SelectedItem as Contractor).ContractorId
                        select items;
                if (x.Count() > 0)
                    return;
                dataGrid4.Items.Add(dataGrid3.SelectedItem);
            }
        }

        private void RefreshCntrctrBtn_Click(object sender, RoutedEventArgs e)
        {
            dataGrid3.ItemsSource = null;
            dataGrid4.Items.Clear();
        }

        private void DeleteCntrctrBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid4.SelectedIndex != -1)
                dataGrid4.Items.Remove(dataGrid4.SelectedItem);
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
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.BriefingMeeting, null, null, this.layoutRoot, null, CurrentMeeting.MeetingId);
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMeeting.MeetingId == 0)
            {
                ErrorHandler.NotifyUser("ابتدا جلسه را ثبت کنید");
                return;
            }
            if (RecordDateDP.SelectedDate == null)
            {
                label32.Foreground = new SolidColorBrush(Colors.Red);
                ErrorHandler.NotifyUser("برخی از اطلاعات ضروری وارد نشده است");
                return;
            }
            else { label32.Foreground = new SolidColorBrush(Colors.Black); }

            if (RecordDescriptionTxt.Text == "")
            {
                label19.Foreground = new SolidColorBrush(Colors.Red);
                ErrorHandler.NotifyUser("برخی از اطلاعات ضروری وارد نشده است");
                return;
            }
            else { label19.Foreground = new SolidColorBrush(Colors.Black); }
            NavigationHandler.NavigateToPage(this,new Report.Report3.Report3_Viewer(CurrentMeeting,CurrentTendering));
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            Header.CurrentRequest = DataManagement.RetrieveTenderingContractorRequest(CurrentTendering);
            dataGrid2.Items.Clear();
            dataGrid4.Items.Clear();
            var d1 = DataManagement.RetrieveMeetingUserParticipant(CurrentMeeting);
            foreach (var item in d1)
            {
                dataGrid2.Items.Add(item);
            }
            
            var d2 = DataManagement.RetrieveJustificationMeetingContractor(CurrentMeeting);
            var d3 = from items in DataManagement.RetrieveTenderingDocumentRecieve(CurrentTendering) select items.ContractorId;
            if (d2.Count > 0)
            {
                foreach (var item in d2)
                {
                    dataGrid4.Items.Add(item);
                }
            }
            else
            {
                using (var en = new RTMEntities())
                {
                    var d4 = from items in en.Contractors where d3.Contains(items.ContractorId) select items;
                    foreach (var item in d4)
                    {
                        dataGrid4.Items.Add(item);
                    }
                }

            }

            
        }

        private void PositionCom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ShowBtn_Click(object sender, RoutedEventArgs e)
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
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.BriefingMeeting, null, null, this.layoutRoot, null, CurrentMeeting.MeetingId);
        }

        private void DelReportBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMeeting.MeetingId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, TenderingIndex.BriefingMeeting, null, null, this.layoutRoot, null, CurrentMeeting.MeetingId);
        }
    }
}

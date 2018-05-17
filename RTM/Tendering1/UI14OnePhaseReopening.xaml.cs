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
    /// Interaction logic for UI14OnePhaseReopening.xaml
    /// </summary>
    public partial class UI14OnePhaseReopening : Page
    {
        private const MeetingTypes MeetingType = MeetingTypes.OnePhaseOpenPacket;
        private List<ContractorMeetingOpenPacket> list = new List<ContractorMeetingOpenPacket>();
        public Tendering CurrentTendering { set; get; }
        public Meeting CurrentMeeting { set; get; }
        public UI14OnePhaseReopening()
        {
            CurrentMeeting = new Meeting();
            InitializeComponent();
        }
        public UI14OnePhaseReopening( Tendering t)
        {
            CurrentTendering = t;
            CurrentMeeting = DataManagement.SearchOrCreateMeeting(t, MeetingType);
            InitializeComponent();
        }
      

        private void QualifyEstimateCheck_Checked(object sender, RoutedEventArgs e)
        {
            //EstimateReportBtn.IsEnabled = true;
        }

        private void QualifyEstimateCheck_Unchecked(object sender, RoutedEventArgs e)
        {
            //EstimateReportBtn.IsEnabled = false;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            //if (SesionDateDP.SelectedDate==null)
            //{
            //    label32.Foreground = new SolidColorBrush(Colors.Red);
            //    ErrorHandler.NotifyUser("برخی از اطلاعات ضروری وارد نشده است");
            //    return;
            //}
            //else
            //{
            //    label32.Foreground = new SolidColorBrush(Colors.Black);
            //}
            try
            {
                DataManagement.UpdateMeeting(CurrentMeeting);
                DataManagement.UpdateMeetingUserParticipants(dataGrid2.Items.Cast<User>().ToList(), CurrentMeeting);
                DataManagement.UpdateContractoOpenPacket(list);
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["SuccessfulSave"]);
                DataManagement.UpdateTenderingStage(CurrentTendering, Stages.OpenPacket);
            }
            catch
            {
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["FailedSave"]);
                DataManagement.UpdateTenderingStage(CurrentTendering, Stages.OpenPacket);
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


        private void SaveResultBtn_Click(object sender, RoutedEventArgs e)
        {

            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.OpenPacketOne, null, null, this.layoutRoot, null, CurrentMeeting.MeetingId);
        }
        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (!UserData.CurrentAccessRight.TenderingWrite)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            if (SaveBtn.IsEnabled == false)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            var item = MainGrid.SelectedItem as ContractorMeetingOpenPacket;
            if (item == null || item.CMOId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, (TenderingIndex.OpenPacketIntroductionLetter), item.ContractorId, null, this.layoutRoot, null);
        }

        private void DeleteFile_Click(object sender, RoutedEventArgs e)
        {
            if (!UserData.CurrentAccessRight.TenderingDelete)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            if (SaveBtn.IsEnabled == false || !UserData.CurrentAccessRight.TenderingDelete)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            var item = MainGrid.SelectedItem as ContractorMeetingOpenPacket;
            if (item == null || item.CMOId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, (TenderingIndex.OpenPacketIntroductionLetter), item.ContractorId, null, this.layoutRoot, null);
        }

        private void ViewFile_Click(object sender, RoutedEventArgs e)
        {
            var item = MainGrid.SelectedItem as ContractorMeetingOpenPacket;
            if (item == null || item.CMOId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, (TenderingIndex.OpenPacketIntroductionLetter), item.ContractorId, null, this.layoutRoot, null);
        }

        private void SavePriceOfferBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveGauranteeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBtn_Click_1(object sender, RoutedEventArgs e)
        {
            DataManagement.CreateMeeting(CurrentMeeting);
            DataManagement.UpdateMeetingUserParticipants(dataGrid2.Items.Cast<User>().ToList(), CurrentMeeting);
            DataManagement.UpdateContractoOpenPacket(list);
        }

        private void EditBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            Header.CurrentRequest = DataManagement.RetrieveTenderingContractorRequest(CurrentTendering);
            var d1 = DataManagement.RetrieveMeetingUserParticipant(CurrentMeeting);
            if (dataGrid2.Items.Count == 0)
            {
                foreach (var item in d1)
                {
                    dataGrid2.Items.Add(item);
                }
            }
            //var d2 = DataManagement.RetrieveOpenPacketMeetingContractor(CurrentMeeting);
            //foreach (var item in d2)
            //{
            //    dataGrid4.Items.Add(item);
            //}
            list = DataManagement.RetrieveContractorOpenPacket(CurrentTendering,CurrentMeeting);
            MainGrid.ItemsSource = list;
            
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentMeeting.MeetingId == 0)
            {
                ErrorHandler.NotifyUser("ابتدا جلسه را ثبت کنید");
                return;
            }
            NavigationHandler.NavigateToPage(this, new Report.Report6.Report6_Viewer(CurrentMeeting, CurrentTendering));
        }

        private void SesionRecordAddBtn_Click(object sender, RoutedEventArgs e)
        {
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.OpenPacketOne, null, null, this.layoutRoot, null, CurrentMeeting.MeetingId);
        }

        private void OpenFileBtn_Click(object sender, RoutedEventArgs e)
        {
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.OpenPacketOne, null, null, this.layoutRoot, null, CurrentMeeting.MeetingId);
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, TenderingIndex.OpenPacketOne, null, null, this.layoutRoot, null, CurrentMeeting.MeetingId);
        }

       
	}
}  
       

       


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
    /// Interaction logic for UI21TwoPhaseReopeningSesion.xaml
    /// </summary>
    public partial class UI21TwoPhaseReopeningSesion : Page
    {
        private const MeetingTypes MeetingType = MeetingTypes.TwoPhaseOpenPacket;
        private List<ContractorMeetingOpenPacket> list = new List<ContractorMeetingOpenPacket>();
        public Tendering CurrentTendering { set; get; }
        public Meeting CurrentMeeting { set; get; }
        public UI21TwoPhaseReopeningSesion(Tendering t)
        {
            CurrentTendering = t;
            CurrentMeeting = DataManagement.SearchOrCreateMeeting(t, MeetingType);
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if ( ReopeningDateDP.SelectedDate == null)
            {
                labell.Foreground = new SolidColorBrush(Colors.Red);
                ErrorHandler.NotifyUser("برخی از اطلاعات ضروری وارد نشده است");
                return;
            }
            else { labell.Foreground = new SolidColorBrush(Colors.Black); }
            DataManagement.UpdateMeeting(CurrentMeeting);
            DataManagement.UpdateMeetingUserParticipants(dataGrid2.Items.Cast<User>().ToList(), CurrentMeeting);
            DataManagement.UpdateContractoOpenPacket(list);
            
            DataManagement.UpdateTenderingStage(CurrentTendering, Stages.OpenPacket);
            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["SuccessfulSave"]);
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid2.Items.Count == 0)
            {
                label12.Foreground = new SolidColorBrush(Colors.Red);
                ErrorHandler.NotifyUser("برخی از اطلاعات ضروری وارد نشده است");
                return;
            }
            else { label12.Foreground = new SolidColorBrush(Colors.Black); }
            DataManagement.UpdateMeeting(CurrentMeeting);
            DataManagement.UpdateMeetingUserParticipants(dataGrid2.Items.Cast<User>().ToList(), CurrentMeeting);
            DataManagement.UpdateContractoOpenPacket(list);
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            Header.CurrentRequest = DataManagement.RetrieveTenderingContractorRequest(CurrentTendering);
            this.DataContext = CurrentMeeting;
            var d1 = DataManagement.RetrieveMeetingUserParticipant(CurrentMeeting);
            foreach (var item in d1)
            {
                dataGrid2.Items.Add(item);
            }
            //var d2 = DataManagement.RetrieveOpenPacketMeetingContractor(CurrentMeeting);
            //foreach (var item in d2)
            //{
            //    dataGrid4.Items.Add(item);
            //}
            list = DataManagement.RetrieveContractorOpenPacket(CurrentTendering, CurrentMeeting);
            MainGrid.ItemsSource = list;
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

        }

        private void SavePriceOfferBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowResponseBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveGauranteeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PermanentBtn_Click(object sender, RoutedEventArgs e)
        {

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

	}
}  
       

       


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

namespace RTM.Tenderingg
{
    /// <summary>
    /// Interaction logic for Evaluation1_1.xaml
    /// </summary>
    public partial class Evaluation1_1 : Page
    {
        private Evaluation CurrentEval = new Evaluation();
        public Tendering CurrentTender = new Tendering();

        public Evaluation1_1()
        {
            InitializeComponent();
            datePicker1.SelectedDate = DateTime.Now;
        }
        public Evaluation1_1(Evaluation eval)
        {
            CurrentEval = eval;

            InitializeComponent();
            LoadEvaluation();
            //NavigationHandler.ForceAccessToDestinationPageWithMode(this, false, NavigationMethod.EditMode, SubSystem.Tendering);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var t = DataManagement.RetrievePositions();
            PositionCom.ItemsSource = t;
            if (Grid2.Items.Count > 0)
                return;
            foreach (var item in DataManagement.RetrieveTechnicalCommittee())
            {
                Grid2.Items.Add(item);
            }
        }
        private void LoadEvaluation()
        {
            TitleTxt.Text = CurrentEval.Title;
            TenderNumberTxt.Text = CurrentEval.TenderingNumber;
            NoticeNumber.Text = CurrentEval.NoticeNumber;
            Tick.IsChecked = CurrentEval.HasTendering;
            MinTxt.Text = CurrentEval.MinimumScore.ToString();
            foreach (var item in CurrentEval.UserEvaluationMembers)
            {
                Grid2.Items.Add(item.User);
            }
            foreach (var item in CurrentEval.EvaluationContractors)
            {
                Grid4.Items.Add(item.Contractor);
            }
            datePicker1.SelectedDate = CurrentEval.MeetingDate;
            MinuteTxt.Text = ((DateTime)CurrentEval.MeetingDate).Minute.ToString();
            HourTxt.Text = ((DateTime)CurrentEval.MeetingDate).Hour.ToString();
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TitleTxt.Text == "") { l1.Foreground = new SolidColorBrush(Colors.Red); } else { l1.Foreground = new SolidColorBrush(Colors.Black); }
            if (MinTxt.Text == "") { l90.Foreground = new SolidColorBrush(Colors.Red); } else { l90.Foreground = new SolidColorBrush(Colors.Black); }
            if (TenderNumberTxt.Text == "" && Tick.IsChecked == true) { l3.Foreground = new SolidColorBrush(Colors.Red); } else { l3.Foreground = new SolidColorBrush(Colors.Black); }
            if (Grid2.Items.Count == 0) { l4.Foreground = new SolidColorBrush(Colors.Red); } else { l4.Foreground = new SolidColorBrush(Colors.Black); }
            if (Grid4.Items.Count == 0) { l5.Foreground = new SolidColorBrush(Colors.Red); } else { l5.Foreground = new SolidColorBrush(Colors.Black); }
            if (HourTxt.Text == "" || MinuteTxt.Text == "") { l6.Foreground = new SolidColorBrush(Colors.Red); } else { l6.Foreground = new SolidColorBrush(Colors.Black); }
            if (MinTxt.Text == "" || HourTxt.Text == "" || MinuteTxt.Text == "" || TitleTxt.Text == "" || (TenderNumberTxt.Text == "" && Tick.IsChecked == true) || Grid2.Items.Count == 0 || Grid4.Items.Count == 0)
            {
                ErrorHandler.NotifyUser("برخی اطلاعات ضروری وارد نشده اند");
                return;
            }
            else if(NextBtn.IsEnabled == true)
            {

                ErrorHandler.ShowErrorMessage("ثبت قبلا صورت گرفته است. لطفا به صفحه بعد بروید.");
                return;
            }
            else
            {
                List<User> l = new List<User>();
                foreach (var item in Grid2.Items)
                {
                    l.Add(item as User);
                }
                List<Contractor> l2 = new List<Contractor>();
                foreach (var item in Grid4.Items)
                {
                    l2.Add(item as Contractor);
                }
                try
                {
                    var d = (DateTime)datePicker1.SelectedDate;
                    DateTime date = new DateTime(d.Year, d.Month, d.Day, Int32.Parse(HourTxt.Text), Int32.Parse(MinuteTxt.Text), 0);
                    CurrentEval = DataManagement.CreateEvaluationForm(Int32.Parse(MinTxt.Text), date, TitleTxt.Text, (Tick.IsChecked==true)?TenderNumberTxt.Text:null, l, l2, false, true, NoticeNumber.Text,(bool)Tick.IsChecked, false);
                    ErrorHandler.NotifyUser("ثبت با موفقیت انجام شد به صفحه بعد بروید");
                    NextBtn.IsEnabled = true;
                    EditBtn.IsEnabled = true;
                }
                catch (System.Exception ex)
                {
                }
            }



        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentEval.PermanentRecord == true && UserData.CurrentAccessRight.SysAdmin == false)
            {
                ErrorHandler.NotifyUser("اين سند قبلا به تأييد نهايي رسيده است.");
                return;
            }
            if (MinTxt.Text == "") { l90.Foreground = new SolidColorBrush(Colors.Red); } else { l90.Foreground = new SolidColorBrush(Colors.Black); }
            if (TitleTxt.Text == "") { l1.Foreground = new SolidColorBrush(Colors.Red); } else { l1.Foreground = new SolidColorBrush(Colors.Black); }
            if (TenderNumberTxt.Text == "" && Tick.IsChecked == true) { l3.Foreground = new SolidColorBrush(Colors.Red); } else { l3.Foreground = new SolidColorBrush(Colors.Black); }
            if (Grid2.Items.Count == 0) { l4.Foreground = new SolidColorBrush(Colors.Red); } else { l4.Foreground = new SolidColorBrush(Colors.Black); }
            if (Grid4.Items.Count == 0) { l5.Foreground = new SolidColorBrush(Colors.Red); } else { l5.Foreground = new SolidColorBrush(Colors.Black); }
            if (HourTxt.Text == "" || MinuteTxt.Text == "") { l6.Foreground = new SolidColorBrush(Colors.Red); } else { l6.Foreground = new SolidColorBrush(Colors.Black); }
            if (MinTxt.Text == "" || HourTxt.Text == "" || MinuteTxt.Text == "" || TitleTxt.Text == "" || (TenderNumberTxt.Text == "" && Tick.IsChecked == true) || Grid2.Items.Count == 0 || Grid4.Items.Count == 0)
            {
                ErrorHandler.NotifyUser("برخی اطلاعات ضروری وارد نشده اند");
                return;
            }
            List<User> l = new List<User>();
            foreach (var item in Grid2.Items)
            {
                l.Add(item as User);
            }
            List<Contractor> l2 = new List<Contractor>();
            foreach (var item in Grid4.Items)
            {
                l2.Add(item as Contractor);
            }
            try
            {
                var d = (DateTime)datePicker1.SelectedDate;
                DateTime date = new DateTime(d.Year, d.Month, d.Day, Int32.Parse(HourTxt.Text), Int32.Parse(MinuteTxt.Text), 0);
                DataManagement.EditEvaluationForm(CurrentEval.EvaluationId, Int32.Parse(MinTxt.Text), date, TitleTxt.Text, (Tick.IsChecked == true) ?(TenderNumberTxt.Text) : null, l, l2, false,true,NoticeNumber.Text,null, (bool)Tick.IsChecked,(bool)CurrentEval.PermanentRecord);
                ErrorHandler.NotifyUser("ویرایش با موفقیت انجام شد");

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("مشکل در وارد کردن تاریخ و ساعت");
            }
        }

        private void searchContractor_Click(object sender, RoutedEventArgs e)
        {
            var name = (CompanyNameTxt.Text.Trim() == "") ? null : CompanyNameTxt.Text;
            var social = (SocialNumberTxt.Text.Trim() == "") ? null : SocialNumberTxt.Text;
            var t = DataManagement.SearchContractors(name, social, null, true, null);
            Grid3.ItemsSource = t;
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            var name = (NameTxt.Text.Trim() == "") ? null : NameTxt.Text;
            var family = (FamilyTxt.Text.Trim() == "") ? null : FamilyTxt.Text;
            var position = (PositionCom.Text.Trim() == "") ? null : PositionCom.Text;
            var t = DataManagement.SearchUsers(name, family, position, null);
            Grid1.ItemsSource = t;
        }

        private void button1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // ADD SELECTED USER

            if (Grid1.SelectedIndex != -1 && Grid2.Items.IndexOf(Grid1.SelectedItem) == -1)
            {
                var x = from items in Grid2.Items.Cast<User>()
                        where items.UserId == (Grid1.SelectedItem as User).UserId
                        select items;
                if(x.Count()>0)
                    return;
                Grid2.Items.Add(Grid1.SelectedItem);
            }
                
        }

        private void RefreshBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            Grid1.ItemsSource = null;
            Grid2.Items.Clear();

        }

        private void button2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            if (Grid2.SelectedIndex != -1)
                Grid2.Items.Remove(Grid2.SelectedItem);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            if (Grid3.SelectedIndex != -1 && Grid4.Items.IndexOf(Grid3.SelectedItem) == -1)
            {
                var x = from items in Grid4.Items.Cast<Contractor>()
                        where items.ContractorId == (Grid3.SelectedItem as Contractor).ContractorId
                        select items;
                if (x.Count() > 0)
                    return;
                Grid4.Items.Add(Grid3.SelectedItem);
            }

        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if (Grid4.SelectedIndex != -1)
                Grid4.Items.Remove(Grid4.SelectedItem);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Grid3.ItemsSource = null;
            Grid4.Items.Clear();
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SaveBtn.IsEnabled == true)
            {
                NavigationHandler.NavigateToPageWithMode(this, new Tenderingg.Evaluation2(1,CurrentEval), NavigationMethod.EditMode, SubSystem.Tendering);
            }
            else if (EditBtn.IsEnabled == true)
            {
                NavigationHandler.NavigateToPageWithMode(this, new Tenderingg.Evaluation2(1, CurrentEval), NavigationMethod.EditMode, SubSystem.Tendering);
            }
            else
            {
                NavigationHandler.NavigateToPageWithMode(this, new Tenderingg.Evaluation2(1, CurrentEval), NavigationMethod.ViewMode, SubSystem.Tendering);
            }
        }

  
        private void TenderNumberTxt_LostFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var t = DataManagement.SearchTenderings("", "", TenderNumberTxt.Text, "", "").FirstOrDefault();
            CurrentTender = t;
            if (t != null && TenderNumberTxt.Text != "")
            {
                ErrorHandler.NotifyUser(Errors.FoundTendering);
                MinTxt.Text = t.MinScore.ToString();
                Grid4.Items.Clear();
                foreach (var item in DataManagement.RetrieveContractorsWhoSubmitPacket(t))
                {
                    Grid4.Items.Add(item);
                }
               // searchContractor.IsEnabled = button3.IsEnabled = button5.IsEnabled = button6.IsEnabled = false;
            }
            else
            {
                TenderNumberTxt.Text = "";
                Tick.IsChecked = false;
                ErrorHandler.ShowErrorMessage(Errors.NotFoundTendering);
            }
        }

        private void NoticeNumber_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var t = DataManagement.SearchTenderings("","",NoticeNumber.Text,"","",null,null,null,null,null,null,null,null,"",null,null,true).FirstOrDefault();
            if (t != null && NoticeNumber.Text !="")
            {
                ErrorHandler.NotifyUser(Errors.FoundNotice);
                MinTxt.Text = t.MinScore.ToString();
                TitleTxt.Text = t.TenderingTitle;
            }
            else
            {
                NoticeNumber.Text = "";
                ErrorHandler.ShowErrorMessage(Errors.NotFoundNotice);
            }
        }

       
    }
}

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
    /// Interaction logic for Evaluation1.xaml
    /// </summary>
    public partial class Evaluation1 : Page
    {
        private Evaluation currentEval = new Evaluation();
        public Evaluation1()
        {
            InitializeComponent();
            datePicker1.SelectedDate = DateTime.Now;
        }
        public Evaluation1(Evaluation eval)
        {
            currentEval = eval;
           
            InitializeComponent();
            LoadEvaluation();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var t = DataManagement.RetrievePositions();
            PositionCom.ItemsSource = t;
            if (Grid2.Items.Count > 0)
                return;
            foreach (var item in DataManagement.RetrieveConsultantCommittee())
            {
                Grid2.Items.Add(item);
            }
        }
        private void LoadEvaluation()
        {
            MinTxt.Text = currentEval.MinimumScore.ToString();
            TitleTxt.Text = currentEval.Title;
            textBox1.Text = currentEval.EvaluationId.ToString();

            foreach (var item in currentEval.UserEvaluationMembers)
            {
                Grid2.Items.Add(item.User);
            }
            foreach (var item in currentEval.EvaluationContractors)
            {
                Grid4.Items.Add(item.Contractor);
            }
            datePicker1.SelectedDate = currentEval.MeetingDate;
            MinuteTxt.Text = ((DateTime)currentEval.MeetingDate).Minute.ToString();
            HourTxt.Text = ((DateTime)currentEval.MeetingDate).Hour.ToString();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TitleTxt.Text == "") { l1.Foreground = new SolidColorBrush(Colors.Red); } else { l1.Foreground = new SolidColorBrush(Colors.Black); }
            if (MinTxt.Text == "") { l22.Foreground = new SolidColorBrush(Colors.Red); } else { l22.Foreground = new SolidColorBrush(Colors.Black); }
            if (Grid2.Items.Count == 0) { l4.Foreground = new SolidColorBrush(Colors.Red); } else { l4.Foreground = new SolidColorBrush(Colors.Black); }
            if (Grid4.Items.Count == 0) { l5.Foreground = new SolidColorBrush(Colors.Red); } else { l5.Foreground = new SolidColorBrush(Colors.Black); }
            if (HourTxt.Text == "" || MinuteTxt.Text == "") { l6.Foreground = new SolidColorBrush(Colors.Red); } else { l6.Foreground = new SolidColorBrush(Colors.Black); }
            if (HourTxt.Text == "" || MinuteTxt.Text == "" || TitleTxt.Text == "" || MinTxt.Text == "" || Grid2.Items.Count == 0 || Grid4.Items.Count == 0)
            {
                ErrorHandler.NotifyUser("برخی اطلاعات ضروری وارد نشده اند");
                return;
            }
            else if (NextBtn.IsEnabled == true)
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
                    currentEval = DataManagement.CreateEvaluationForm(Int32.Parse(MinTxt.Text), (DateTime)(datePicker1.SelectedDate), TitleTxt.Text, null, l, l2, true, false,null, false, false);
                    ErrorHandler.NotifyUser("ثبت با موفقیت انجام شد به صفحه بعد بروید");
                    NextBtn.IsEnabled = true;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("مشکل در وارد کردن تاریخ و ساعت");
                }
            }

            
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currentEval.PermanentRecord == true && UserData.CurrentAccessRight.SysAdmin == false)
            {
                ErrorHandler.NotifyUser("اين سند قبلا به تأييد نهايي رسيده است.");
                return;
            }
            if (TitleTxt.Text == "") { l1.Foreground = new SolidColorBrush(Colors.Red); } else { l1.Foreground = new SolidColorBrush(Colors.Black); }
            if (MinTxt.Text == "") { l22.Foreground = new SolidColorBrush(Colors.Red); } else { l22.Foreground = new SolidColorBrush(Colors.Black); }
            if (Grid2.Items.Count == 0) { l4.Foreground = new SolidColorBrush(Colors.Red); } else { l4.Foreground = new SolidColorBrush(Colors.Black); }
            if (Grid4.Items.Count == 0) { l5.Foreground = new SolidColorBrush(Colors.Red); } else { l5.Foreground = new SolidColorBrush(Colors.Black); }
            if (HourTxt.Text == "" || MinuteTxt.Text == "") { l6.Foreground = new SolidColorBrush(Colors.Red); } else { l6.Foreground = new SolidColorBrush(Colors.Black); }
            if (HourTxt.Text == "" || MinuteTxt.Text == "" || TitleTxt.Text == "" || MinTxt.Text == "" || Grid2.Items.Count == 0 || Grid4.Items.Count == 0)
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
                DataManagement.EditEvaluationForm(currentEval.EvaluationId, Int32.Parse(MinTxt.Text), date, TitleTxt.Text, null, l, l2, true, false, null,null,false, (bool)currentEval.PermanentRecord);
                ErrorHandler.NotifyUser("ویرایش با موفقیت انجام شد");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("ویرایش با مشکل مواجه شد");
            }
            
        }

        private void textBox6_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
         private void searchContractor_Click(object sender, RoutedEventArgs e)
        {
            var name = (CompanyNameTxt.Text.Trim() == "") ? null : CompanyNameTxt.Text;
            var social = (SocialNumberTxt.Text.Trim() == "") ? null : SocialNumberTxt.Text;
            var t = DataManagement.SearchContractors(name, social,null,null,true);
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
                if (x.Count() > 0)
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
			if(Grid2.SelectedIndex!=-1)
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
                NavigationHandler.NavigateToPageWithMode(this, new Tenderingg.Evaluation2(2, currentEval), NavigationMethod.NewMode, SubSystem.Tendering);
            }
            else if (EditBtn.IsEnabled == true)
            {
                NavigationHandler.NavigateToPageWithMode(this, new Tenderingg.Evaluation2(2, currentEval), NavigationMethod.EditMode, SubSystem.Tendering);
            }
            else
            {
                NavigationHandler.NavigateToPageWithMode(this, new Tenderingg.Evaluation2(2, currentEval), NavigationMethod.ViewMode, SubSystem.Tendering);
            }
        }

    }
}

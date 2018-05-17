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
    /// Interaction logic for PriceEvaluation.xaml
    /// </summary>
    public partial class PriceEvaluation : Page
    {
        public Evaluation CurrentEvaluation = null;
        public Tendering CurrentTendering = new Tendering();
        public PriceEvaluation()
        {
            CurrentEvaluation = new Evaluation();
            InitializeComponent();
        }
        public PriceEvaluation(Evaluation e)
        {
            CurrentEvaluation = e;
            InitializeComponent();
        }

        private void TenderNumberTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TitleTxt.Text=="") { l1.Foreground = new SolidColorBrush(Colors.Red); } else { l1.Foreground = new SolidColorBrush(Colors.Black); }
            if (TenderNumberTxt.Text == "") { l2.Foreground = new SolidColorBrush(Colors.Red); } else { l2.Foreground = new SolidColorBrush(Colors.Black); }
            if (datePicker1.SelectedDate == null) { l3.Foreground = new SolidColorBrush(Colors.Red); } else { l3.Foreground = new SolidColorBrush(Colors.Black); }
            if (HourTxt.Text=="" || MinuteTxt.Text=="" || (int.Parse)(HourTxt.Text) > 23 || (int.Parse)(HourTxt.Text) < 0 || (int.Parse)(MinuteTxt.Text) > 59 || (int.Parse)(MinuteTxt.Text) < 0) { l4.Foreground = new SolidColorBrush(Colors.Red); } else { l4.Foreground = new SolidColorBrush(Colors.Black); }
            if (Grid2.Items.Count==0) { l5.Foreground = new SolidColorBrush(Colors.Red); } else { l5.Foreground = new SolidColorBrush(Colors.Black); }
            if (TitleTxt.Text == "" || TenderNumberTxt.Text == "" || datePicker1.SelectedDate == null || HourTxt.Text == "" || MinuteTxt.Text == "" || Grid2.Items.Count == 0)
            {
                ErrorHandler.NotifyUser("برخی اطلاعات ضروری وارد نشده اند");
                return;
            }
            if ((int.Parse)(HourTxt.Text) > 23 || (int.Parse)(HourTxt.Text) < 0 || (int.Parse)(MinuteTxt.Text) > 59 || (int.Parse)(MinuteTxt.Text) < 0)
            {
                ErrorHandler.NotifyUser("ساعت نادرست وارد شده است");
                return;
            }
            var d = (DateTime)datePicker1.SelectedDate;
            DateTime date = new DateTime(d.Year, d.Month, d.Day, Int32.Parse(HourTxt.Text), Int32.Parse(MinuteTxt.Text), 0);
            CurrentEvaluation.MeetingDate = date;
            if (CurrentEvaluation.EvaluationId == 0)
            {
                try
                {
                    DataManagement.CreateEvaluation(CurrentEvaluation, Grid2.Items.Cast<User>().ToList());
                    ErrorHandler.NotifyUser("ثبت موفقیت آمیز بود");
                }
                catch
                {
                    ErrorHandler.NotifyUser("ثبت با شکست مواجه شد");
                }
            }
            else
            {
                try
                {
                    DataManagement.UpdateEvaluation(CurrentEvaluation, Grid2.Items.Cast<User>().ToList());
                    ErrorHandler.NotifyUser("ثبت موفقیت آمیز بود");
                }
                catch
                {
                    ErrorHandler.NotifyUser("ثبت با شکست مواجه شد");
                }
            }

        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentEvaluation.EvaluationId == 0)
            {
                ErrorHandler.NotifyUser("ابتدا جلسه را ثبت کنید");
                return;
            }
            else if (EditBtn.IsEnabled == false)
            {
                NavigationHandler.NavigateToPageWithMode(this, new RTM.Tenderingg.PriceEvaluation1(CurrentEvaluation),NavigationMethod.ViewMode,SubSystem.Tendering);
            }
            else
            {

                NavigationHandler.NavigateToPage(this, new RTM.Tenderingg.PriceEvaluation1(CurrentEvaluation));
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            var name = (NameTxt.Text.Trim() == "") ? null : NameTxt.Text;
            var family = (FamilyTxt.Text.Trim() == "") ? null : FamilyTxt.Text;
            var position = (PositionCom.Text.Trim() == "") ? null : PositionCom.Text;
            var t = DataManagement.SearchUsers(name, family, position, null);
            Grid1.ItemsSource = t;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentEvaluation.MeetingType = true;
            PositionCom.ItemsSource = DataManagement.RetrievePositions();
            this.DataContext = CurrentEvaluation;
            if (Grid2.Items.Count > 0)
                return;
            foreach (var item in CurrentEvaluation.UserEvaluationMembers)
            {
                Grid2.Items.Add(item.User);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
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

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid1.ItemsSource = null;
            Grid2.Items.Clear();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (Grid2.SelectedIndex != -1)
                Grid2.Items.Remove(Grid2.SelectedItem);
        }

        private void TenderNumberTxt_LostFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var t = DataManagement.SearchTenderings("", "", TenderNumberTxt.Text, "", "").FirstOrDefault();
            CurrentTendering = t;
            if (t != null)
            {
                CurrentEvaluation.Title = t.TenderingTitle;
                ErrorHandler.NotifyUser(Errors.FoundTendering);
            }
            else
            {
                CurrentEvaluation.TenderingNumber = "";
                ErrorHandler.ShowErrorMessage(Errors.NotFoundTendering);
            }
        }
    }
}

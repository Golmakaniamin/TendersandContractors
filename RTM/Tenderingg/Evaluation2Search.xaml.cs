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
    /// Interaction logic for Evaluation2Search.xaml
    /// </summary>
    public partial class Evaluation2Search : Page
    {
        public Evaluation2Search()
        {
            InitializeComponent();
            Grid.ItemsSource = null;
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            TitleTxt.Text = "";
            NumberTxt.Text = "";
            Grid.ItemsSource = null;
            TypeCom.SelectedIndex = -1;
            NoticeNum.Text = "";
            datepicker.SelectedDate = null;
            datePicker1.SelectedDate = null;
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.SelectedIndex == -1) MessageBox.Show("هیج موردی انتخاب نشده");
            else if((Grid.SelectedItem as Evaluation).IsContractorMeeting == true)
            {
                NavigationHandler.NavigateToPageWithMode(this, new Evaluation1_1((Evaluation)Grid.SelectedItem),NavigationMethod.ViewMode,SubSystem.Tendering);
            }
            else
            {
                NavigationHandler.NavigateToPageWithMode(this, new PriceEvaluation((Evaluation)Grid.SelectedItem), NavigationMethod.ViewMode, SubSystem.Tendering);
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            var tx = (TitleTxt.Text.Trim() == "") ? null : TitleTxt.Text;
            var tnt = (NumberTxt.Text.Trim() == "") ? null : NumberTxt.Text;
            var nt = (NoticeNum.Text.Trim() == "") ? null : NoticeNum.Text;
            var t = DataManagement.SearchEvaluations(null, tnt, nt, tx, datepicker.SelectedDate, datePicker1.SelectedDate, null, null, (bool?)(TypeCom.SelectedIndex == 0 ? false : (TypeCom.SelectedIndex == 1 ? true : (bool?)null)));
            //if (t!=null)
            Grid.ItemsSource = t;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.SelectedIndex == -1) MessageBox.Show("هیج موردی انتخاب نشده");
            else if ((Grid.SelectedItem as Evaluation).IsContractorMeeting == true)
            {
                NavigationHandler.NavigateToPageWithMode(this, new Evaluation1_1((Evaluation)Grid.SelectedItem), NavigationMethod.EditMode, SubSystem.Tendering);
            }
            else
            {
                NavigationHandler.NavigateToPageWithMode(this, new PriceEvaluation((Evaluation)Grid.SelectedItem), NavigationMethod.EditMode, SubSystem.Tendering);
            }
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null)
            {
                ErrorHandler.NotifyUser(Errors.NotSearched);
                return;
            }
            NavigationHandler.NavigateToPage(this, new RTM.Report.GenralRep.Evaluation_Viewer((List<Evaluation>)(Grid.ItemsSource)));
        }
    }
}

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
    /// Interaction logic for Evaluation1Search.xaml
    /// </summary>
    public partial class Evaluation1Search : Page
    {
        public Evaluation1Search()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Grid.ItemsSource = null;
            //datepicker.SelectedDate = DateTime.Now;
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            TitleTxt.Text = "";
            Grid.ItemsSource = null;
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.SelectedIndex == -1) MessageBox.Show("هیج موردی انتخاب نشده");
            else
            {
                NavigationHandler.NavigateToPageWithMode(this, new Evaluation1((Evaluation)Grid.SelectedItem),NavigationMethod.ViewMode,SubSystem.Tendering);
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            var tx = (TitleTxt.Text.Trim()=="")?null :TitleTxt.Text;
            var t= DataManagement.SearchEvaluations(null,null,null,tx,datepicker.SelectedDate,datePicker1.SelectedDate,false,true,null  );
            if (t !=null)
                Grid.ItemsSource = t;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.SelectedIndex == -1) MessageBox.Show("هیج موردی انتخاب نشده");
            else
            {
                NavigationHandler.NavigateToPageWithMode(this, new Evaluation1((Evaluation)Grid.SelectedItem), NavigationMethod.EditMode, SubSystem.Tendering);
            }
        }
    }
}

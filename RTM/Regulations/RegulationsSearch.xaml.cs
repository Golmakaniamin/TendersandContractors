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

namespace RTM.Regulations
{
    /// <summary>
    /// Interaction logic for RegulationsPage2.xaml
    /// </summary>
    public partial class RegulationsSearch : Page
    {
        public Regulation CurrentRegulation { set; get; }
        public RegulationsSearch()
        {
            CurrentRegulation = new Regulation();
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ActingCom.ItemsSource = DataManagement.RetrieveOrganizationChart();
            ReferenceCom.ItemsSource = DataManagement.RetrieveIssuingReferences();
            RefreshBtn_Click(sender, e);
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            
            Grid.ItemsSource = DataManagement.SearchRegulations(CurrentRegulation);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var item = Grid.SelectedItem as Regulation;
            if (item == null)
            {
                ErrorHandler.ShowErrorMessage("موردی انتخاب نشده است.");
                return;
            }
            else
            {
                NavigationHandler.NavigateToPageWithMode(this, new RTM.Regulations.RegulationsPage1(item), NavigationMethod.ViewMode, SubSystem.Regulation);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var item = Grid.SelectedItem as Regulation;
            if (item == null)
            {
                ErrorHandler.ShowErrorMessage("موردی انتخاب نشده است.");
                return;
            }
            else
            {
                NavigationHandler.NavigateToPageWithMode(this, new RTM.Regulations.RegulationsPage1(item), NavigationMethod.EditMode, SubSystem.Regulation);
            }
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            TypeCom.SelectedIndex = -1;
            CurrentRegulation.Type = "";
            GroupCom.SelectedIndex = -1;
            CurrentRegulation.Group = "";
            ReferenceCom.SelectedIndex = -1;
            CurrentRegulation.ActingReferenceId = 0;
            ActingCom.SelectedIndex = -1;
            CurrentRegulation.IssuingReferenceId = 0;
            datePicker1.Text = "";
            TitleTxt.Text = "";
            CurrentRegulation.Title = "";
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource==null)
            {
                ErrorHandler.NotifyUser(Errors.NotSearched);
                return;
            }
            NavigationHandler.NavigateToPage(this,new RTM.Report.GenralRep.Regulation_Viewer((List<Regulation>)(Grid.ItemsSource)));
        }
    }
}

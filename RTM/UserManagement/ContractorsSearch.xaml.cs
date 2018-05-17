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

namespace RTM.UserManagement
{
    /// <summary>
    /// Interaction logic for ContractorsSearch.xaml
    /// </summary>
    public partial class ContractorsSearch : Page
    {
        public ContractorsSearch()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            
            var name = (NameTxt.Text.Trim() == "") ? null : NameTxt.Text;
            var national = (NationalTxt.Text.Trim() == "") ? null : NationalTxt.Text;
            bool? iscontractor =null;
            bool? isconsultant = null;
            if (Service.SelectedIndex == 0)
                iscontractor = true;
            else if (Service.SelectedIndex == 1)
                isconsultant = true;
            else
                iscontractor = isconsultant = null;
            var t = DataManagement.SearchContractors(name,national,null,iscontractor,isconsultant,FieldCom.Text,BaseCom.Text);
            Grid.ItemsSource = t;
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            NameTxt.Text = "";
            National.Text = "";
            Service.SelectedIndex = -1;
            Grid.ItemsSource = null;
            FieldCom.SelectedIndex = -1;
            BaseCom.SelectedIndex = -1;
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.SelectedIndex == -1)
            {
                ErrorHandler.ShowErrorMessage("موردی انتخاب نشده است");
                return;
            }
            var x = Grid.SelectedItem as Contractor;
            NavigationHandler.NavigateToPageWithMode(this, new Contractors(x), NavigationMethod.ViewMode, SubSystem.Tendering);
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.SelectedIndex == -1)
            {
                ErrorHandler.ShowErrorMessage("موردی انتخاب نشده است");
                return;
            }
            var x = Grid.SelectedItem as Contractor;
            NavigationHandler.NavigateToPageWithMode(this, new Contractors(x), NavigationMethod.EditMode, SubSystem.Tendering);
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null)
            {
                ErrorHandler.NotifyUser(Errors.NotSearched);
                return;
            }
            NavigationHandler.NavigateToPage(this, new RTM.Report.GenralRep.Contractor_Viewer((List<Contractor>)(Grid.ItemsSource)));
        }
    }
}

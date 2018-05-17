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

namespace RTM.Contracts
{
    /// <summary>
    /// Interaction logic for AccessToTendersManagement.xaml
    /// </summary>
    public partial class AccessToTendersManagement : Page
    {
        public AccessToTendersManagement()
        {
            InitializeComponent();
        }

        private void RefreshTenderBtn_Click(object sender, RoutedEventArgs e)
        {
            TenderNomTxt.Text = ""; TitleTxt.Text = ""; TenderDateDP.Text = "";
            ContractSearchGrid.ItemsSource = null;
            
        }

        private void RefreshUserBtn_Click(object sender, RoutedEventArgs e)
        {
            FirstNameTxt.Text = ""; LastNameTxt.Text = ""; OrgCom.SelectedIndex = -1; PositionTxt.SelectedIndex = -1;
            var t = DataManagement.HasAccessToContract(ContractSearchGrid.SelectedItem as Contract);
            SearchUserGrid.ItemsSource = null;
        }



        private void SearchTenderBtn_Click(object sender, RoutedEventArgs e)
        {
            ContractSearchGrid.ItemsSource = DataManagement.SearchContracts("", TenderNomTxt.Text, null, TenderDateDP.SelectedDate, null, TitleTxt.Text);
        }

  
        

        private void ShowInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPageWithMode(this, new ContractsCreate(ContractSearchGrid.SelectedItem as Contract), NavigationMethod.ViewMode, SubSystem.Contract);
        }

        private void SearchUserBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchUserGrid.ItemsSource = DataManagement.SearchUsers(FirstNameTxt.Text == "" ? null : FirstNameTxt.Text, LastNameTxt.Text == "" ? null : LastNameTxt.Text, PositionTxt.Text == "" ? null : PositionTxt.Text, OrgCom.Text == "" ? null : OrgCom.Text);
        }


        private void AddToListBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in SearchUserGrid.SelectedItems)
            {
                bool found = false;
                foreach (var item2 in ChosenUsersGrid.Items)
                {
                    if((item as User).UserId == (item2 as User).UserId )
                    found = true;
                }
                if(!found)
                    ChosenUsersGrid.Items.Add(item);
            }   
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            DataManagement.UpdateContractAccess(ChosenUsersGrid.Items.OfType<User>().ToList(), ContractSearchGrid.SelectedItem as Contract);
            ErrorHandler.NotifyUser(Errors.Saved);
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            ChosenUsersGrid.Items.Remove(ChosenUsersGrid.SelectedItem);
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            PositionTxt.ItemsSource = DataManagement.RetrievePositions();
            OrgCom.ItemsSource = DataManagement.RetrieveOrganizationChart();

        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ContractSearchGrid.SelectedIndex==-1)
                return;
            var res = DataManagement.RetrieveContractAccess(ContractSearchGrid.SelectedItem as Contract);
            ChosenUsersGrid.Items.Clear();
            foreach (var item in res)
            {
                ChosenUsersGrid.Items.Add(item);
            }
        }
    }
}

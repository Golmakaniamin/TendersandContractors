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
    
    /// </summary>
    public partial class SelfStateManagment : Page
    {
        public SelfStateManagment()
        {
            InitializeComponent();
        }

        private void SelfState_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshGrids();
        }

        private void RefreshGrids()
        {
            dataGrid.ItemsSource = DataManagement.RetrieveContractorsInWaitingList();
            dataGrid2.ItemsSource = DataManagement.RetrieveApprovedContractors();
        }
        private void ShowInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedIndex != -1)
                NavigationHandler.NavigateToPageWithMode(this, new UserManagement.Contractors(dataGrid.SelectedItem as Contractor),NavigationMethod.EditMode,SubSystem.Tendering);
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedIndex != -1)
            {
                DataManagement.ToggleContractorState(dataGrid.SelectedItem as Contractor);
                RefreshGrids();
            }
        }

        private void ChosenShowInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid2.SelectedIndex != -1)
                NavigationHandler.NavigateToPageWithMode(this, new UserManagement.Contractors(dataGrid2.SelectedItem as Contractor), NavigationMethod.EditMode, SubSystem.Tendering);
        }

        private void BackToTopGridBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid2.SelectedIndex != -1)
            {
                DataManagement.ToggleContractorState(dataGrid2.SelectedItem as Contractor);
                RefreshGrids();
            }
        }



       
    }
}

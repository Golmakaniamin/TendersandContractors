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

namespace RTM.UserManagment
{
    /// <summary>
    /// Interaction logic for UserMainMenu.xaml
    /// </summary>
    public partial class UserMainMenu : Page
    {
        public UserMainMenu()
        {
            InitializeComponent();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPage(this, "UserManagement/NewUser.xaml");
        }

        private void FindUserBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPage(this, "UserManagement/FindUser.xaml");
        }

        private void OrgChartBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPage(this, "UserManagement/OrganizationalChart.xaml");
        }


    }
}

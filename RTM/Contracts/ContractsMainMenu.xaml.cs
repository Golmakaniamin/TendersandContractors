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
    /// Interaction logic for ContractsMainMenu.xaml
    /// </summary>
    public partial class ContractsMainMenu : Page
    {
        public ContractsMainMenu()
        {
            InitializeComponent();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UserData.CurrentUser.ManagingPaymentDraft == true)
                NavigationHandler.NavigateToPageWithMode(this, new ContractsCreate(), NavigationMethod.NewMode, SubSystem.Contract);
            else
                ErrorHandler.NotifyUser("دسترسی به این بخش امکان پذیر نمی باشد");
        }

        private void SearchForEditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UserData.CurrentUser.ManagingPaymentDraft == true || UserData.CurrentUser.PaymentDraftCommittee == true || UserData.CurrentAccessRight.ContractRead)
                NavigationHandler.NavigateToPage(this, new ContractsSearch());
            else
                ErrorHandler.NotifyUser("دسترسی به این بخش امکان پذیر نمی باشد");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (UserData.CurrentUser.ManagingContractAccess == true) // ezafe kardane dastresi jadid baraye modiriate dastresi gharardad
                NavigationHandler.NavigateToPage(this, new AccessToTendersManagement());
            else
                ErrorHandler.NotifyUser("دسترسی به این بخش امکان پذیر نمی باشد");
        }
    }
}

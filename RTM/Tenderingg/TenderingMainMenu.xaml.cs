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
using RTM.UserManagement;

namespace RTM.Tenderingg
{
    /// <summary>
    /// Interaction logic for TenderingMainMenu.xaml
    /// </summary>
    public partial class TenderingMainMenu : Page
    {
        public TenderingMainMenu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            RTM.Classes.NavigationHandler.NavigateToPageWithMode(this, new Evaluation1(), NavigationMethod.NewMode, SubSystem.Tendering);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            RTM.Classes.NavigationHandler.NavigateToPage(this, new Evaluation1Search());
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (!UserData.CurrentAccessRight.TenderingWrite)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            RTM.Classes.NavigationHandler.NavigateToPageWithMode(this, new Evaluation1_1(),NavigationMethod.NewMode,SubSystem.Tendering);
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            RTM.Classes.NavigationHandler.NavigateToPage(this, new Evaluation2Search());
        }

        private void ContractorsBtn_Click(object sender, RoutedEventArgs e)
        {
            RTM.Classes.NavigationHandler.NavigateToPageWithMode(this,new UserManagement.Contractors(), NavigationMethod.NewMode, SubSystem.Tendering);
        }

        private void ContractorsSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            RTM.Classes.NavigationHandler.NavigateToPage(this, "UserManagement/ContractorsSearch.xaml");
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
   
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void button5_Click_1(object sender, RoutedEventArgs e)
        {
            RTM.Classes.NavigationHandler.NavigateToPage(this,new RTM.Tendering1.SearchRequestInformation());
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            RTM.Classes.NavigationHandler.NavigateToPage(this, new RTM.Tendering1.SearchTenderInformation());
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPageWithMode(this, new  RTM.Tendering1.UI1choosingCntrctrReq(), NavigationMethod.NewMode, SubSystem.Tendering);
        }

        private void SelfStateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!UserData.CurrentAccessRight.ContractWrite)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            NavigationHandler.NavigateToPage(this, new RTM.Tenderingg.SelfStateManagment());
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            if (!UserData.CurrentAccessRight.TenderingWrite)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            NavigationHandler.NavigateToPage(this, new RTM.Tenderingg.PriceEvaluation());
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPageWithMode(this, new RTM.Notices.NoticeRequest(),NavigationMethod.NewMode,SubSystem.Tendering);
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPage(this, new RTM.Notices.NoticeSearch());
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPage(this, new RTM.Tenderingg.Web_DocContractor());
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPage(this, new RTM.Tendering1.TenderAdvancedSearch());
        }
    }
}

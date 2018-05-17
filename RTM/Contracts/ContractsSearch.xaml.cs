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
    /// Interaction logic for ContractsSearchForEdit.xaml
    /// </summary>
    public partial class ContractsSearch : Page
    {
        public Regulation CurrentContract {set;get;}
        public ContractsSearch()
        {
            CurrentContract = new Regulation();
            InitializeComponent();
        }

        private void TitleTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ContractNumberTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

            Grid.ItemsSource = DataManagement.SearchContracts(TenderNumberTxt.Text, ContractNumberTxt.Text, (int?)TypeCom.SelectedValue, FromDate.SelectedDate, ToDate.SelectedDate, TitleTxt.Text,null,null,(int?)ContractorsCom.SelectedValue,(int?)ConsultantCom.SelectedValue);
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            TypeCom.SelectedIndex = ContractorsCom.SelectedIndex = ConsultantCom.SelectedIndex = -1;
            FromDate.SelectedDate = ToDate.SelectedDate = null;
            TenderNumberTxt.Text = ContractNumberTxt.Text = TitleTxt.Text = "";
            Grid.ItemsSource = null;
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            TypeCom.ItemsSource = DataManagement.RetrieveContractType();
            ContractorsCom.ItemsSource = DataManagement.SearchContractors(null, null, null, null, null).OrderBy(s=>s.CompanyName);
            ConsultantCom.ItemsSource = DataManagement.SearchContractors(null, null, null, null, null).OrderBy(s => s.CompanyName);
            RefreshBtn_Click(sender, e);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.SelectedItem != null)
            {
                if (Grid.SelectedItem != null)
                {
                    if (UserData.CurrentUser.ManagingPaymentDraft == true || UserData.CurrentUser.PaymentDraftCommittee == true || DataManagement.HasAccessToContract(Grid.SelectedItem as Contract))
                        NavigationHandler.NavigateToPageWithMode(this, new ContractsCreate(Grid.SelectedItem as Contract), NavigationMethod.ViewMode, SubSystem.Contract);
                    else
                        ErrorHandler.NotifyUser("دسترسی به این بخش امکان پذیر نمی باشد");

                }

            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.SelectedItem != null)
            {
                if (UserData.CurrentUser.ManagingPaymentDraft == true || UserData.CurrentUser.PaymentDraftCommittee == true)
                    NavigationHandler.NavigateToPageWithMode(this, new ContractsCreate(Grid.SelectedItem as Contract), NavigationMethod.EditMode, SubSystem.Contract);
                else
                    ErrorHandler.NotifyUser("دسترسی به این بخش امکان پذیر نمی باشد");
                
            }
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null)
            {
                ErrorHandler.NotifyUser(Errors.NotSearched);
                return;
            }
            NavigationHandler.NavigateToPage(this,new Report.GenralRep.Contract_Viewer((List<Contract>)(Grid.ItemsSource)));
        }
    }
}

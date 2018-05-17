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
namespace RTM.Tendering1
{
    /// <summary>
    /// Interaction logic for TenderAdvancedSearch.xaml
    /// </summary>
    public partial class TenderAdvancedSearch : Page
    {
        public TenderAdvancedSearch()
        {
            InitializeComponent();
        }

        private void comboBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox4.SelectedIndex == 0)
            {
                ContractorCom.IsEnabled = true;
            }
            else
            {
                ContractorCom.IsEnabled = false;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TenderTypeCom.ItemsSource = new List<string> { "عمومي يک مرحله اي", "عمومي دو مرحله اي", "محدود يک مرحله اي", "محدود دو مرحله اي", "ترک تشريفات", "انحصاري", "بين المللي" };
            RequiredField.ItemsSource = new List<string> { "ساختمان", "آب", "راه و ترابري", "صنعت و معدن", "نيرو", "تاسيسات و تجهيزات", "کاوشهاي زميني", "ارتباطات", "کشاورزي", "خدمات", "آثار باستاني" };
            if (SuperVisionCom.ItemsSource == null || RequestUnitCom.ItemsSource == null)
                RequestUnitCom.ItemsSource = SuperVisionCom.ItemsSource = DataManagement.RetrieveOrganizationChart();
            if (ContractorCom.ItemsSource == null)
                ContractorCom.ItemsSource = DataManagement.SearchContractors(null, null, null, null, null).OrderBy(s => s.CompanyName);
            if (StageCom.Items.Count == 0)
                StageCom.ItemsSource = DataManagement.RetrieveStages();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            bool type = false;
            if (TypeCom.SelectedIndex == 0)
                type = false;
            else
                type = true;

            DataGrid.ItemsSource = DataManagement.SearchTenderings(TenderTypeCom.Text, TenderTitleTxt.Text, TenderSystemCodeTxt.Text, null, ReqNum.Text, FromDateTender.SelectedDate, ToDateTender.SelectedDate, FromDateReq.SelectedDate, ToDateReq.SelectedDate, FromDateRes.SelectedDate, ToDateRes.SelectedDate, (int?)RequestUnitCom.SelectedValue, (int?)SuperVisionCom.SelectedValue, RequiredField.Text, (bool?)(comboBox4.SelectedIndex == 0 ? false :(comboBox4.SelectedIndex == 1? true:(bool?)null)), (int?)ContractorCom.SelectedValue,type,(int?)StageCom.SelectedValue);
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid.ItemsSource == null)
            {
                ErrorHandler.NotifyUser(Errors.NotSearched);
                return;
            }
            NavigationHandler.NavigateToPage(this, new RTM.Report.GenralRep.Tender_Viewer((DataGrid.ItemsSource.Cast<Tendering>().ToList())));
        }
    }
}

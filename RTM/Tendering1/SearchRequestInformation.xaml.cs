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
    /// Interaction logic for SearchRequestInformation.xaml
    /// </summary>
    public partial class SearchRequestInformation : Page
    {
        public ContractorRequest CurrentReq { set; get; }
        public SearchRequestInformation()
        {
            CurrentReq = new ContractorRequest() {ProjectTitle = "", RequestNumber="" };
            InitializeComponent();
        }


        private void DescriptionTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DisqualifiedRadio_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid.ItemsSource = DataManagement.SearchContractorRequest(CurrentReq);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationHandler.NavigateToPageWithMode(this, new UI1choosingCntrctrReq(Grid.SelectedItem as ContractorRequest), NavigationMethod.EditMode, SubSystem.Tendering);
        }

        private void Grid_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            Header.CurrentRequest = (Grid.SelectedItem as ContractorRequest);
        }
    }
}

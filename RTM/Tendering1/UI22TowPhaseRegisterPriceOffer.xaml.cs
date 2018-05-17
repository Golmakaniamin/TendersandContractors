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
    /// Interaction logic for UI22TowPhaseRegisterPriceOffer.xaml
    /// </summary>
    public partial class UI22TowPhaseRegisterPriceOffer : Page
    {
        public Tendering CurrentTendering { set; get; }
        private List<Bid> list = new List<Bid>();

        public UI22TowPhaseRegisterPriceOffer(Tendering t)
        {
            CurrentTendering = t;
            InitializeComponent();
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Grid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            DataManagement.UpdateBids(list, CurrentTendering);
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            Header.CurrentRequest = DataManagement.RetrieveTenderingContractorRequest(CurrentTendering);
            list = DataManagement.RetrieveBids(CurrentTendering);
            dataGrid.ItemsSource = list;
            dataGrid.Items.Refresh();
        }

    }
}

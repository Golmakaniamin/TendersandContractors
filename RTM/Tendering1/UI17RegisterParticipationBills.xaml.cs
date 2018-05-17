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
    /// Interaction logic for UI17RegisterParticipationBills.xaml
    /// </summary>
    public partial class UI17RegisterParticipationBills : Page
    {
        private List<Warranty> list = new List<Warranty>();
        public Tendering CurrentTendering { set; get; }

        public UI17RegisterParticipationBills(Tendering c)
        {
            CurrentTendering = c;
            InitializeComponent();
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            ChooseCom.ItemsSource = DataManagement.RetrieveContractorsWhoSubmitPacket(CurrentTendering);

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            list.Remove((dataGrid.SelectedItem as Warranty));
            dataGrid.ItemsSource = list;
            dataGrid.Items.Refresh();
        }

        private void ChoseCntrctrCom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            list = DataManagement.RetrieveWarranty((ChooseCom.SelectedItem as Contractor), CurrentTendering, WarrantyTypes.Stock);
            dataGrid.ItemsSource = list;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataManagement.UpdateWarranty(list, CurrentTendering, (ChooseCom.SelectedItem as Contractor), WarrantyTypes.Stock);
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["SuccessfulSave"]);
                DataManagement.UpdateTenderingStage(CurrentTendering, Stages.Warranty);
            }
            catch
            {
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["FailedSave"]);
            }
        }

    }
}

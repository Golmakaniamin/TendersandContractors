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
    /// Interaction logic for ContractorSelection.xaml
    /// </summary>
    public partial class ContractorSelection : Page
    {
        public Tendering CurrentTendring { set; get; }
        public ContractorSelection(Tendering x)
        {
            CurrentTendring = x;
            InitializeComponent();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid2.SelectedIndex != -1)
                DataGrid2.Items.Remove(DataGrid2.SelectedItem);
        }

        private void searchContractor_Click(object sender, RoutedEventArgs e)
        {
            var name = (CompanyNameTxt.Text.Trim() == "") ? null : CompanyNameTxt.Text;
            var social = (SocialNumberTxt.Text.Trim() == "") ? null : SocialNumberTxt.Text;
            var t = DataManagement.SearchContractors(name, social, null, null, null);
            DataGrid1.ItemsSource = t;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedIndex != -1 && DataGrid2.Items.IndexOf(DataGrid1.SelectedItem) == -1)
            {
                var x = from items in DataGrid2.Items.Cast<Contractor>()
                        where items.ContractorId == (DataGrid1.SelectedItem as Contractor).ContractorId
                        select items;
                if (x.Count() > 0)
                    return;
                DataGrid2.Items.Add(DataGrid1.SelectedItem);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var t = DataManagement.RetrieveContractorShortList(CurrentTendring);
            DataGrid2.Items.Clear();
            if (t == null)
                return;
            foreach(var item in t)
            {
                DataGrid2.Items.Add(item);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if(UserData.CurrentAccessRight.TenderingWrite == false && CurrentTendring.RequestPermanentCheck == true)
            {
                ErrorHandler.ShowErrorMessage(Errors.FailedSave);
                return;
            }
            DataManagement.UpdateContractorShortList(CurrentTendring,DataGrid2.Items.Cast<Contractor>().ToList());
            ErrorHandler.NotifyUser(Errors.Saved);
        }
    }
}

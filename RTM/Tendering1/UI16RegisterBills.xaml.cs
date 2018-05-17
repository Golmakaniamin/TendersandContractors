﻿using System;
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
    /// Interaction logic for UI16RegisterBills.xaml
    /// </summary>
    public partial class UI16RegisterBills : Page
    {
        private List<Warranty> list = new List<Warranty>();
        public Tendering CurrentTendering { set; get; }

        public UI16RegisterBills(Tendering c)
        {
            CurrentTendering = c;
            InitializeComponent();
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Grid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            list.Remove((dataGrid.SelectedItem as Warranty));
            dataGrid.ItemsSource = list;
            dataGrid.Items.Refresh();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataManagement.UpdateWarranty(list, CurrentTendering, (ChooseCom.SelectedItem as Contractor), WarrantyTypes.Draft);
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["SuccessfulSave"]);
                DataManagement.UpdateTenderingStage(CurrentTendering, Stages.Warranty);
            }
            catch
            {
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["FailedSave"]);
            }
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            ChooseCom.ItemsSource = DataManagement.RetrieveContractorsWhoSubmitPacket(CurrentTendering);
        }

        private void ChooseCom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            list = DataManagement.RetrieveWarranty((ChooseCom.SelectedItem as Contractor), CurrentTendering, WarrantyTypes.Draft);
            dataGrid.ItemsSource = list;
        }
    }
}

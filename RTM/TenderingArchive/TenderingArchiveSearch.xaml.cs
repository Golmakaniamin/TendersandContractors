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

namespace RTM.TenderingArchive
{
    /// <summary>
    /// Interaction logic for TenderingArchiveSearch.xaml
    /// </summary>
    public partial class TenderingArchiveSearch : Page
    {
        public TenderingArchiveSearch()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TenderTypeCom.ItemsSource = new List<string> { "عمومي يک مرحله اي", "عمومي دو مرحله اي", "محدود يک مرحله اي", "محدود دو مرحله اي", "ترک تشريفات", "انحصاري", "بين المللي" };
        }


        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            TenderTypeCom.SelectedIndex = -1;
            TenderSystemCodeTxt.Text = "";
            RequestNumber.Text = "";
            TenderTitleTxt.Text = "";
            string tt = (TenderTypeCom.SelectedIndex == -1) ? "" : TenderTypeCom.SelectedItem.ToString();
            Grid.ItemsSource = null;
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            //NavigationHandler.NavigateToPage(this, new TenderingArchiveMain());
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            string tt = (TenderTypeCom.SelectedIndex == -1) ? "" : TenderTypeCom.SelectedItem.ToString();
            Grid.ItemsSource = DataManagement.SearchTenderings(tt, TenderTitleTxt.Text, TenderSystemCodeTxt.Text, RequestNumber.Text,RequestNumber.Text);
        }

        private void OpenBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (Grid.SelectedIndex != -1)
            {
                var t = Grid.SelectedItem as Tendering;
                NavigationHandler.NavigateToPage(this, new RTM.TenderingArchive.TenderingArchiveMain(t));
            }
        }
    }
}

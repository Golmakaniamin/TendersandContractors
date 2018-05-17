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

namespace RTM.Tenderingg
{
    /// <summary>
    /// Interaction logic for Web_DocContractor.xaml
    /// </summary>
    public partial class Web_DocContractor : Page
    {
        public Web_DocContractor()
        {
            InitializeComponent();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            var t = DataManagement.SearchTenderings("", "", TenderNumberTxt.Text, "", "").FirstOrDefault();
          
            if (t != null && TenderNumberTxt.Text != "")
            {
                var c = DataManagement.RetrieveTenderingContractorRequest(t);
                Header.CurrentRequest = c;
                DataGrid1.ItemsSource = DataManagement.RetrieveTenderingDownloadFiles(t);
                ErrorHandler.NotifyUser(Errors.FoundTendering);
            }
            else
            {
                ErrorHandler.ShowErrorMessage(Errors.NotFoundTendering);
                //Header.CurrentRequest = null;
                DataGrid1.ItemsSource = null;
            }

        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.ItemsSource == null)
            {
                ErrorHandler.ShowErrorMessage("ابتدا مناقصه را جستجو کنید");
                return;
            }
            NavigationHandler.NavigateToPage(this,new Report.GenralRep.Download_Viewer((List<TenderingFileDownload>)(DataGrid1.ItemsSource)));
        }
    }
}

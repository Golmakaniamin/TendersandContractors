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

namespace RTM.Notices
{
    /// <summary>
    /// Interaction logic for NoticeSearch.xaml
    /// </summary>
    public partial class NoticeSearch : Page
    {
        public List<Tendering> list = new List<Tendering>();
        
        public NoticeSearch()
        {
            InitializeComponent();
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            list = DataManagement.SearchTenderings("", TenderTitleTxt.Text, TenderSystemCodeTxt.Text,"", RequestNumber.Text, null, null, null, null, null, null, (RequestUnitCom.SelectedIndex == -1) ? null : (int?)RequestUnitCom.SelectedValue, null, "", null, null, true);
            using (var en = new RTMEntities())
            {
                var t = from tenders in list
                        from reqs in en.ContractorRequests
                        where
                            tenders.ContractorRequestId == reqs.ContractorRequestId
                        select new
                        {
                            RequestNumber = reqs.RequestNumber,
                            TenderingId = tenders.TenderingId,
                            NoticeNumber = tenders.TenderingNumber,
                            ProjectTitle = reqs.ProjectTitle,
                            RequestingUnit = reqs.RequestingUnit,

                        };

                Grid.ItemsSource = t;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RequestUnitCom.ItemsSource =  DataManagement.RetrieveOrganizationChart();
        }

        private void OpenBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (Grid.SelectedItem == null)
                return;
            dynamic o = Grid.SelectedItem;
            int tenderingId = o.TenderingId;
            Tendering t = DataManagement.SearchTenderings("", "", "", tenderingId.ToString(), "", null, null, null, null, null, null, null, null, "", null, null,true).FirstOrDefault();
            NavigationHandler.NavigateToPageWithMode(this, new RTM.Notices.NoticeRequest(t,DataManagement.RetrieveTenderingContractorRequest(t)), NavigationMethod.EditMode, SubSystem.Tendering);
        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            RequestUnitCom.SelectedIndex = -1;
            TenderSystemCodeTxt.Text = TenderTitleTxt.Text = RequestNumber.Text = "";
        }
    }
}

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
using RTM.Tendering1;
using RTM.Classes;

namespace RTM.TenderingArchive
{
    /// <summary>
    /// Interaction logic for TenderingArchiveMain.xaml
    /// </summary>
    public partial class TenderingArchiveMain : Page
    {
        public Tendering CurrentTendering;
        public List<TenderingDocument> DocTypes { set; get; }
        public List<UI5GridItems> GridList = new List<UI5GridItems>();
        public TenderingArchiveMain(Tendering t)
        {
            try
            {
                DocTypes = (from items in (new RTMEntities()).TenderingDocuments   select items).ToList();
            }
            catch (System.Exception ex)
            {

            }
            CurrentTendering = t;
            InitializeComponent();
        }
        private void ViewFile_Click(object sender, RoutedEventArgs e)
        {
            var o = Grid.SelectedItem as UI5GridItems;
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, (TenderingIndex)o.DocumentIndex, null, o.Version, this.layoutRoot);
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            var o = Grid.SelectedItem as UI5GridItems;
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, (TenderingIndex)o.DocumentIndex, null, o.Version, this.layoutRoot);
            Grid.Items.Refresh();
        }

        private void DeleteFile_Click(object sender, RoutedEventArgs e)
        {
            var o = Grid.SelectedItem as UI5GridItems;
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, (TenderingIndex)o.DocumentIndex, null, o.Version, this.layoutRoot);
            GridList.Remove(o);
            UpdateGridList();

            Grid.Items.Refresh();
        }
        private void UpdateGridList()
        {
            var en = new RTMEntities();
            var result = from file in en.TenderingDocumentFiles
                         from rel in en.TenderingDocumentFileRelations
                         from doc in en.TenderingDocuments
                         where file.TenderingDocumentFileId == rel.TenderingDocumentFileId &&
                               rel.TenderingDocumentId == doc.TenderingDocumentId &&
                               rel.TenderingId == CurrentTendering.TenderingId
                               orderby doc.DocumentIndex, file.AttachedDate descending
                         select new UI5GridItems
                         {
                             TenderingDocumentId = rel.TenderingDocumentId,
                             Version = file.Version,
                             AttachedDate = file.AttachedDate,
                             DocumentIndex = doc.DocumentIndex
                         };
            GridList = result.ToList();
            Grid.ItemsSource = GridList;
            Grid.Items.Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Header.CurrentRequest = DataManagement.RetrieveTenderingContractorRequest(CurrentTendering);
            UpdateGridList();
        }

        private void Header_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            
            //DataGrid temp = new DataGrid();
            //temp.ItemsSource = Grid.ItemsSource;
            //temp.Width = 1024;
            //PrintDialog a = new PrintDialog();
            //a.ShowDialog();
            ////Grid.Height = 10000;
            //a.PrintVisual(temp, "grid");
            UpdateGridList();
        }
    }
}

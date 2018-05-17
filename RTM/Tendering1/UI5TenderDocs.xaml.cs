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
using System.Threading;

namespace RTM.Tendering1
{
    /// <summary>
    /// Interaction logic for UI5.xaml
    /// </summary>
    /// 

    public partial class UI5TenderDocs : Page
    {
        public Tendering CurrentTendering { set; get; }
        public List<TenderingDocument> DocTypes { set; get; }
        public List<UI5GridItems> GridList = new List<UI5GridItems>();
        public UI5TenderDocs()
        {
            InitializeComponent();
        }
        public UI5TenderDocs(Tendering t)
        {
            try
            {
                DocTypes = (from items in (new RTMEntities()).TenderingDocuments where items.IsDoc ==true select items).ToList();
            }
            catch (System.Exception ex)
            {

            }
            CurrentTendering = t;
            InitializeComponent();
        }


        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                UpdateGridList();
                
                DocTypesCom.ItemsSource = DocTypes;
                FilingManager.TransactionFinished += new FilingJobDone(FilingManager_TransactionFinished);
            }
            catch (System.Exception ex)
            {

            }

            Header.CurrentRequest = DataManagement.RetrieveTenderingContractorRequest(CurrentTendering);
        }

        void FilingManager_TransactionFinished()
        {
            UpdateGridList();
        }
        private void UpdateGridList()
        {
            var en = new RTMEntities();
            var result = from file in en.TenderingDocumentFiles
                         from rel in en.TenderingDocumentFileRelations
                         from doc in en.TenderingDocuments
                         where file.TenderingDocumentFileId == rel.TenderingDocumentFileId &&
                               rel.TenderingDocumentId == doc.TenderingDocumentId &&
                               rel.TenderingId == CurrentTendering.TenderingId &&
                               doc.IsDoc == true
                         select new UI5GridItems
                         {
                             TenderingDocumentId = rel.TenderingDocumentId,
                             Version = file.Version,
                             AttachedDate = file.AttachedDate,
                             DocumentIndex = doc.DocumentIndex,
                             FileId = file.TenderingDocumentFileId
                         };
            GridList = result.ToList();
            Grid.ItemsSource = GridList;
            Grid.Items.Refresh();
        }
        private void ViewFile_Click(object sender, RoutedEventArgs e)
        {
            var o = Grid.SelectedItem as UI5GridItems;
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, (TenderingIndex)o.DocumentIndex, null, o.Version, this.layoutRoot);
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (button2.IsEnabled == false)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            if (!UserData.CurrentAccessRight.TenderingWrite)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            var o = Grid.SelectedItem as UI5GridItems;
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, (TenderingIndex)o.DocumentIndex, null, o.Version, this.layoutRoot);
            Grid.Items.Refresh();
        }

        private void DeleteFile_Click(object sender, RoutedEventArgs e)
        {
            if (button2.IsEnabled == false)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            if (!UserData.CurrentAccessRight.TenderingDelete)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            var o = Grid.SelectedItem as UI5GridItems;
            //FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, (TenderingIndex)o.DocumentIndex, null, o.Version, this.layoutRoot);
            FilingManager.DeleteTenderingFile(o.FileId, this.layoutRoot);
            GridList.Remove(o);
            //UpdateGridList();
            
            Grid.Items.Refresh();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DocTitles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = e.AddedItems;
        }

        private void AddFileBtn_Click(object sender, RoutedEventArgs e)
        {
            if (VersionTxt.Text.Trim() != "")
            {
                FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, (TenderingIndex)DocTypesCom.SelectedValue, null, VersionTxt.Text, this.layoutRoot);
                if (CurrentTendering.TenderingType == "محدود يک مرحله اي" || CurrentTendering.TenderingType == "محدود دو مرحله اي" || CurrentTendering.TenderingType == "ترک تشريفات" || CurrentTendering.TenderingType == "انحصاري")
                    DataManagement.UpdateTenderingStage(CurrentTendering, Stages.Notice);
                else
                    DataManagement.UpdateTenderingStage(CurrentTendering, Stages.Documents);
                UpdateGridList();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            UpdateGridList();
        }
    }
    public class UI5GridItems
    {
        public int TenderingDocumentId { set; get; }
        public string Version { set; get; }
        public DateTime? AttachedDate { set; get; }
        public int? DocumentIndex { set; get; }
        public int FileId { set; get; }
    }
}

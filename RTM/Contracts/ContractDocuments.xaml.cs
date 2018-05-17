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

namespace RTM.Contracts
{
    /// <summary>
    /// Interaction logic for ContractDocuments.xaml
    /// </summary>
    public partial class ContractDocuments : Page
    {
        public List<ContractDocument> DocTypes { set; get; }
        public List<ContractFilesGridItem> GridList = new List<ContractFilesGridItem>();
        public Contract CurrentContract { set; get; }
        public ContractDocuments()
        {
            InitializeComponent();
        }

        public ContractDocuments( Contract x )
        {
            try
            {
                DocTypes = (from items in (new RTMEntities()).ContractDocuments where items.DocumentIndex>3 select items).ToList();
            }
            catch (System.Exception ex)
            {

            }
            CurrentContract = x;
            InitializeComponent();
           
        }
        private void UpdateGridList()
        {
            var en = new RTMEntities();
            var result = from file in en.ContractFiles
                         from rel in en.ContractDocFileRelations
                         from doc in en.ContractDocuments
                         where file.FileId == rel.FileId &&
                               rel.ContractDocId == doc.ContractDocumentId  &&
                               doc.DocumentIndex >3
                               && rel.ContractId == CurrentContract.Contractid

                         select new ContractFilesGridItem
                         {
                             FileId = file.FileId,
                             Version = file.Version,
                             AttachedDate = file.AttachedDate,
                             DocumentIndex = doc.DocumentIndex
                         };
            GridList = result.ToList();
            Grid1.ItemsSource = GridList;
            Grid1.Items.Refresh();
        }
        private void SuperVisionCom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddFileBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentContract.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("سند به ثبت نهایی رسیده است");
                return;
            }
            if (VersionTxt.Text == "")
            {
                ErrorHandler.NotifyUser("عنوان نسخه وارد نشده است");
                return;
            }
            if (!UserData.CurrentAccessRight.ContractWrite)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            FilingManager.UploadContractFile(CurrentContract.Contractid, (ContractIndex)DocTitles.SelectedValue, VersionTxt.Text, this.layoutRoot);
        }

        private void SearchBtn_Copy9_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ViewFile_Click(object sender, RoutedEventArgs e)
        {
            var o = Grid1.SelectedItem as ContractFilesGridItem;
            FilingManager.DownloadContractFile(CurrentContract.Contractid, (ContractIndex)o.DocumentIndex, o.FileId, this.layoutRoot);
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            var o = Grid1.SelectedItem as ContractFilesGridItem;
            FilingManager.UploadContractFile(CurrentContract.Contractid, (ContractIndex)o.DocumentIndex,null, this.layoutRoot);
            Grid1.Items.Refresh();
        }

        private void DeleteFile_Click(object sender, RoutedEventArgs e)
        {
            if (UserData.CurrentUser.ManagingPaymentDraft == false) return;
            if (CurrentContract.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("سند به ثبت نهایی رسیده است");
                return;
            }
            if (!UserData.CurrentAccessRight.ContractDelete)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            var o = Grid1.SelectedItem as ContractFilesGridItem;
            FilingManager.DeleteContractFile(CurrentContract.Contractid, (ContractIndex)o.DocumentIndex, o.FileId, this.layoutRoot);
            UpdateGridList();
        }


        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateGridList();
            DocTitles.ItemsSource = DocTypes; 
            Header.CurrentContract = CurrentContract;
            FilingManager.TransactionFinished += new FilingJobDone(FilingManager_TransactionFinished);
        }

        void FilingManager_TransactionFinished()
        {
            UpdateGridList();
        }

        private void ContractHeaderControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateGridList();
        }

    }
    public class ContractFilesGridItem
    {
        public int FileId { set; get; }
        public string Version { set; get; }
        public DateTime? AttachedDate { set; get; }
        public int? DocumentIndex { set; get; }
    }
}

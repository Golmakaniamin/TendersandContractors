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
    /// Interaction logic for UI10.xaml
    /// </summary>
    public partial class UI10DocsPresentation : Page
    {
        private List<ContractorTenderingDocumentRecieve> DocRecList = new List<ContractorTenderingDocumentRecieve>();
        Tendering CurrentTendering { set; get; }
        public UI10DocsPresentation(Tendering t)
        {
            CurrentTendering = t;
            InitializeComponent();
        }

        private void SuperVisionCom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddFileBtn_Click(object sender, RoutedEventArgs e)
        {

        }
       

      
      
        private void CntrctrSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            var name = (CompanyNameTxt.Text.Trim() == "") ? null : CompanyNameTxt.Text;
            var social = (SocialNumberTxt.Text.Trim() == "") ? null : SocialNumberTxt.Text;
            var t = DataManagement.SearchContractors(name, social, null, true, null);
            dataGrid3.ItemsSource = t;
        }

        private void AddCntrctrBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid3.SelectedIndex != -1 )
            {
                var x = from items in dataGrid4.Items.Cast<ContractorTenderingDocumentRecieve>()
                        where items.ContractorId == (dataGrid3.SelectedItem as Contractor).ContractorId
                        select items;
                if (x.Count() > 0)
                    return;
               DocRecList.Add(new ContractorTenderingDocumentRecieve() { ContractorId = (dataGrid3.SelectedItem as Contractor).ContractorId,TenderingId=CurrentTendering.TenderingId });
               dataGrid4.ItemsSource = DocRecList;
               dataGrid4.Items.Refresh();
            }
        }

        private void RefreshCntrctrBtn_Click(object sender, RoutedEventArgs e)
        {
            CompanyNameTxt.Text = "";
            SocialNumberTxt.Text = "";
            dataGrid3.ItemsSource = null;
            
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                DataManagement.UpdateTenderingDocumentRecieve(DocRecList, CurrentTendering);
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["SuccessfulSave"]);
                DataManagement.UpdateTenderingStage(CurrentTendering, Stages.RecieveDocs);
                var t = DataManagement.RetrieveTenderingDocumentRecieve(CurrentTendering);
                if (t != null)
                {
                    DocRecList = t;
                }
                dataGrid4.ItemsSource = DocRecList;
            }
            catch
            {
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["NotSave"]);
            }
        }

        private void DeleteCntrctrBtn_Click(object sender, RoutedEventArgs e)
        {
            var item = dataGrid4.SelectedItem as ContractorTenderingDocumentRecieve;
           DocRecList.Remove(dataGrid4.SelectedItem as ContractorTenderingDocumentRecieve);
           dataGrid4.ItemsSource = DocRecList;
           dataGrid4.Items.Refresh();

        }


        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.IsDocForSale == false)
            {
                BankNameColumn.IsReadOnly = DraftNumberColumn.IsReadOnly = DraftAmountColumn.IsReadOnly = true;
            }
            var t = DataManagement.RetrieveTenderingDocumentRecieve(CurrentTendering);
            if (t != null)
            {
                DocRecList = t;
            }
            if (DocRecList.Count == 0)
            {
                dataGrid3.ItemsSource = DataManagement.RetrieveContractorShortList(CurrentTendering);
            }
            dataGrid4.ItemsSource = DocRecList;
            Header.CurrentRequest = DataManagement.RetrieveTenderingContractorRequest(CurrentTendering);
            if (CurrentTendering.TenderingType == "انحصاری" || CurrentTendering.TenderingType == "ترک تشريفات" || CurrentTendering.TenderingType == "محدود دو مرحله اي" || CurrentTendering.TenderingType == "محدود يک مرحله اي")
            {
                CntrctrSearchBtn.IsEnabled = true;
            }
        }
        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (!UserData.CurrentAccessRight.TenderingWrite)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            if (SaveBtn.IsEnabled == false)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            var item = dataGrid4.SelectedItem as ContractorTenderingDocumentRecieve;
            if (item == null || item.ContractorTenderingBuyId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, (TenderingIndex.ContractorRecieveDoc), item.ContractorId,null, this.layoutRoot, null);
        }

        private void DeleteFile_Click(object sender, RoutedEventArgs e)
        {
            if (!UserData.CurrentAccessRight.TenderingDelete)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            if (SaveBtn.IsEnabled == false)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            var item = dataGrid4.SelectedItem as ContractorTenderingDocumentRecieve;
            if (item == null || item.ContractorTenderingBuyId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NoFile"]);
                return;
            }
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, (TenderingIndex.ContractorRecieveDoc), item.ContractorId, null, this.layoutRoot, null);
        }

        private void ViewFile_Click(object sender, RoutedEventArgs e)
        {
            var item = dataGrid4.SelectedItem as ContractorTenderingDocumentRecieve;
            if (item == null || item.ContractorTenderingBuyId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NoFile"]);
                return;
            }
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, (TenderingIndex.ContractorRecieveDoc), item.ContractorId, null, this.layoutRoot, null);
        }
    }
}

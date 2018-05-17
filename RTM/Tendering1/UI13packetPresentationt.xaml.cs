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
    /// Interaction logic for UI13pakat.xaml
    /// </summary>
    public partial class UI13packetPresentationt : Page
    {
        public Tendering CurrentTendering { get; set; }
        private List<ContractorTenderingSubmitPacket> list = new List<ContractorTenderingSubmitPacket>();
        public UI13packetPresentationt()
        {
            InitializeComponent();
        }
        public UI13packetPresentationt(Tendering t)
        {
            CurrentTendering = t;
            InitializeComponent();
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Grid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

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
            var item = dataGrid.SelectedItem as ContractorTenderingSubmitPacket;
            if (item == null || item.ContractorSubmitingDocumentId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, (TenderingIndex.PacketPresent), item.ContractorId, null, this.layoutRoot, null);
        }

        private void DeleteFile_Click(object sender, RoutedEventArgs e)
        {
            if (!UserData.CurrentAccessRight.TenderingDelete)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            if (SaveBtn.IsEnabled == false || !UserData.CurrentAccessRight.TenderingDelete)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            var item = dataGrid.SelectedItem as ContractorTenderingSubmitPacket;
            if (item == null || item.ContractorSubmitingDocumentId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, (TenderingIndex.PacketPresent), item.ContractorId, null, this.layoutRoot, null);
        }

        private void ViewFile_Click(object sender, RoutedEventArgs e)
        {
            var item = dataGrid.SelectedItem as ContractorTenderingSubmitPacket;
            if (item == null || item.ContractorSubmitingDocumentId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, (TenderingIndex.PacketPresent), item.ContractorId, null, this.layoutRoot, null);
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            Header.CurrentRequest = DataManagement.RetrieveTenderingContractorRequest(CurrentTendering);
            list = DataManagement.RetrieveContractorSubmitPackets(CurrentTendering);
            dataGrid.ItemsSource = list;
        }
        public bool CheckValidInputs(List<ContractorTenderingSubmitPacket> list)
        {
            bool hasError = false;
            ContractorTenderingSubmitPacket errorItem = null;
            string response = "";
            foreach (var item in list)
            {
                var x = item as ContractorTenderingSubmitPacket;
                if (x.SecretaryNumber == null || x.SecretaryNumber == "")
                {
                    response += "شماره ثبت دبیرخانه";
                    hasError = true;
                    errorItem = x;
                    break;
                }
            }
            if (hasError)
            {
                dataGrid.SelectedItem = errorItem;
                ErrorHandler.ShowErrorMessage(response + " صحیح وارد نشده است.");
                return false;
            }
            return true;

        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (!CheckValidInputs(list)) return;
                foreach (var item in list)
                {
                    if (!(
                            (item.SubmitDate >= CurrentTendering.RecievingDocumentsDate && item.SubmitDate <= CurrentTendering.SuggestionRecieveDate) ||
                                                    (item.WithdrawDate >= CurrentTendering.RecievingDocumentsDate && item.WithdrawDate <= CurrentTendering.SuggestionRecieveDate) ||
                                                        (item.SubmitDate != null && item.WithdrawDate != null))
                            )
                    {
                        ErrorHandler.ShowErrorMessage("خطا در ورود تاریخ ها: تاریخ های ثبت شده باید قبل از " + (new DateConverterGrid()).Convert(CurrentTendering.SuggestionRecieveDate, null, null, null) + " و بعد از " + (new DateConverterGrid()).Convert(CurrentTendering.RecievingDocumentsDate, null, null, null) + "  باشند ");
                        return;
                    }
                }
                DataManagement.UpdateContractorSubmitPacket(list);
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["SuccessfulSave"]);
                DataManagement.UpdateTenderingStage(CurrentTendering, Stages.RecivePackets);
            }
            catch
            {
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["NotSave"]);
            }
        }


    }
}

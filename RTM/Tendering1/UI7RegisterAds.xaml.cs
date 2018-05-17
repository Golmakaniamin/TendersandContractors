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
    /// Interaction logic for UI7RegisterAds.xaml
    /// </summary>
    public partial class UI7RegisterAds : Page
    {
        public Notice CurrentNotice { set; get; }
        public Tendering CurrentTendering { set; get; }
        public List<Advertisement> AdList = new List<Advertisement>();
        public UI7RegisterAds()
        {
            CurrentNotice = new Notice();
            InitializeComponent();
        }

        public UI7RegisterAds(Notice n, Tendering x)
        {
            CurrentTendering = x;
            CurrentNotice = n;
            InitializeComponent();
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                AdList = DataManagement.RetrieveAdvertisement(CurrentNotice);
                NoticeGrid.ItemsSource = AdList;
            }
            catch (System.Exception ex)
            {

            }
        }


        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser(Errors.Permanented);
                return;
            }
            if (SaveBtn.IsEnabled == false)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            if (!UserData.CurrentAccessRight.TenderingWrite)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            var item = NoticeGrid.SelectedItem as Advertisement;
            if (item == null || item.AdvertisementId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.UploadTenderingFile(CurrentNotice.TenderingId, (TenderingIndex.Advertisement), null, null, this.layoutRoot, item.AdvertisementId);
        }

        private void DeleteFile_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser(Errors.Permanented);
                return;
            }
            if (SaveBtn.IsEnabled == false)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            if (!UserData.CurrentAccessRight.TenderingDelete)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            var item = NoticeGrid.SelectedItem as Advertisement;
            if (item == null || item.AdvertisementId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NoFile"]);
                return;
            }
            FilingManager.DeleteTenderingFile(CurrentNotice.TenderingId, (TenderingIndex.Advertisement), null, null, this.layoutRoot, item.AdvertisementId);
        }

        private void ViewFile_Click(object sender, RoutedEventArgs e)
        {
            var item = NoticeGrid.SelectedItem as Advertisement;
            if (item == null || item.AdvertisementId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NoFile"]);
                return;
            }
            FilingManager.DownloadTenderingFile(CurrentNotice.TenderingId, (TenderingIndex.Advertisement), null, null, this.layoutRoot, item.AdvertisementId);
        }


        private void DocTitles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = e.AddedItems;
        }

        private void SaveBtn_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentTendering.PermanentRecord==true)
                {
                    ErrorHandler.NotifyUser(Errors.Permanented);
                    return;
                }
                if (!CheckValidInputs(AdList))
                    return;
                if (AdList.Count == 0)
                {
                    ErrorHandler.ShowErrorMessage("موردی وارد نشده است.");
                    return;
                }
                DataManagement.UpdateAdveritsement(AdList, CurrentNotice);
                AdList = DataManagement.RetrieveAdvertisement(CurrentNotice);
                NoticeGrid.ItemsSource = AdList;
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["SuccessfulSave"]);
            }
            catch
            {
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["FailedSave"]);
            }
        }

        private void NoticeGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var text = e.EditingElement as TextBox;
            var date = e.EditingElement as DatePicker;

            if (text != null)
            {
                if (text.Text == "" || text.Text == null)
                {
                    ErrorHandler.ShowErrorMessage(e.Column.Header.ToString() + " باید پر شود");
                    e.Cancel = true;
                    return;
                }
                return;
            }
            else if (date != null)
            {
                if (date.SelectedDate == null)
                {
                    ErrorHandler.ShowErrorMessage(e.Column.Header.ToString() + " باید انتخاب  شود");
                    e.Cancel = true;
                    return;
                }
                return;
            }
        }
        public bool CheckValidInputs(List<Advertisement> list)
        {
            bool hasError = false;
            Advertisement errorItem = null;
             string response = "";
            foreach (var item in list)
            {
                var x = item as Advertisement;
               
                
                if (x.AdertisementDate == null )
                {
                    response += "تاریخ";
                    hasError = true;
                    errorItem = x;
                    break;
                }
                else if (x.AdvertisementAlternationCount == null || x.AdvertisementAlternationCount <=0)
                {
                    response += "نوبت";
                    hasError = true;
                    errorItem = x;
                    break;
                }
                else if (x.AdvertisementNumber == null || x.AdvertisementNumber == "")
                {
                    response += "شماره";
                    hasError = true;
                    errorItem = x;
                    break;
                }
                else if (x.NewspaperName == null || x.NewspaperName == "")
                {
                    response += "نام روزنامه";
                    hasError = true;
                    errorItem = x;
                    break;
                }
                else if (x.NewsPaperNumber == null || x.NewsPaperNumber == "")
                {
                    response += "شماره روزنامه";
                    hasError = true;
                    errorItem = x;
                    break;
                }
            }
            if (hasError)
            {
                NoticeGrid.SelectedItem = errorItem;
                ErrorHandler.ShowErrorMessage(response + " باید پر شود");
                return false;
            }
            return true;

        }

        private void NoticeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}

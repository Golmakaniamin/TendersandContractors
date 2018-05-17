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
    /// Interaction logic for Tazmin.xaml
    /// </summary>
    public partial class Tazmin : Page
    {
        public List<WarrantyType> TypesList = new List<WarrantyType>()
        { 
            new WarrantyType(){
                Title="ضمانت نامه بانکی", ID=(int)WarrantyTypes.LC
            },
            new WarrantyType(){
                Title="فیش واریزی", ID=(int)WarrantyTypes.Draft
            },
            new WarrantyType(){
                Title="اوراق مشارکت", ID=(int)WarrantyTypes.Stock
            }
        };
        public Tendering CurrentTendering { set; get; }
        private List<Warranty> list = new List<Warranty>();
        public Tazmin()
        {
            InitializeComponent();
        }

        public Tazmin(Tendering x)
        {
            InitializeComponent();
            CurrentTendering = x;
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ChooseCom.ItemsSource = DataManagement.RetrieveWarrantyContractor(CurrentTendering);
            DocType.ItemsSource = TypesList;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("سند به تایید نهایی رسیده است");
                return;
            }

            if (CurrentTendering.LcWarranty == false && DocType.SelectedIndex == 0)
            {
                ErrorHandler.NotifyUser("این نوع سند تضمین در این مناقصه پذیرفته نیست");
                return;
            }
            if (CurrentTendering.DraftWarranty == false && DocType.SelectedIndex == 1)
            {
                ErrorHandler.NotifyUser("این نوع سند تضمین در این مناقصه پذیرفته نیست");
                return;
            }
            if (CurrentTendering.StockWarranty == false && DocType.SelectedIndex == 2)
            {
                ErrorHandler.NotifyUser("این نوع سند تضمین در این مناقصه پذیرفته نیست");
                return;
            }

            if (NumberTxt.Text == "") { l1.Foreground = new SolidColorBrush(Colors.Red); } else { l1.Foreground = new SolidColorBrush(Colors.Black); }
            if (RegDate.SelectedDate == null) { l2.Foreground = new SolidColorBrush(Colors.Red); } else { l2.Foreground = new SolidColorBrush(Colors.Black); }
            if (PriceTxt.Text == "") { l3.Foreground = new SolidColorBrush(Colors.Red); } else { l3.Foreground = new SolidColorBrush(Colors.Black); }
            if (BankName.Text == "") { l4.Foreground = new SolidColorBrush(Colors.Red); } else { l4.Foreground = new SolidColorBrush(Colors.Black); }
            if (NumberTxt.Text == "" || RegDate.SelectedDate == null || PriceTxt.Text == "" || BankName.Text == "")
            {
                ErrorHandler.NotifyUser("برخی از اطلاعات ضروری وارد نشده است");
                return;
            }
            decimal? sum = 0;
            foreach (var item in list)
            {
                if (item.RegisterDate > CurrentTendering.SuggestionRecieveDate || item.RegisterDate < CurrentTendering.RecievingDocumentsDate)
                {
                    ErrorHandler.ShowErrorMessage("خطا در ورود تاریخ ها: تاریخ های ثبت شده باید قبل از " + (new DateConverterGrid()).Convert(CurrentTendering.SuggestionRecieveDate, null, null, null) + " و بعد از " + (new DateConverterGrid()).Convert(CurrentTendering.RecievingDocumentsDate, null, null, null) + " باشند");
                    return;
                }
                sum += item.Amount;
            }

            if (sum < CurrentTendering.GuarantyPrice)
            {
                ErrorHandler.ShowErrorMessage("مبلغ ضمانت نامه کمتر از میزان تعیین شده است");
                return;
            }
            if (ChooseCom.SelectedItem as Contractor != null)
            {
                if(DataManagement.UpdateWarranty(list, CurrentTendering, ChooseCom.SelectedItem as Contractor))
                    ErrorHandler.NotifyUser("مورد منتخب با موفقیت ثبت شد");
                DataManagement.UpdateTenderingStage(CurrentTendering, Stages.Warranty);
            }
            ChooseCom_SelectionChanged(sender,null);
        }

        private void CityTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DocType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ChooseCom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var temp = ChooseCom.SelectedItem as Contractor;
            if (temp == null)
                return;
            list = DataManagement.RetrieveWarranty(temp, CurrentTendering);
            dataGrid.ItemsSource = list;
            dataGrid.Items.Refresh();
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
            var item = dataGrid.SelectedItem as Warranty;
            if (item == null || item.WarrantyId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, (TenderingIndex.WarrantyDocs),item.ContractorId, null, this.layoutRoot,null,null,item.WarrantyId);
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
            var item = dataGrid.SelectedItem as Warranty;
            if (item == null || item.WarrantyId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, (TenderingIndex.WarrantyDocs), item.ContractorId, null, this.layoutRoot, null, null, item.WarrantyId);
        }

        private void ViewFile_Click(object sender, RoutedEventArgs e)
        {
            var item = dataGrid.SelectedItem as Warranty;
            if (item == null || item.WarrantyId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, (TenderingIndex.WarrantyDocs), item.ContractorId, null, this.layoutRoot, null, null, item.WarrantyId);
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            
            var temp = dataGrid.SelectedItem as Warranty;
            if (temp == null)
                return;
            list.Remove(temp);
            dataGrid.ItemsSource = list;
            dataGrid.Items.Refresh();
        }

        private void SesionRecordAddBtn_Click(object sender, RoutedEventArgs e)
        {
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.WarrantyMeeting,null,null, this.layoutRoot);
        }

        private void OpenFileBtn_Click(object sender, RoutedEventArgs e)
        {
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.WarrantyMeeting, null, null, this.layoutRoot);
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.TenderingId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, TenderingIndex.WarrantyMeeting, null, null, this.layoutRoot);
        }

        private void PriceTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox Tmp = (TextBox)sender;
            foreach (char x in Tmp.Text)
            {
                if (!char.IsDigit(x) && x != ',')
                {
                    ErrorHandler.NotifyUser("این فیلد فقط شامل مقادیر عددی است");
                    Tmp.Text = "";
                    return;
                }
            }
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.StageId < (int)Stages.Warranty)
            {
                ErrorHandler.NotifyUser("ابتدا به ثبت سندهای تضمین بپردازید");
                return;
            }
            else
            {
                NavigationHandler.NavigateToPage(this,new RTM.Report.Report7.Report7_Viewer(CurrentTendering));
            }
        }
    }
    public class WarrantyType
    {
        public string Title { set; get; }
        public int ID { set; get; }
    }
}

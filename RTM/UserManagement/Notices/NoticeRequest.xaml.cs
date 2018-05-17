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
    /// Interaction logic for NoticeRequest.xaml
    /// </summary>
    public partial class NoticeRequest : Page
    {
        public Tendering CurrentTendering;
        public ContractorRequest CurrentReq;
        public NoticeRequest()
        {
            CurrentReq = new ContractorRequest();
            CurrentTendering = new Tendering();
            InitializeComponent();
        }

        public NoticeRequest(Tendering x, ContractorRequest y)
        {
            CurrentReq = y;
            CurrentTendering = x;
            InitializeComponent();
        }

        private bool CheckValidity()
        {
            if (CurrentTendering.RequestPermanentCheck == true)
            {
                ErrorHandler.NotifyUser("سند به تایید نهایی رسیده است");
                return false;
            }

            
            if (ReqNomTxt.Text == "") { label5.Foreground = new SolidColorBrush(Colors.Red); } else { label5.Foreground = new SolidColorBrush(Colors.Black); }
            if (ReqDateDP.SelectedDate == null) { label6.Foreground = new SolidColorBrush(Colors.Red); } else { label6.Foreground = new SolidColorBrush(Colors.Black); }
            if (RequestUnitCom.SelectedIndex == -1) { label16.Foreground = new SolidColorBrush(Colors.Red); } else { label16.Foreground = new SolidColorBrush(Colors.Black); }
            if (SuperVisionCom.SelectedIndex == -1) { label8.Foreground = new SolidColorBrush(Colors.Red); } else { label8.Foreground = new SolidColorBrush(Colors.Black); }
            if (TitleTxt.Text == "") { label3.Foreground = new SolidColorBrush(Colors.Red); } else { label3.Foreground = new SolidColorBrush(Colors.Black); }
            if (NeededFieldCom.SelectedIndex == -1) { label13.Foreground = new SolidColorBrush(Colors.Red); } else { label13.Foreground = new SolidColorBrush(Colors.Black); }
            if (NeededRankCom.SelectedIndex == -1) { label14.Foreground = new SolidColorBrush(Colors.Red); } else { label14.Foreground = new SolidColorBrush(Colors.Black); }
            if (TenderCodeCom.SelectedIndex == -1) { label7.Foreground = new SolidColorBrush(Colors.Red); } else { label7.Foreground = new SolidColorBrush(Colors.Black); }
            if ( RequestUnitCom.SelectedIndex == -1 ||  ReqNomTxt.Text == "" || TitleTxt.Text == ""   || NeededFieldCom.SelectedIndex == -1 ||  NeededRankCom.SelectedIndex == -1 || TenderCodeCom.SelectedIndex == -1 || ReqDateDP.SelectedDate == null)
            {
                ErrorHandler.NotifyUser("برخی از اطلاعات ضروری وارد نشده است");
                return false;
            }
            return true;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (SuperVisionCom.ItemsSource == null || RequestUnitCom.ItemsSource == null)
                RequestUnitCom.ItemsSource = SuperVisionCom.ItemsSource = DataManagement.RetrieveOrganizationChart();
            if (TenderCodeCom.ItemsSource == null)
                TenderCodeCom.ItemsSource = DataManagement.RetrieveTenderingTitle();
            NeededRankCom.ItemsSource = new List<int> { 1, 2, 3, 4, 5 };
            NeededFieldCom.ItemsSource = new List<string> { "ساختمان", "آب", "راه و ترابري", "صنعت و معدن", "نيرو", "تاسيسات و تجهيزات", "کاوشهاي زميني", "ارتباطات", "کشاورزي", "خدمات", "آثار باستاني" };
            
            CurrentTendering = DataManagement.RetrieveContractorRequestTendering(CurrentReq);
            if (CurrentTendering == null)
                CurrentTendering = new Tendering();
            this.DataContext = CurrentReq;
            textBox1.DataContext = CurrentTendering;
        }

        private void YearCom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if ( !CheckValidity())
                return;
            if (DataManagement.CreateContractorRequest(CurrentReq) != null)
            {
                Tendering t = new Tendering()
                {
                    ContractorRequestId = CurrentReq.ContractorRequestId,
                };
                t.TenderingTitle = TitleTxt.Text;
                t.Location = LocationTxt.Text;
                t.IsNotice = true;
                t.MinScore = CurrentTendering.MinScore;
                try
                {
                    CurrentTendering = DataManagement.CreateTendering(t);
                    ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["SuccessfulSave"]);
                    SaveBtn.IsEnabled = false;
                }
                catch (Exception ex)
                {
                    ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["FailedSave"]);
                }
            }
            else
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["FailedSave"]);
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTendering.RequestPermanentCheck == true)
            {
                ErrorHandler.NotifyUser(Errors.Permanented);
                return;
            }
            if (!CheckValidity())
                return;
            try
            {
                DataManagement.UpdateContractorRequest(CurrentReq);
                CurrentTendering.TenderingTitle = TitleTxt.Text;
                CurrentTendering.Location = LocationTxt.Text;
                CurrentTendering.IsNotice = true;
                DataManagement.UpdateTendering(CurrentTendering);
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["SuccessfulSave"]);
            }
            catch
            {
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["FailedSave"]);
            }
        }

        private void TitleTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentReq.ContractorRequestId == 0)
            {
                ErrorHandler.NotifyUser("ابتدا درخواست را ثبت کنید");
                return;
            }
            NavigationHandler.NavigateToPage(this,new RTM.Tendering1.UI3PresidentOrder(CurrentReq,true));
        }

        private void TenderEstimateTxt_KeyDown(object sender, KeyEventArgs e)
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

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SuperVisionCom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

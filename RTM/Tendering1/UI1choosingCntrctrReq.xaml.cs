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
    /// Interaction logic for UI1choosingCntrctrReq.xaml
    /// </summary>
    /// 
    public partial class UI1choosingCntrctrReq : Page
    {
        public ContractorRequest CurrentReq { set; get; }
        public Tendering CurrentTendering { set; get; }
        List<Contractor> contractors = new List<Contractor>();
        public UI1choosingCntrctrReq()
        {
            CurrentReq = new ContractorRequest();
            CurrentReq.SelectConsultant = false;
            CurrentReq.SelectContractor = false;
            CurrentReq.IsPriceList = false;
            CurrentReq.HasQualityEvaluation = false;
            CurrentReq.HasCEOAccepted = true;
            CurrentReq.HasFunding = true;
            InitializeComponent();
        }
        public UI1choosingCntrctrReq(ContractorRequest c)
        {
            CurrentReq = c;
            InitializeComponent();
        }

        public UI1choosingCntrctrReq(ContractorRequest c, bool isTenderingNotice)
        {
            CurrentReq = c;
            InitializeComponent();
            //invising and changing titles correspondingly
        }

        private void comboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (YearCom.Text == "" && PriceListCheck.IsChecked == true) { label12.Foreground = new SolidColorBrush(Colors.Red); } else { label12.Foreground = new SolidColorBrush(Colors.Black); }
            if (ReqNomTxt.Text == "") { label5.Foreground = new SolidColorBrush(Colors.Red); } else { label5.Foreground = new SolidColorBrush(Colors.Black); }
            if (ChoosingConsultantRadio.IsChecked == false && choosingCntrctrRadio.IsChecked == false) { label25.Foreground = new SolidColorBrush(Colors.Red); } else { label25.Foreground = new SolidColorBrush(Colors.Black); }
            if (RequestUnitCom.SelectedIndex == -1) { label16.Foreground = new SolidColorBrush(Colors.Red); } else { label16.Foreground = new SolidColorBrush(Colors.Black); }
            if (TitleTxt.Text == "") { label3.Foreground = new SolidColorBrush(Colors.Red); } else { label3.Foreground = new SolidColorBrush(Colors.Black); }
            if (LocationTxt.Text == "") { label4.Foreground = new SolidColorBrush(Colors.Red); } else { label4.Foreground = new SolidColorBrush(Colors.Black); }
            if (TenderEstimateTxt.Text == "") { label9.Foreground = new SolidColorBrush(Colors.Red); } else { label9.Foreground = new SolidColorBrush(Colors.Black); }
            if (NeededFieldCom.SelectedIndex == -1) { label13.Foreground = new SolidColorBrush(Colors.Red); } else { label13.Foreground = new SolidColorBrush(Colors.Black); }
            if (SuperVisionCom.SelectedIndex == -1) { label8.Foreground = new SolidColorBrush(Colors.Red); } else { label8.Foreground = new SolidColorBrush(Colors.Black); }
            if (NeededRankCom.SelectedIndex == -1) { label14.Foreground = new SolidColorBrush(Colors.Red); } else { label14.Foreground = new SolidColorBrush(Colors.Black); }
            if (TenderTypeCom.SelectedIndex == -1) { label17.Foreground = new SolidColorBrush(Colors.Red); } else { label17.Foreground = new SolidColorBrush(Colors.Black); }
            if (TenderCodeCom.SelectedIndex == -1) { label7.Foreground = new SolidColorBrush(Colors.Red); } else { label7.Foreground = new SolidColorBrush(Colors.Black); }
            if (ReqDateDP.SelectedDate == null) { label6.Foreground = new SolidColorBrush(Colors.Red); } else { label6.Foreground = new SolidColorBrush(Colors.Black); }
            if ((YearCom.Text == "" && PriceListCheck.IsChecked == true) || RequestUnitCom.SelectedIndex == -1 || ChoosingConsultantRadio.IsChecked == false && choosingCntrctrRadio.IsChecked == false || ReqNomTxt.Text == "" || TitleTxt.Text == "" || LocationTxt.Text == "" || TenderEstimateTxt.Text == "" || NeededFieldCom.SelectedIndex == -1 || SuperVisionCom.SelectedIndex == -1 || NeededRankCom.SelectedIndex == -1 || TenderTypeCom.SelectedIndex == -1 || TenderCodeCom.SelectedIndex == -1 || ReqDateDP.SelectedDate == null)
            {
                ErrorHandler.NotifyUser("برخی از اطلاعات ضروری وارد نشده است");
                return;
            }

            if (DataManagement.CreateContractorRequest(CurrentReq) != null)
            {
                Tendering t = new Tendering()
                {
                    ContractorRequestId = CurrentReq.ContractorRequestId,
                };
                t.StageId = (int)Stages.Request;
                t.TenderingType = TenderTypeCom.Text;
                t.TenderingTitle = TitleTxt.Text;
                t.Location = LocationTxt.Text;
                try
                {
                    CurrentTendering = DataManagement.CreateTendering(t);
                    DataManagement.UpdateContractorShortList(CurrentTendering, contractors);
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
                ErrorHandler.NotifyUser("سند به تایید نهایی رسیده است");
                return;
            }

            if (YearCom.Text == "" && PriceListCheck.IsChecked == true) { label12.Foreground = new SolidColorBrush(Colors.Red); } else { label12.Foreground = new SolidColorBrush(Colors.Black); }
            if (ReqNomTxt.Text == "") { label5.Foreground = new SolidColorBrush(Colors.Red); } else { label5.Foreground = new SolidColorBrush(Colors.Black); }
            if (ChoosingConsultantRadio.IsChecked == false && choosingCntrctrRadio.IsChecked == false) { label25.Foreground = new SolidColorBrush(Colors.Red); } else { label25.Foreground = new SolidColorBrush(Colors.Black); }
            if (RequestUnitCom.SelectedIndex == -1) { label16.Foreground = new SolidColorBrush(Colors.Red); } else { label16.Foreground = new SolidColorBrush(Colors.Black); }
            if (TitleTxt.Text == "") { label3.Foreground = new SolidColorBrush(Colors.Red); } else { label3.Foreground = new SolidColorBrush(Colors.Black); }
            if (LocationTxt.Text == "") { label4.Foreground = new SolidColorBrush(Colors.Red); } else { label4.Foreground = new SolidColorBrush(Colors.Black); }
            if (TenderEstimateTxt.Text == "") { label9.Foreground = new SolidColorBrush(Colors.Red); } else { label9.Foreground = new SolidColorBrush(Colors.Black); }
            if (NeededFieldCom.SelectedIndex == -1) { label13.Foreground = new SolidColorBrush(Colors.Red); } else { label13.Foreground = new SolidColorBrush(Colors.Black); }
            if (SuperVisionCom.SelectedIndex == -1) { label8.Foreground = new SolidColorBrush(Colors.Red); } else { label8.Foreground = new SolidColorBrush(Colors.Black); }
            if (NeededRankCom.SelectedIndex == -1) { label14.Foreground = new SolidColorBrush(Colors.Red); } else { label14.Foreground = new SolidColorBrush(Colors.Black); }
            if (TenderTypeCom.SelectedIndex == -1) { label17.Foreground = new SolidColorBrush(Colors.Red); } else { label17.Foreground = new SolidColorBrush(Colors.Black); }
            if (TenderCodeCom.SelectedIndex == -1) { label7.Foreground = new SolidColorBrush(Colors.Red); } else { label7.Foreground = new SolidColorBrush(Colors.Black); }
            if (ReqDateDP.SelectedDate == null) { label6.Foreground = new SolidColorBrush(Colors.Red); } else { label6.Foreground = new SolidColorBrush(Colors.Black); }
            if ((YearCom.Text == "" && PriceListCheck.IsChecked == true) || RequestUnitCom.SelectedIndex == -1 || ChoosingConsultantRadio.IsChecked == false && choosingCntrctrRadio.IsChecked == false || ReqNomTxt.Text == "" || TitleTxt.Text == "" || LocationTxt.Text == "" || TenderEstimateTxt.Text == "" || NeededFieldCom.SelectedIndex == -1 || SuperVisionCom.SelectedIndex == -1 || NeededRankCom.SelectedIndex == -1 || TenderTypeCom.SelectedIndex == -1 || TenderCodeCom.SelectedIndex == -1 || ReqDateDP.SelectedDate == null)
            {
                ErrorHandler.NotifyUser("برخی از اطلاعات ضروری وارد نشده است");
                return;
            }


            try
            {
                DataManagement.UpdateContractorRequest(CurrentReq);
                CurrentTendering.TenderingType = TenderTypeCom.Text;
                CurrentTendering.TenderingTitle = TitleTxt.Text;
                CurrentTendering.Location = LocationTxt.Text;
                DataManagement.UpdateTendering(CurrentTendering);
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["SuccessfulSave"]);
            }
            catch
            {
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["FailedSave"]);
            }

        }

        private void PriceListCheck_Checked(object sender, RoutedEventArgs e)
        {

            if (this.IsInitialized)
                YearCom.IsEnabled = true;

        }

        private void PriceListCheck_Unchecked(object sender, RoutedEventArgs e)
        {

            if (this.IsInitialized)
                YearCom.IsEnabled = false;
        }

        private void SaveCommitteeSessionBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentTendering.StageId >= (int)Stages.CEO && CurrentReq.HasCEOAccepted == true)
                {
                    if (CurrentReq.TenderingType == "ترک تشريفات")
                        NavigationHandler.NavigateToPage(this, new RTM.Tendering1.UI4HoldingTenderSesion(CurrentTendering, CurrentReq), true);
                    else
                        NavigationHandler.NavigateToPage(this, new RTM.Tendering1.UI4HoldingTenderSesion(CurrentTendering, CurrentReq));
                }
                else if (CurrentTendering.StageId >= (int)Stages.CEO && CurrentReq.HasCEOAccepted == false)
                {
                    ErrorHandler.NotifyUser("به دستور مدیر کل با اجرای این مناقصه مخالفت شد و امکان ادامه مراحل وجود ندارد");
                }
                else
                    ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
            }
            catch (Exception ex)
            {
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
            }
        }

        private void SavePresidentOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentTendering.StageId >= (int)Stages.CreditControl)
                    NavigationHandler.NavigateToPage(this, new RTM.Tendering1.UI3PresidentOrder(CurrentReq));
                else
                    ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
            }
            catch (Exception ex)
            {
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
            }

        }

        private void SaveCreditInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentTendering.StageId >= (int)Stages.Request)
                    NavigationHandler.NavigateToPage(this, new RTM.Tendering1.UI2CreditControl(CurrentReq, CurrentTendering));
                else
                    ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
            }
            catch (Exception ex)
            {
                ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
            }
        }

        private void ReqNomTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            if (SuperVisionCom.ItemsSource == null || RequestUnitCom.ItemsSource == null)
                RequestUnitCom.ItemsSource = SuperVisionCom.ItemsSource = DataManagement.RetrieveOrganizationChart();
            if (TenderCodeCom.ItemsSource == null)
                TenderCodeCom.ItemsSource = DataManagement.RetrieveTenderingTitle();
            NeededRankCom.ItemsSource = new List<int> { 1, 2, 3, 4, 5 };
            NeededFieldCom.ItemsSource = new List<string> { "ساختمان", "آب", "راه و ترابري", "صنعت و معدن", "نيرو", "تاسيسات و تجهيزات", "کاوشهاي زميني", "ارتباطات", "کشاورزي", "خدمات", "آثار باستاني" };
            TenderTypeCom.ItemsSource = new List<string> { "عمومي يک مرحله اي", "عمومي دو مرحله اي", "محدود يک مرحله اي", "محدود دو مرحله اي", "ترک تشريفات", "انحصاري", "بين المللي" };
            CurrentTendering = DataManagement.RetrieveContractorRequestTendering(CurrentReq);
            if (CurrentTendering != null)
                TenderSystemCodeTxt.Text = CurrentTendering.TenderingNumber;
        }

        private void ShowFileBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentReq.ContractorRequestId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.TechnicalSpecification, null, null, this.layoutRoot);
        }

        private void AddFileBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentReq.ContractorRequestId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            if (CurrentTendering.RequestPermanentCheck == true)
            {
                ErrorHandler.NotifyUser("سند به تایید نهایی رسیده است");
                return;
            }
            if (!UserData.CurrentAccessRight.TenderingWrite)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.TechnicalSpecification, null, null, this.layoutRoot);
        }

        private void AddFileBtn2_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentReq.ContractorRequestId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            if (CurrentTendering.RequestPermanentCheck == true)
            {
                ErrorHandler.NotifyUser("سند به تایید نهایی رسیده است");
                return;
            }
            if (!UserData.CurrentAccessRight.TenderingWrite)
            {
                ErrorHandler.ShowErrorMessage(Errors.OperationNotAllowed);
                return;
            }
            FilingManager.UploadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.PrivateConditions, null, null, this.layoutRoot);
        }

        private void ShowFileBtn2_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentReq.ContractorRequestId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            FilingManager.DownloadTenderingFile(CurrentTendering.TenderingId, TenderingIndex.PrivateConditions, null, null, this.layoutRoot);
        }

        private void PermanentBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UserData.CurrentAccessRight.TenderingPermanentWrite != true)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            if (CurrentReq.ContractorRequestId == 0 || CurrentTendering == null)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }

            if (PriceListCheck.IsChecked == true && YearCom.Text == "") { label12.Foreground = new SolidColorBrush(Colors.Red); } else { label12.Foreground = new SolidColorBrush(Colors.Black); }
            if (ReqNomTxt.Text == "") { label5.Foreground = new SolidColorBrush(Colors.Red); } else { label5.Foreground = new SolidColorBrush(Colors.Black); }
            if (ChoosingConsultantRadio.IsChecked == false && choosingCntrctrRadio.IsChecked == false) { label25.Foreground = new SolidColorBrush(Colors.Red); } else { label25.Foreground = new SolidColorBrush(Colors.Black); }
            if (RequestUnitCom.SelectedIndex == -1) { label16.Foreground = new SolidColorBrush(Colors.Red); } else { label16.Foreground = new SolidColorBrush(Colors.Black); }
            if (TitleTxt.Text == "") { label3.Foreground = new SolidColorBrush(Colors.Red); } else { label3.Foreground = new SolidColorBrush(Colors.Black); }
            if (LocationTxt.Text == "") { label4.Foreground = new SolidColorBrush(Colors.Red); } else { label4.Foreground = new SolidColorBrush(Colors.Black); }
            if (TenderEstimateTxt.Text == "") { label9.Foreground = new SolidColorBrush(Colors.Red); } else { label9.Foreground = new SolidColorBrush(Colors.Black); }
            if (NeededFieldCom.SelectedIndex == -1) { label13.Foreground = new SolidColorBrush(Colors.Red); } else { label13.Foreground = new SolidColorBrush(Colors.Black); }
            if (SuperVisionCom.SelectedIndex == -1) { label8.Foreground = new SolidColorBrush(Colors.Red); } else { label8.Foreground = new SolidColorBrush(Colors.Black); }
            if (NeededRankCom.SelectedIndex == -1) { label14.Foreground = new SolidColorBrush(Colors.Red); } else { label14.Foreground = new SolidColorBrush(Colors.Black); }
            if (TenderTypeCom.SelectedIndex == -1) { label17.Foreground = new SolidColorBrush(Colors.Red); } else { label17.Foreground = new SolidColorBrush(Colors.Black); }
            if (TenderCodeCom.SelectedIndex == -1) { label7.Foreground = new SolidColorBrush(Colors.Red); } else { label7.Foreground = new SolidColorBrush(Colors.Black); }
            if (ReqDateDP.SelectedDate == null) { label6.Foreground = new SolidColorBrush(Colors.Red); } else { label6.Foreground = new SolidColorBrush(Colors.Black); }
            if (PriceListCheck.IsChecked == true && YearCom.Text == "" || RequestUnitCom.SelectedIndex == -1 || ChoosingConsultantRadio.IsChecked == false && choosingCntrctrRadio.IsChecked == false || ReqNomTxt.Text == "" || TitleTxt.Text == "" || LocationTxt.Text == "" || TenderEstimateTxt.Text == "" || NeededFieldCom.SelectedIndex == -1 || SuperVisionCom.SelectedIndex == -1 || NeededRankCom.SelectedIndex == -1 || TenderTypeCom.SelectedIndex == -1 || TenderCodeCom.SelectedIndex == -1 || ReqDateDP.SelectedDate == null)
            {
                ErrorHandler.NotifyUser("برخی از اطلاعات ضروری وارد نشده است");
                return;
            }

            if (CurrentTendering.StageId < (int)Stages.TenderingMeeting)
            {
                ErrorHandler.NotifyUser("برای ثبت نهایی درخواست، لازم است مناقصه تا مرحله جلسه تصمیم نسبت به برگزاری پیش برود ");
                return;
            }

            if (CurrentTendering.RequestPermanentCheck == false)
            {
                if (ErrorHandler.PromptUserForPermision("ثبت دائم صورت گیرد ؟") == MessageBoxResult.Yes)
                {
                    CurrentTendering.RequestPermanentCheck = true;
                    CurrentTendering.TenderingNumber = DataManagement.GenerateTenderingSystemCode(CurrentTendering, CurrentReq);
                    DataManagement.UpdateTendering(CurrentTendering);
                    TenderSystemCodeTxt.Text = CurrentTendering.TenderingNumber;

                    ErrorHandler.NotifyUser("سند به ثبت نهایی رسید");
                }
            }
            else
            {
                ErrorHandler.NotifyUser("سند قبلا به ثبت نهایی رسیده است ");
                return;
            }
        }

        private void YearCom_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PriceListCheck.IsChecked == false)
                YearCom.Text = "";
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentReq.ContractorRequestId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            if (!UserData.CurrentAccessRight.TenderingDelete)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            if (CurrentTendering.RequestPermanentCheck == true)
            {
                ErrorHandler.NotifyUser("سند به تایید نهایی رسیده است");
                return;
            }
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, TenderingIndex.TechnicalSpecification, null, null, this.layoutRoot);
        }

        private void DelBtn1_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentReq.ContractorRequestId == 0)
            {
                ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NotSaved"]);
                return;
            }
            if (!UserData.CurrentAccessRight.TenderingDelete)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return;
            }
            if (CurrentTendering.RequestPermanentCheck == true)
            {
                ErrorHandler.NotifyUser("سند به تایید نهایی رسیده است");
                return;
            }
            FilingManager.DeleteTenderingFile(CurrentTendering.TenderingId, TenderingIndex.PrivateConditions, null, null, this.layoutRoot);
        }


        private void YearCom_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox Tmp = (TextBox)sender;
            foreach (char x in Tmp.Text)
            {
                if (!char.IsDigit(x))
                {
                    ErrorHandler.NotifyUser("این فیلد فقط شامل مقادیر عددی است");
                    Tmp.Text = "";
                    return;
                }
            }
        }

        private void TenderEstimateTxt_LostFocus(object sender, RoutedEventArgs e)
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


        private void ReqNomTxt_LostFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (UniqueConstraints.ValidRequestNumber(ReqNomTxt.Text, CurrentReq) == false)
            {
                ErrorHandler.ShowErrorMessage(Errors.InvalidNumber);
                CurrentReq.RequestNumber = "";
            }
        }

        private void CompanySelectBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentReq.ContractorRequestId == 0)
            {
                ErrorHandler.ShowErrorMessage(Errors.NotSaved);
                return;
            }
            NavigationHandler.NavigateToPage(this, new RTM.Tendering1.ContractorSelection(CurrentTendering));
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

        private void NoticeNumberTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

            }
        }

        private void NoticeNumberTxt_KeyDown(object sender, KeyboardFocusChangedEventArgs e)
        {
            try
            {
                var t = DataManagement.SearchTenderings("", "", NoticeNumber.Text, "", "", null, null, null, null, null, null, null, null, "", null, null, true).FirstOrDefault();
                if (t != null && NoticeNumber.Text != "")
                {
                    var x = DataManagement.SearchEvaluations(null, null, NoticeNumber.Text, null, null, null, null, null, null).FirstOrDefault();
                    if (x != null)
                    {


                        var temp = DataManagement.RetrieveEvaluationContractorsWithScoreSum(x.EvaluationId);
                        foreach (var item in temp)
                        {
                            if (item.totalScore >= x.MinimumScore)
                                contractors.Add(item.contractor);
                        }
                    }
                    else
                    {
                        ErrorHandler.ShowErrorMessage(Errors.IncompleteNotice);
                    }
                    var c = DataManagement.RetrieveTenderingContractorRequest(t);
                    ErrorHandler.NotifyUser(Errors.FoundNotice);
                    CurrentReq.Estimatation = c.Estimatation;
                    CurrentReq.RequestingUnit = c.RequestingUnit;
                    CurrentReq.ProjectTitle = c.ProjectTitle;
                    CurrentReq.TenderingTitleId = c.TenderingTitleId;
                    CurrentReq.SupervisionId = c.SupervisionId;
                    CurrentReq.TenderingType = c.TenderingType;
                    CurrentReq.IsPriceList = c.IsPriceList;
                    CurrentReq.RequiredField = c.RequiredField;
                    CurrentReq.RequiredMinRank = c.RequiredMinRank;
                    CurrentReq.Year = c.Year;
                    CurrentReq.TenderingType = TenderTypeCom.Items[2] as string;
                }
                else
                {
                    NoticeNumber.Text = "";
                    ErrorHandler.ShowErrorMessage(Errors.NotFoundNotice);
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage(Errors.ServerError);
            }
        }

        private void TenderTypeCom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (TenderTypeCom.SelectedIndex)
            {
                case 2:
                case 3:
                case 4:
                case 5:
                    CompanySelectBtn.IsEnabled = true;
                    break;
                case 0:
                case 1:
                case 6:
                    CompanySelectBtn.IsEnabled = false;
                    break;
            }
        }
    }
}

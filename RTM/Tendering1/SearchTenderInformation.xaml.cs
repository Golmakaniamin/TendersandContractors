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
using RTM.TenderingArchive;

namespace RTM.Tendering1
{
    /// <summary>
    /// Interaction logic for SearchTenderInformation.xaml
    /// </summary>
    ///
    public partial class SearchTenderInformation : Page
    {
        public Tendering CurrentTender { set; get; }
        public ContractorRequest CurrentReq {set; get;}
        public SearchTenderInformation()
        {
            CurrentTender = new Tendering();
            InitializeComponent();
        }

        private void Grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Grid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DescriptionTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DisqualifiedRadio_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            string tt = (TenderTypeCom.SelectedIndex == -1) ? "" : TenderTypeCom.SelectedItem.ToString();
            Grid.ItemsSource = DataManagement.SearchTenderings(tt, TenderTitleTxt.Text, TenderSystemCodeTxt.Text,null,"",FromDate.SelectedDate,ToDate.SelectedDate);
        }

        private void page_Loaded(object sender, RoutedEventArgs e)
        {
            TenderTypeCom.ItemsSource = new List<string> { "عمومي يک مرحله اي", "عمومي دو مرحله اي", "محدود يک مرحله اي", "محدود دو مرحله اي", "ترک تشريفات", "انحصاري", "بين المللي" };
            if(StagesCom.Items.Count ==0)
            StagesCom.ItemsSource = DataManagement.RetrieveStages();
            
        }

        private void Grid_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            var item = Grid.SelectedItem as Tendering;
            if (item == null)
            {
                return;
            }
            Header.CurrentRequest = DataManagement.RetrieveTenderingContractorRequest(item);
            StagesCom.SelectedValue = item.StageId;
            //CurrentTender = item;
            CurrentTender = DataManagement.RetrieveContractorRequestTendering(Header.CurrentRequest);
            CurrentReq = Header.CurrentRequest;

        }

        private void TenderSystemCodeTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
  
            if (UserData.CurrentAccessRight.TenderingWrite == false)
            {
                ErrorHandler.NotifyUser("عملیات امکان پذیر نیست");
                return;
            }
            if (Grid.SelectedIndex==-1)
                ErrorHandler.NotifyUser("مناقصه ای انتخاب نشده است");
            else
            {
                CurrentTender = DataManagement.RetrieveContractorRequestTendering(Header.CurrentRequest);
                if (CurrentTender.PermanentRecord == true)
                {
                    ErrorHandler.NotifyUser("امکان ویرایش وجود ندارد این مناقصه به ثبت دائم رسیده است");
                    return;
                }
                var item = StagesCom.SelectedItem as Stage;
                switch (item.StageNumber)
                {
                    case 1:
                        //NavigationHandler.NavigateToPage(this, new Tendering1.UI1choosingCntrctrReq(DataManagement.RetrieveTenderingContractorRequest(CurrentTender)));
                        NavigationHandler.NavigateToPageWithMode(this, new Tendering1.UI1choosingCntrctrReq(DataManagement.RetrieveTenderingContractorRequest(CurrentTender)), NavigationMethod.EditMode, SubSystem.Tendering);
                        break;
                    case 2:
                        if (CurrentTender.StageId >= (int)Stages.Request)
                            NavigationHandler.NavigateToPage(this, new Tendering1.UI2CreditControl((DataManagement.RetrieveTenderingContractorRequest(CurrentTender)), CurrentTender));
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                            
                        }
                        break;
                    case 3:
                        if (CurrentTender.StageId >= (int)Stages.CreditControl)
                            NavigationHandler.NavigateToPage(this, new Tendering1.UI3PresidentOrder((DataManagement.RetrieveTenderingContractorRequest(CurrentTender))));
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                    case 4:
                        if (CurrentTender.StageId >= (int)Stages.CEO && CurrentReq.HasCEOAccepted == true)
                        {
                            if (CurrentReq.TenderingType == "ترک تشريفات")
                                NavigationHandler.NavigateToPage(this, new Tendering1.UI4HoldingTenderSesion(CurrentTender, DataManagement.RetrieveTenderingContractorRequest(CurrentTender),true));
                            else
                                NavigationHandler.NavigateToPage(this, new Tendering1.UI4HoldingTenderSesion(CurrentTender, DataManagement.RetrieveTenderingContractorRequest(CurrentTender)));
                        }
                        else if (CurrentTender.StageId >= (int)Stages.CEO && CurrentReq.HasCEOAccepted == false)
                        {
                            ErrorHandler.NotifyUser("به دستور مدیر کل با اجرای این مناقصه مخالفت شد و امکان ادامه مراحل وجود ندارد");
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                    case 5:
                        if (CurrentTender.StageId >= (int)Stages.TenderingMeeting)
                        {
                            if (CurrentTender.RequestPermanentCheck == false)
                            {
                                ErrorHandler.NotifyUser("برای ادامه ی مراحل  مناقصه، در مرحله درخواست نسبت به ثبت نهایی درخواست اقدام فرمایید");
                                return;
                            } 
                            NavigationHandler.NavigateToPage(this, new Tendering1.UI5TenderDocs(CurrentTender));
                        }
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                    case 6:
                        if (CurrentTender.StageId >= (int)Stages.Documents)
                        {
                            if (CurrentTender.TenderingType == "محدود يک مرحله اي" || CurrentTender.TenderingType == "محدود دو مرحله اي" || CurrentTender.TenderingType == "ترک تشريفات" || CurrentTender.TenderingType == "انحصاري")
                                ErrorHandler.NotifyUser(" مرحله فراخوان و آگهی برای این مناقصه انجام نمی پذیرد");
                            else
                                NavigationHandler.NavigateToPage(this, new Tendering1.UI6TenderingNotice(CurrentTender));
                        }
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                    case 7:
                        if (CurrentTender.StageId >= (int)Stages.Notice)
                            NavigationHandler.NavigateToPage(this, new Tendering1.UI10DocsPresentation(CurrentTender));
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                    case 8:
                        if (CurrentTender.StageId >= (int)Stages.RecieveDocs)
                            NavigationHandler.NavigateToPage(this, new Tendering1.UI13packetPresentationt(CurrentTender));
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                    case 9:
                        if (CurrentTender.StageId >= (int)Stages.RecivePackets)
                        {
                            //if (CurrentTender.TenderingType == "عمومي دو مرحله اي" || CurrentTender.TenderingType == "محدود دو مرحله اي")
                              //  NavigationHandler.NavigateToPage(this, new Tendering1.UI21TwoPhaseReopeningSesion(CurrentTender));
                            //else
                                NavigationHandler.NavigateToPage(this, new Tendering1.UI14OnePhaseReopening(CurrentTender));
                        }
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                    case 10:
                        if (CurrentTender.StageId >= (int)Stages.OpenPacket)
                        {
                            //if (CurrentTender.DraftWarranty==true)
                            //    NavigationHandler.NavigateToPage(this, new Tendering1.UI16RegisterBills(CurrentTender));
                            //else if (CurrentTender.LcWarranty==true)
                            //    NavigationHandler.NavigateToPage(this, new Tendering1.UI15RegisterBankGaurantees(CurrentTender));
                            //else if (CurrentTender.StockWarranty==true)
                            //    NavigationHandler.NavigateToPage(this, new Tendering1.UI17RegisterParticipationBills(CurrentTender));
                            //else
                            //    ErrorHandler.NotifyUser("نوع تضمین در مرحله تصمیم نسبت به برگزاری مشخص نگردیده است");
                            NavigationHandler.NavigateToPage(this, new RTM.Tendering1.Tazmin(CurrentTender));
                        }
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                    case 11:
                        if (CurrentTender.StageId >= (int)Stages.Warranty)
                            NavigationHandler.NavigateToPage(this, new Tendering1.UI18RegisterPriceOffer(CurrentTender));
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                    case 12:
                        if (CurrentTender.StageId >= (int)Stages.Bid)
                            NavigationHandler.NavigateToPage(this, new Tendering1.UI19TenderResult(CurrentTender));
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                    case 13:
                        if (CurrentTender.StageId >= (int)Stages.Result)
                        {
                            if (CurrentTender.PermanentRecord==true)
                                ErrorHandler.NotifyUser("مراحل ثبت این مناقصه به پایان رسیده و این مناقصه به ثبت نهایی رسیده است");
                            else
                                ErrorHandler.NotifyUser("مراحل ثبت این مناقصه به پایان رسیده؛ نسبت به ثبت نهایی آن اقدام شود");
                        }
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                }
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (UserData.CurrentAccessRight.TenderingWrite==false)
            {
                ErrorHandler.NotifyUser("عملیات امکان پذیر نیست");
                return;
            }
            if (Grid.SelectedIndex == -1)
            {
                ErrorHandler.NotifyUser("مناقصه ای انتخاب نشده است");
                return;
            }
            CurrentTender = DataManagement.RetrieveContractorRequestTendering(Header.CurrentRequest);
            if (CurrentTender.PermanentRecord == true)
            {
                ErrorHandler.NotifyUser("امکان ویرایش وجود ندارد این مناقصه به ثبت دائم رسیده است");
                return;
            }
            if (SessionCom.SelectedIndex==0)
                NavigationHandler.NavigateToPage(this, new UI9JustificationSesion(CurrentTender));
            else if (SessionCom.SelectedIndex==1)
                NavigationHandler.NavigateToPage(this, new UI8ExtendSesion(CurrentTender,MeetingTypes.DocExtendingMeeting));
            else if (SessionCom.SelectedIndex==2)
                NavigationHandler.NavigateToPage(this, new UI8ExtendSesion(CurrentTender,MeetingTypes.PacketExtendingMeeting));
        }

        private void StagesCom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            TenderTypeCom.SelectedIndex = -1;
            TenderTitleTxt.Text = "";
            TenderSystemCodeTxt.Text = "";
            Grid.ItemsSource = null;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.SelectedIndex == -1)
            {
                ErrorHandler.NotifyUser("مناقصه ای انتخاب نشده است");
                return;
            }
            if (SessionCom.SelectedIndex==0)
                NavigationHandler.NavigateToPageWithMode(this, new UI9JustificationSesion(CurrentTender),NavigationMethod.ViewMode,SubSystem.Tendering);
            else if (SessionCom.SelectedIndex==1)
                NavigationHandler.NavigateToPageWithMode(this, new  UI8ExtendSesion(CurrentTender,MeetingTypes.DocExtendingMeeting),NavigationMethod.ViewMode,SubSystem.Tendering);
            else if (SessionCom.SelectedIndex==2)
                NavigationHandler.NavigateToPageWithMode(this, new  UI8ExtendSesion(CurrentTender,MeetingTypes.PacketExtendingMeeting),NavigationMethod.ViewMode,SubSystem.Tendering);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.SelectedIndex == -1)
                ErrorHandler.NotifyUser("مناقصه ای انتخاب نشده است");
            else
            {
                CurrentTender = DataManagement.RetrieveContractorRequestTendering(Header.CurrentRequest);
                var item = StagesCom.SelectedItem as Stage;
                switch (item.StageNumber)
                {
                    case 1:
                        NavigationHandler.NavigateToPageWithMode(this, new Tendering1.UI1choosingCntrctrReq(DataManagement.RetrieveTenderingContractorRequest(CurrentTender)), NavigationMethod.ViewMode, SubSystem.Tendering);
                        break;
                    case 2:
                        if (CurrentTender.StageId >= (int)Stages.Request)
                            NavigationHandler.NavigateToPageWithMode(this, new Tendering1.UI2CreditControl((DataManagement.RetrieveTenderingContractorRequest(CurrentTender)), CurrentTender), NavigationMethod.ViewMode, SubSystem.Tendering);
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;

                        }
                        break;
                    case 3:
                        if (CurrentTender.StageId >= (int)Stages.CreditControl)
                            NavigationHandler.NavigateToPageWithMode(this, new Tendering1.UI3PresidentOrder((DataManagement.RetrieveTenderingContractorRequest(CurrentTender))), NavigationMethod.ViewMode, SubSystem.Tendering);
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                    case 4:
                        if (CurrentTender.StageId >= (int)Stages.CEO && CurrentReq.HasCEOAccepted == true)
                        {
                            if (CurrentReq.TenderingType == "ترک تشريفات")
                                NavigationHandler.NavigateToPageWithMode(this, new Tendering1.UI4HoldingTenderSesion(CurrentTender, DataManagement.RetrieveTenderingContractorRequest(CurrentTender),true), NavigationMethod.ViewMode, SubSystem.Tendering);
                            else
                                NavigationHandler.NavigateToPageWithMode(this, new Tendering1.UI4HoldingTenderSesion(CurrentTender, DataManagement.RetrieveTenderingContractorRequest(CurrentTender)), NavigationMethod.ViewMode, SubSystem.Tendering);
                        }
                        else if (CurrentTender.StageId >= (int)Stages.CEO && CurrentReq.HasCEOAccepted == false)
                        {
                            ErrorHandler.NotifyUser("به دستور مدیر کل با اجرای این مناقصه مخالفت شد و امکان ادامه مراحل وجود ندارد");
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                    case 5:
                        if (CurrentTender.StageId >= (int)Stages.TenderingMeeting)
                        {
                            if (CurrentTender.RequestPermanentCheck == false)
                            {
                                ErrorHandler.NotifyUser("برای ادامه ی مراحل  مناقصه، در مرحله درخواست نسبت به ثبت نهایی درخواست اقدام فرمایید");
                                return;
                            }
                            NavigationHandler.NavigateToPageWithMode(this, new Tendering1.UI5TenderDocs(CurrentTender), NavigationMethod.ViewMode, SubSystem.Tendering);
                        }
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                    case 6:
                        if (CurrentTender.StageId >= (int)Stages.Documents)
                        {
                            if (CurrentTender.TenderingType == "محدود يک مرحله اي" || CurrentTender.TenderingType == "محدود دو مرحله اي" || CurrentTender.TenderingType == "ترک تشريفات" || CurrentTender.TenderingType == "انحصاري")
                                ErrorHandler.NotifyUser(" مرحله فراخوان و آگهی برای این مناقصه انجام نمی پذیرد");
                            else
                                NavigationHandler.NavigateToPageWithMode(this, new Tendering1.UI6TenderingNotice(CurrentTender), NavigationMethod.ViewMode, SubSystem.Tendering);
                        }
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                    case 7:
                        if (CurrentTender.StageId >= (int)Stages.Notice)
                            NavigationHandler.NavigateToPageWithMode(this, new Tendering1.UI10DocsPresentation(CurrentTender), NavigationMethod.ViewMode, SubSystem.Tendering);
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                    case 8:
                        if (CurrentTender.StageId >= (int)Stages.RecieveDocs)
                            NavigationHandler.NavigateToPageWithMode(this, new Tendering1.UI13packetPresentationt(CurrentTender), NavigationMethod.ViewMode, SubSystem.Tendering);
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                    case 9:
                        if (CurrentTender.StageId >= (int)Stages.RecivePackets)
                        {
                            //if (CurrentTender.TenderingType == "عمومي دو مرحله اي" || CurrentTender.TenderingType == "محدود دو مرحله اي")
                                //NavigationHandler.NavigateToPageWithMode(this, new Tendering1.UI21TwoPhaseReopeningSesion(CurrentTender), NavigationMethod.ViewMode, SubSystem.Tendering);
                            //else
                                NavigationHandler.NavigateToPageWithMode(this, new Tendering1.UI14OnePhaseReopening(CurrentTender), NavigationMethod.ViewMode, SubSystem.Tendering);
                        }
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                    case 10:
                        if (CurrentTender.StageId >= (int)Stages.OpenPacket)
                        {
                            //if (CurrentTender.DraftWarranty == true)
                            //    NavigationHandler.NavigateToPageWithMode(this, new Tendering1.UI16RegisterBills(CurrentTender), NavigationMethod.ViewMode, SubSystem.Tendering);
                            //else if (CurrentTender.LcWarranty == true)
                            //    NavigationHandler.NavigateToPageWithMode(this, new Tendering1.UI15RegisterBankGaurantees(CurrentTender), NavigationMethod.ViewMode, SubSystem.Tendering);
                            //else if (CurrentTender.StockWarranty == true)
                            //    NavigationHandler.NavigateToPageWithMode(this, new Tendering1.UI17RegisterParticipationBills(CurrentTender), NavigationMethod.ViewMode, SubSystem.Tendering);
                            //else
                            //    ErrorHandler.NotifyUser("نوع تضمین در مرحله تصمیم نسبت به برگزاری مشخص نگردیده است");
                            NavigationHandler.NavigateToPageWithMode(this, new RTM.Tendering1.Tazmin(CurrentTender), NavigationMethod.ViewMode, SubSystem.Tendering);
                        }
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                    case 11:
                        if (CurrentTender.StageId >= (int)Stages.Warranty)
                            NavigationHandler.NavigateToPageWithMode(this, new Tendering1.UI18RegisterPriceOffer(CurrentTender), NavigationMethod.ViewMode, SubSystem.Tendering);
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                    case 12:
                        if (CurrentTender.StageId >= (int)Stages.Bid)
                            NavigationHandler.NavigateToPageWithMode(this, new Tendering1.UI19TenderResult(CurrentTender), NavigationMethod.ViewMode, SubSystem.Tendering);
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                    case 13:
                        if (CurrentTender.StageId >= (int)Stages.Result)
                        {
                            if (CurrentTender.PermanentRecord == true)
                                ErrorHandler.NotifyUser("مراحل ثبت این مناقصه به پایان رسیده و این مناقصه به ثبت نهایی رسیده است");
                            else
                                ErrorHandler.NotifyUser("مراحل ثبت این مناقصه به پایان رسیده؛ نسبت به ثبت نهایی آن اقدام شود");
                        }
                        else
                        {
                            ErrorHandler.NotifyUser(ErrorHandler.ErrorMessages["StageError"]);
                            StagesCom.SelectedValue = CurrentTender.StageId;
                        }
                        break;
                }
            }
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Grid.ItemsSource == null)
            {
                ErrorHandler.NotifyUser(Errors.NotSearched);
                return;
            }
            NavigationHandler.NavigateToPage(this, new RTM.Report.GenralRep.Tender_Viewer((List<Tendering>)(Grid.ItemsSource)));
        }
    }
}

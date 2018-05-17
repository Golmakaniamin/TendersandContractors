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
namespace RTM.Report.Report1
{
    /// <summary>
    /// Interaction logic for Report1_Viewer.xaml
    /// </summary>
    public partial class Report1_Viewer : Page
    {
        public ContractorRequest CurrentReq { set; get; }
        public Tendering CurrentTender { set; get; }
        public DateTime CurrentDate { set; get; }
        public Report1_Viewer()
        {
            InitializeComponent();
        }

        public Report1_Viewer( Tendering x )
        {
            InitializeComponent();
            CurrentTender = x;
            CurrentReq = DataManagement.RetrieveTenderingContractorRequest(CurrentTender);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void crystalReportsViewer1_Loaded(object sender, RoutedEventArgs e)
        {
            var report = new RTM.Report.Report1.Report1_Main();
            try
            {
                report.SetDatabaseLogon("ratec", "ratec");
                report.SetParameterValue("MeetingDateParam", DateConverter.ConvertDate((DateTime)(CurrentTender.TenderingRecordDate).Value.Date).ToString().Substring(4));
                report.SetParameterValue("ReqNumParam", CurrentReq.RequestNumber.ToString());
                report.SetParameterValue("ReqDateParam", DateConverter.ConvertDate((DateTime)(CurrentReq.RequestDate).Value.Date).ToString().Substring(4));
                report.SetParameterValue("TitleParam", CurrentReq.ProjectTitle);
                report.SetParameterValue("LocParam", CurrentReq.Location);
                report.SetParameterValue("EstimateParam", CurrentReq.Estimatation);
                if (CurrentReq.IsPriceList==true)
                    report.SetParameterValue("PriceListParam",CurrentReq.Year);
                else
                    report.SetParameterValue("PriceListParam", "ندارد");
                report.SetParameterValue("FieldParam", CurrentReq.RequiredField);
                report.SetParameterValue("MinRankParam", CurrentReq.RequiredMinRank);
                report.SetParameterValue("TenderTypeParam", CurrentReq.TenderingType);
                if (CurrentTender.AdvertisingAlternationCount==null || CurrentTender.AdvertisingAlternationCount==0)
                    report.SetParameterValue("AdParam","ندارد");
                else
                    report.SetParameterValue("AdParam",CurrentTender.AdvertisingAlternationCount.ToString());
                string GarantyType;
                if (CurrentTender.StockWarranty == true)
                    GarantyType = "اوراق مشارکت";
                else if (CurrentTender.LcWarranty == true)
                    GarantyType = "ضمانتنامه بانکی";
                else if (CurrentTender.DraftWarranty == true)
                    GarantyType = "فیش واریزی";
                else
                    GarantyType = "";
                report.SetParameterValue("GarantyTypeParam", GarantyType);
                report.SetParameterValue("GarantyPriceParam", CurrentTender.GuarantyPrice);
                report.SetParameterValue("RecParam", DateConverter.ConvertDate((DateTime)(CurrentTender.RecievingDocumentsDate).Value.Date).ToString().Substring(4));
                report.SetParameterValue("RecEndParam", DateConverter.ConvertDate((DateTime)(CurrentTender.RecievingDocumentDeadline).Value.Date).ToString().Substring(4));
                report.SetParameterValue("OfferParam", DateConverter.ConvertDate((DateTime)(CurrentTender.SuggestionRecieveDate).Value.Date).ToString().Substring(4));
                report.SetParameterValue("OfferEndParam", DateConverter.ConvertDate((DateTime)(CurrentTender.SuggestionOpenDate).Value.Date).ToString().Substring(4));
                if ( CurrentTender.IsDocForSale == true && CurrentTender.DocumentSalePrice!=null)
                    report.SetParameterValue("SalePriceParam", CurrentTender.DocumentSalePrice);
                else
                    report.SetParameterValue("SalePriceParam", "0");
                if (CurrentTender.HasQualityEvaluation == true )
                    report.SetParameterValue("QualityParam", "دارد");
                else
                    report.SetParameterValue("QualityParam", "ندارد");
                if (CurrentTender.HasBriefingSession == true)
                {
                    report.SetParameterValue("JustiParam", "دارد");
                    report.SetParameterValue("JustiDateParam", DateConverter.ConvertDate((DateTime)(CurrentTender.BriefingSessionDate).Value.Date).ToString().Substring(4));
                }
                else
                {
                    report.SetParameterValue("JustiParam", "ندارد");
                    report.SetParameterValue("JustiDateParam", "-");
                }
                if (CurrentTender.Description == null || CurrentTender.Description.Trim() == "")
                    report.SetParameterValue("NoteParam", "");
                else
                    report.SetParameterValue("NoteParam", CurrentTender.Description);
                report.SetParameterValue("TenderId", CurrentTender.TenderingId);
                crystalReportsViewer1.ViewerCore.ReportSource = report;
            }
            catch
            {
                return;
            }
          
        }
    }
}

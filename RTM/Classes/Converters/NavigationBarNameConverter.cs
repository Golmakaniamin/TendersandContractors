using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace RTM.Classes
{
    class NavigationBarNameConverter : IValueConverter
    {
        public static Dictionary<string, string> NCD = new Dictionary<string, string>()
        {
            {"StartPage","منوی اصلی"},
            {"LoginPage","صفحه ورود"},
            {"Evaluation2Search","جستجو جلسه فنی"},
            {"Evaluation1Search","جستجو جلسه مشاور"},
            {"TenderingMainMenu","منوی مناقصات"},
            {"EvaluationReport","گزارش جلسه ارزیابی"},
            {"Evaluation1_1","جلسه ارزیابی کیفی"},
            {"Evaluation1","ارزیابی مشاور ص1"},
            {"Evaluation2","ارزیابی - امتیازدهی"},
            {"ContractorsSearch", "جستجوی شرکتها"},
            {"Contractors","اطلاعات شرکتها"},
            {"FindUser","جستجوی کاربران"},
            {"NewUser","اطلاعات کاربر"},
            {"OrganizationalChart","چارت سازمانی"},
            {"UserMainMenu","منو اصلی کاربران"},
            {"RegulationsPage1","اطلاعات آیین نامه"},
            {"RegulationsPage2","جستجوی آیین نامه ها"},
            {"RegulationsMainMenu","منوی آیین نامه ها"},
            {"ContractsMainMenu","منوی اصلی قراردادها"},
            {"ContractsCreate","اطلاعات قرارداد"},
            {"TransfersManagement","مدیریت حواله ها"},
            {"NewPaymentTransfer","صدور حواله جدید"},
            {"ContractDocuments","اسناد قرارداد"},
            {"ContractsSearch","جستجوی قراردادها"},
            {"SearchTenderInformation","جستجوی مناقصه"},
            {"UI1choosingCntrctrReq","درخواست انتخاب"},
            {"UI3PresidentOrder","دستور مدیر کل"},
            {"UI4HoldingTenderSesion","جلسه برگزاری مناقصه"},
            {"UI6TenderingNotice","فراخوان"},
            {"UI8ExtendSesion","جلسه تمدید"},
            {"UI9JustificationSesion","جلسه توجیهی"},
            {"TenderingArchiveSearch","جستجوی آرشیو"},
            {"PriceEvaluation","ارزیابی قیمت"},
            {"PriceEvaluation1","ارزیابی شرکتها"},
            {"CreateNotice","ایجاد فراخوان"},
            {"NoticeRequest","درخواست فراخوان"},
            {"NoticeSearch","جستجوی فراخوان"},
            {"SystemLogsManagement","مدیریت لاگ"},
            {"ContractorSelection"," انتخاب شرکتها"},
            {"Tazmin","ثبت پاکات تضمین"},
            {"UI10DocsPresentation","ارائه اسناد"},
            {"UI13packetPresentationt","تسلیم پاکات"},
            {"UI14OnePhaseReopening","بازگشایی پاکات"},
            {"UI18RegisterPriceOffer","پیشنهاد قیمت"},
            {"UI19TenderResult","ثبت نتیجه"},
            {"SelfState","مدیریت خوداظهاری"},
            {"TenderAdvancedSearch","گزارش مناقصات"},
            {"Web_DocContractor","دانلود اسناد"},
            

            
        };


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                string temp = value as string;
                temp = temp.Substring(temp.LastIndexOf(@"/") + 1);
                if (temp.IndexOf(".xaml") != -1)
                {
                    temp = temp.Substring(0, temp.LastIndexOf(@".xaml"));
                }
                return NCD[temp];
            }
            catch (System.Exception ex)
            {
                return "صفحه قبلی";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

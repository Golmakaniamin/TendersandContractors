using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTM.Classes.ReportQueries
{
    public class TenderingReport
    {
        public int TenderingId = 0;
        public int ChartNodeId = 0;
        public int ChartNodeId1 = 0;
        public int TenderingResultId = 0;
        public int ContractorId = 0;
        public int ContractorRequestId = 0;
        public string RequestNumber = "";
        public string PersianDate1 = "";
        public DateTime RequestDate;
        public string TenderingNumber = "";
        public string TenderingType = "";
        public string ProjectTitle = "";
        public string Title = "";
        public string Title1 = "";
        public string RequiredField = "";
        public bool Renewal = false;
        public string CompanyName = "";
        public string NationalIdNumber;
        public string PersianDate2 = "";
        public DateTime TenderingRecordDate = new DateTime();
        public string PersianDate3 = "";
        public DateTime Date = new DateTime();
        public string tmp1 = "";
        public string tmp2 = "";
    }
    public class ContractReport
    {
        public int Contractid;
        public int ContractorId;
        public int ContractorId_1;
        public int ContractTypeId;
        public int TenderingId;
        public string tmp1;
        public string ContractNumber;
        public string TenderingSystemCode;
        public DateTime AgreementDate;
        public string ContractTtile;
        public string CompanyName;
        public string CompanyName1;
        public string ContractType;
        public string PersianDate;
        public decimal ContractBudget;
    }
    public class EvalReport
    {
        public string PersianDate;
        public int EvaluationId;
        public bool MeetingType;
        public string TenderingNumber;
        public string NoticeNumber;
        public DateTime MeetingDate;
        public string Title;
    }
    public class RegulReport
    {
        public int RegulationId;
        public string Title;
        public string Type;
        public string Group;
        public int IssuingReferenceId;
        public DateTime IssuingDate;
        public string PersianDate;
        public string tmp1;
        public string tmp2;
    }
    public class Reports
    {
        //public static List<TenderingReport> SearchTenderingReport(List<Tendering> list)
        //{
        //    try
        //    {
        //        using (var en = new RTMEntities())
        //        {
        //            var res = (
        //                from tens in list
        //                from reqs in en.ContractorRequests
        //                from wins in en.TenderingResults
        //                from orgs1 in en.OrganizationalCharts
        //                from orgs2 in en.OrganizationalCharts
        //                from c in en.Contractors
        //                where tens.TenderingId == wins.TenderingId &&
        //                tens.ContractorRequestId == reqs.ContractorRequestId &&
        //                reqs.RequestingUnit == orgs1.ChartNodeId &&
        //                reqs.SupervisionId == orgs2.ChartNodeId &&
        //                wins.FirstContractorWinnerId == c.ContractorId
        //                select new TenderingReport
        //                {
        //                    ContractorRequestId = reqs.ContractorRequestId,
        //                    RequestNumber = reqs.RequestNumber,
        //                    RequestDate = (DateTime)reqs.RequestDate,
        //                    TenderingId = tens.TenderingId,
        //                    ChartNodeId = orgs1.ChartNodeId,
        //                    ChartNodeId1 = orgs2.ChartNodeId,
        //                    TenderingNumber = tens.TenderingNumber,
        //                    TenderingType = tens.TenderingType,
        //                    ProjectTitle = reqs.ProjectTitle,
        //                    Title = orgs1.Title,
        //                    tmp1 = orgs1.Title,
        //                    Title1 = orgs2.Title,
        //                    tmp2 = orgs2.Title,
        //                    RequiredField = reqs.RequiredField,
        //                    Renewal = wins.Renewal,
        //                    TenderingResultId = wins.TenderingResultId,
        //                    ContractorId = c.ContractorId,
        //                    CompanyName = c.CompanyName,
        //                    NationalIdNumber = c.NationalIdNumber,
        //                    TenderingRecordDate = (DateTime)tens.TenderingRecordDate,
        //                    Date = (DateTime)wins.Date
        //                }


        //                           ).ToList();
        //            //var res2 = (
        //            //    from tens in list
        //            //    //from reqs in en.ContractorRequests

        //            //    //from orgs1 in en.OrganizationalCharts
        //            //    //from orgs2 in en.OrganizationalCharts

        //            //    where true
        //            //    //tens.ContractorRequestId == reqs.ContractorRequestId 
        //            //    //reqs.RequestingUnit == orgs1.ChartNodeId &&
        //            //    //reqs.SupervisionId == orgs2.ChartNodeId

        //            //    select new TenderingReport
        //            //    {
        //            //        ContractorRequestId = 0,//reqs.ContractorRequestId,
        //            //        RequestNumber = "",//reqs.RequestNumber,
        //            //        RequestDate = DateTime.Now,//(DateTime)reqs.RequestDate,
        //            //        TenderingId = 0,//tens.TenderingId,
        //            //        ChartNodeId = 0,//orgs1.ChartNodeId,
        //            //        ChartNodeId1 = 0,//orgs2.ChartNodeId,
        //            //        TenderingNumber =tens.TenderingNumber,
        //            //        TenderingType = "",//tens.TenderingType,
        //            //        ProjectTitle = "",//reqs.ProjectTitle,
        //            //        Title = "",//orgs1.Title,
        //            //        Title1 = "",//orgs2.Title,
        //            //        RequiredField = "",//reqs.RequiredField,
        //            //        Renewal = false,
        //            //       TenderingResultId = 0,
        //            //        ContractorId =0,
        //            //        CompanyName = "",
        //            //        NationalIdNumber = "",
        //            //        TenderingRecordDate = DateTime.Now,//(DateTime)tens.TenderingRecordDate,
        //            //        Date =DateTime.Now
        //            //    }


        //            //               );
        //            var temp = from items in res select items.TenderingId;

        //            var res2 = (
        //                from tens in list
        //                from reqs in en.ContractorRequests
        //                from orgs1 in en.OrganizationalCharts
        //                from orgs2 in en.OrganizationalCharts
        //                where 
        //                tens.ContractorRequestId == reqs.ContractorRequestId &&
        //                !temp.Contains(tens.TenderingId) &&
        //                reqs.RequestingUnit == orgs1.ChartNodeId &&
        //                reqs.SupervisionId == orgs2.ChartNodeId 
        //                select new TenderingReport
        //                {
        //                    ContractorRequestId = reqs.ContractorRequestId,
        //                    RequestNumber = reqs.RequestNumber,
        //                    RequestDate = (DateTime)reqs.RequestDate,
        //                    TenderingId = tens.TenderingId,
        //                    ChartNodeId = orgs1.ChartNodeId,
        //                    ChartNodeId1 = orgs2.ChartNodeId,
        //                    TenderingNumber = tens.TenderingNumber,
        //                    TenderingType = tens.TenderingType,
        //                    ProjectTitle = reqs.ProjectTitle,
        //                    Title = orgs1.Title,
        //                    tmp1 = orgs1.Title,
        //                    Title1 = orgs2.Title,
        //                    tmp2 = orgs2.Title,
        //                    RequiredField = reqs.RequiredField,
        //                    //Renewal = wins.Renewal,
        //                    //TenderingResultId = tens.TenderingId,
        //                    //ContractorId = tens.TenderingId,
        //                    //CompanyName = c.CompanyName,
        //                    //NationalIdNumber = c.NationalIdNumber,
        //                    TenderingRecordDate = (tens.TenderingRecordDate!=null?(DateTime)tens.TenderingRecordDate:new DateTime()),
        //                    //Date = (DateTime)wins.Date
        //                });
        //            var t = res.Union(res2).ToList();

        //            var x = new DateConverterGrid();
        //            foreach (var item in t)
        //            {
        //                try
        //                {
        //                    item.PersianDate1 = (x).Convert(item.RequestDate, null, null, null).ToString();
        //                }
        //                catch (System.Exception ex)
        //                {
        //                    item.PersianDate1 = "";
        //                }
        //                try
        //                {
        //                    item.PersianDate2 = (item.TenderingRecordDate!=null?(x).Convert(item.TenderingRecordDate, null, null, null).ToString():"");
        //                }
        //                catch (System.Exception ex)
        //                {
        //                    item.PersianDate2 = "";
        //                }
        //                try
        //                {
        //                    item.PersianDate3 = (x).Convert(item.Date, null, null, null).ToString();
        //                }
        //                catch (System.Exception ex)
        //                {
        //                    item.PersianDate3 = "";
        //                }
        //            }
        //            return t;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return null;
        //    }
        //}
        public static List<TenderingReport> SearchTenderingReport(List<Tendering> list)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var res = (
                        from tens in list
                        from reqs in en.ContractorRequests
                        from orgs1 in en.OrganizationalCharts
                        from orgs2 in en.OrganizationalCharts
                        where
                        tens.ContractorRequestId == reqs.ContractorRequestId &&
                        reqs.RequestingUnit == orgs1.ChartNodeId &&
                        reqs.SupervisionId == orgs2.ChartNodeId 
                        select new TenderingReport
                        {
                            ContractorRequestId = reqs.ContractorRequestId,
                            RequestNumber = reqs.RequestNumber,
                            RequestDate = (DateTime)reqs.RequestDate,
                            TenderingId = tens.TenderingId,
                            TenderingNumber = tens.TenderingNumber,
                            TenderingType = tens.TenderingType,
                            ProjectTitle = reqs.ProjectTitle,
                            RequiredField = reqs.RequiredField,
                            Title = orgs1.Title,
                            tmp1 = orgs1.Title,
                            Title1 = orgs2.Title,
                            tmp2 = orgs2.Title,
                            TenderingRecordDate = (tens.TenderingRecordDate != null ? (DateTime)tens.TenderingRecordDate : new DateTime())
                        }).ToList();
                    
                    var x = new DateConverterGrid();
                    foreach (var item in res)
                    {
                        try
                        {
                            item.PersianDate1 = (x).Convert(item.RequestDate, null, null, null).ToString();
                        }
                        catch (System.Exception ex)
                        {
                            item.PersianDate1 = "";
                        }
                        try
                        {
                            item.PersianDate2 = (item.TenderingRecordDate != null ? (x).Convert(item.TenderingRecordDate, null, null, null).ToString() : "");
                        }
                        catch (System.Exception ex)
                        {
                            item.PersianDate2 = "";
                        }
                    }
                    return res;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }
        public static List<ContractReport> SearchContractReport(List<Contract> list)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    
                    var res = (
                        from crt in list
                        from c1 in en.Contractors
                        from type in en.ContractTypes
                        from tens in en.Tenderings
                        where crt.ContractTypeId == type.ContractTypeId &&
                        c1.ContractorId == crt.ContractorId &&
                        //c2.ContractorId == crt.ConsultantId &&
                        tens.TenderingNumber == crt.TenderingSystemCode
                        select new ContractReport
                        {
                            Contractid = crt.Contractid,
                            ContractorId = c1.ContractorId,
                            /*ContractorId_1 = c2.ContractorId,*/
                            ContractTypeId = type.ContractTypeId,
                            ContractNumber = crt.ContractNumber,
                            TenderingId = tens.TenderingId,
                            TenderingSystemCode = crt.TenderingSystemCode,
                            AgreementDate = (DateTime)crt.AgreementDate,
                            ContractTtile = crt.ContractTtile,
                            CompanyName = c1.CompanyName,
                            //CompanyName1 = c2.CompanyName,
                            ContractType = type.ContractType1,
                            PersianDate = "",
                            //tmp1 = c2.CompanyName,
                            ContractBudget = (decimal)(crt.ContractBudget)
                        }).ToList();
                    var x = new DateConverterGrid();
                    foreach (var item in res)
                    {
                        item.PersianDate = (x).Convert(item.AgreementDate, null, null, null).ToString();

                    }
                    return res;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static List<EvalReport> SearchEvaluationReport(List<Evaluation> list)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var res = (
                        from ev in list
                        select new EvalReport
                        {
                            EvaluationId = ev.EvaluationId,
                            MeetingType = ev.MeetingType,
                            TenderingNumber = ev.TenderingNumber,
                            NoticeNumber = ev.NoticeNumber,
                            MeetingDate = (DateTime)ev.MeetingDate,
                            PersianDate = "",
                            Title = ev.Title
                        }


                                   ).ToList();
                    var x = new DateConverterGrid();
                    foreach (var item in res)
                    {
                        item.PersianDate = (x).Convert(item.MeetingDate, null, null, null).ToString();

                    }
                    return res;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static List<RegulReport> SearchRegulationReport(List<Regulation> list)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var res = (
                        from r in list
                        from s in en.OrganizationalCharts
                        from x2 in en.IssuingReferences
                        where s.ChartNodeId == r.ActingReferenceId &&
                        x2.IssuingReferenceId == r.IssuingReferenceId
                        select new RegulReport
                        {
                            RegulationId = r.RegulationId,
                            Title = r.Title,
                            tmp1 = s.Title,
                            tmp2 = x2.Title,
                            Type = r.Type,
                            Group = r.Group,
                            IssuingReferenceId = r.IssuingReferenceId,
                            IssuingDate = (DateTime)r.IssuingDate,
                            PersianDate = ""
                        }


                                   ).ToList();
                    var x = new DateConverterGrid();
                    foreach (var item in res)
                    {
                        item.PersianDate = (x).Convert(item.IssuingDate, null, null, null).ToString();

                    }
                    return res;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
    }
}

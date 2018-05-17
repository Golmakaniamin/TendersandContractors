using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.Data.Objects;

namespace RTM.Classes
{
    class DataManagement
    {
        public static List<RTM.OrganizationalChart> RetrieveOrganizationChart()
        {
            var entity = new RTMEntities();
            try
            {
                var organs = from nodes in entity.OrganizationalCharts select nodes;
                return organs.ToList();
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("در حال حاضر دسترسی به سرور امکان پذیر نیست");
            }
            return null;
        }



        public static int CreateAccessRight(bool? ContractRead, bool? ContractWrite, bool? ContractDelete
      , bool? ContractPermanentWrite, bool? TenderingRead, bool? TenderingWrite, bool? TenderingDelete, bool? TenderingPermanentWrite
      , bool? TenderingArchiveRead, bool? TenderingArchiveWrite, bool? TenderingArchiveDelete, bool? RegulationRead, bool? RegulationWrite
      , bool? RegulationDelete, bool? RegulationPermanentWrite, bool? ContractLog, bool? RegulationLog, bool? TenderingLog, bool? TenderingArchiveLog
      , bool? CreatingUser, bool? TenderArchivePermanentWrite, bool? SelfRegisterManagement)
        {
            var access = new RTM.AccessRight();
            access.ContractRead = (bool)ContractRead;
            access.ContractWrite = (bool)ContractWrite;
            access.ContractDelete = (bool)ContractDelete;
            access.ContractPermanentWrite = (bool)ContractPermanentWrite;
            access.TenderingRead = (bool)TenderingRead;
            access.TenderingWrite = (bool)TenderingWrite;
            access.TenderingDelete = (bool)TenderingDelete;
            access.TenderingPermanentWrite = (bool)TenderingPermanentWrite;
            access.TenderingArchiveRead = (bool)TenderingArchiveRead;
            access.TenderingArchiveWrite = (bool)TenderingArchiveWrite;
            access.TenderingArchiveDelete = (bool)TenderingArchiveDelete;
            access.TenderingArchivePermanentWrite = (bool)TenderArchivePermanentWrite;
            access.RegulationRead = (bool)RegulationRead;
            access.RegulationWrite = (bool)RegulationWrite;
            access.RegulationDelete = (bool)RegulationDelete;
            access.RegulationPermanentWrite = (bool)RegulationPermanentWrite;
            access.ContractLog = (bool)ContractLog;
            access.RegulationLog = (bool)RegulationLog;
            access.TenderingLog = (bool)TenderingLog;
            access.TenderingArchiveLog = (bool)TenderingArchiveLog;
            access.CreatingUser = (bool)CreatingUser;
            access.ContractWrite = (bool)SelfRegisterManagement;


            var entity = new RTMEntities();
            try
            {
                entity.AccessRights.AddObject(access);
                entity.SaveChanges();
                CreateLog('C', (((int)(SubSystem.UserManagement)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
                return -1;
            }
            return access.AccessId;
        }

        public static int EditAccessRight(bool? ContractRead, bool? ContractWrite, bool? ContractDelete
      , bool? ContractPermanentWrite, bool? TenderingRead, bool? TenderingWrite, bool? TenderingDelete, bool? TenderingPermanentWrite
      , bool? TenderingArchiveRead, bool? TenderingArchiveWrite, bool? TenderingArchiveDelete, bool? RegulationRead, bool? RegulationWrite
      , bool? RegulationDelete, bool? RegulationPermanentWrite, bool? ContractLog, bool? RegulationLog, bool? TenderingLog, bool? TenderingArchiveLog
      , bool? CreatingUser, bool? TenderArchivePermanentWrite,bool? SelfRegisterManagement, int accessId)
        {


            var entity = new RTMEntities();
            try
            {
                var access = (from item in entity.AccessRights where item.AccessId == accessId select item).First();
                access.ContractRead = (bool)ContractRead;
                access.ContractWrite = (bool)ContractWrite;
                access.ContractDelete = (bool)ContractDelete;
                access.ContractPermanentWrite = (bool)ContractPermanentWrite;
                access.TenderingRead = (bool)TenderingRead;
                access.TenderingWrite = (bool)TenderingWrite;
                access.TenderingDelete = (bool)TenderingDelete;
                access.TenderingPermanentWrite = (bool)TenderingPermanentWrite;
                access.TenderingArchiveRead = (bool)TenderingArchiveRead;
                access.TenderingArchiveWrite = (bool)TenderingArchiveWrite;
                access.TenderingArchiveDelete = (bool)TenderingArchiveDelete;
                access.TenderingArchivePermanentWrite = (bool)TenderArchivePermanentWrite;
                access.RegulationRead = (bool)RegulationRead;
                access.RegulationWrite = (bool)RegulationWrite;
                access.RegulationDelete = (bool)RegulationDelete;
                access.RegulationPermanentWrite = (bool)RegulationPermanentWrite;
                access.ContractLog = (bool)ContractLog;
                access.RegulationLog = (bool)RegulationLog;
                access.TenderingLog = (bool)TenderingLog;
                access.TenderingArchiveLog = (bool)TenderingArchiveLog;
                access.CreatingUser = (bool)CreatingUser;
                access.ContractWrite = (bool)SelfRegisterManagement;
                entity.SaveChanges();
                CreateLog('U', (((int)(SubSystem.UserManagement)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
                return -1;
            }
            return accessId;
        }

        public static bool CreateUser(string userName, string password, byte[] image, string name, string family, string social,
            string phoneNumber, string status, int positionId, int organizationId, int accessRightId, bool? techCommittee, bool? consultCommittee, bool? TenderingCommitee, bool? ContractManagement, bool? ContractPayment,bool? manageContractAccess)
        {
            var user = new RTM.User();
            user.AccessId = accessRightId;
            user.OrganizationPosition = organizationId;
            user.Password = password;
            user.Username = userName;
            user.Picture = image;
            user.Name = name;
            user.Family = family;
            user.SocialNumber = social;
            user.PhoneNumber = phoneNumber;
            user.Status = status;
            user.PositionId = positionId;
            user.TechnicalCommittee = techCommittee;
            user.ConsultantCommittee = consultCommittee;
            user.TenderingCommittee = TenderingCommitee;
            user.PaymentDraftCommittee = ContractPayment;
            user.ManagingPaymentDraft = ContractManagement;
            user.Isdeleted = false;
            user.ManagingContractAccess = manageContractAccess;
            var entity = new RTMEntities();

            try
            {
                var duplicate = from users in entity.Users
                                where users.Username.ToLower() == user.Username.ToLower()
                                select users;
                if (duplicate.ToList().Count > 0)
                {
                    ErrorHandler.ShowErrorMessage("نام کاربری قبلا در سیستم ثبت شده است");
                    return false;
                }
                entity.Users.AddObject(user);
                entity.SaveChanges();
                CreateLog('C', (((int)(SubSystem.UserManagement)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("در حال حاضر دسترسی به سرور امکان پذیر نیست");
                return false;
            }

            return true;
        }

        public static bool EditUser(string userName, string password, byte[] image, string name, string family, string social,
            string phoneNumber, string status, int positionId, int organizationId, int accessRightId, int UserId, bool? techCommittee, bool? consultCommittee, bool? TenderingCommitee, bool? ContractManagement, bool? ContractPayment,bool? managingContractAccess)
        {
            var entity = new RTMEntities();
            try
            {
                var user = (from users in entity.Users where users.UserId == UserId select users).First();
                user.OrganizationPosition = organizationId;
                user.Password = password;
                user.Username = userName;
                user.Picture = image;
                user.Name = name;
                user.Family = family;
                user.SocialNumber = social;
                user.PhoneNumber = phoneNumber;
                user.Status = status;
                user.PositionId = positionId;
                user.TechnicalCommittee = techCommittee;
                user.ConsultantCommittee = consultCommittee;
                user.TenderingCommittee = TenderingCommitee;
                user.PaymentDraftCommittee = ContractPayment;
                user.ManagingPaymentDraft = ContractManagement;
                user.ManagingContractAccess = managingContractAccess;
                entity.SaveChanges();
                CreateLog('U', (((int)(SubSystem.UserManagement)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("در حال حاضر دسترسی به سرور امکان پذیر نیست");
                return false;
            }

            return true;
        }
        public static RTM.AccessRight RetrieveAccessRight(int accessId)
        {
            var entity = new RTMEntities();
            try
            {
                var organs = from nodes in entity.AccessRights where nodes.AccessId == accessId select nodes;
                return organs.ToList()[0];
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("در حال حاضر دسترسی به سرور امکان پذیر نیست");
            }
            return null;
        }

        public static int DeleteUser(int userId)
        {
            var entity = new RTMEntities();
            try
            {
                var user = (from users in entity.Users where users.UserId == userId select users).First();
                user.Isdeleted = true;
                entity.SaveChanges();
                CreateLog('D', (((int)(SubSystem.UserManagement)).ToString()[0]), "");
                return user.UserId;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }

        public static RTM.User AuthenticateUser(string userName, string password)
        {
            try
            {
                var entity = new RTMEntities();
                
                var user = (from users in entity.Users
                            where users.Username.ToLower() == userName.ToLower() &&
                                (users.Password == password) &&
                                (users.Isdeleted == false)
                            select users);
                var tttt = ((ObjectQuery)((IQueryable)user)).ToTraceString();
                if (user.ToList().Count > 0)
                {
                    return ((RTM.User)(user.ToList()[0]));
                }
                else
                    return null;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }


        public static List<RTM.User> SearchUsers(string name, string family, string position, string organ)
        {
            try
            {
                var entity = new RTMEntities();
                var x = (from po in entity.Positions where po.PositionTitle == ((position == null) ? po.PositionTitle : position) select po.PositionId).ToList();

                var t = (from uss in entity.Users where uss.Name.Contains((name == null) ? uss.Name : name) select uss.UserId).ToList();
                var f = (from uss in entity.Users where uss.Family.Contains((family == null) ? uss.Family : family) select uss.UserId).ToList();
                var userList = from users in entity.Users
                               where t.Contains(users.UserId)
                               && (x.Contains(users.PositionId))
                               && f.Contains(users.UserId)
                               && (users.Isdeleted == false)
                               && (from orgs in entity.OrganizationalCharts
                                   where orgs.Title == ((organ == null) ? orgs.Title : organ)
                                   select orgs.ChartNodeId).Contains(users.OrganizationPosition)
                               select users;

                return userList.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        private static void CreateLog(char action, char subsystem , string Desc)
        {
            try
            {
                var entity = new RTMEntities();
                var log = new Log()
                {
                    Action = action.ToString(),
                    Date = DateTime.Now,
                    Description = Desc,
                    Subsystem = subsystem.ToString(),
                    UserId = UserData.CurrentUser.UserId,
                    MachineName = Environment.MachineName
                };
                entity.AddToLogs(log);
                entity.SaveChanges();
            }
            catch (System.Exception ex)
            {
                return;
            }
        }

        public static Evaluation CreateEvaluationForm(int minScore, DateTime meetingDate, string title, string tenderingNumber, List<User> users, List<Contractor> contractors, bool isConsultant, bool isContractor, string noticeNumber, bool HasTendering = false, bool permanentRecord = false)
        {
            try
            {
                var entity = new RTMEntities();
                var eval = new Evaluation();
                eval.MinimumScore = minScore;
                eval.MeetingDate = meetingDate;
                eval.Title = title;
                eval.PermanentRecord = false;
                eval.IsConsultantMeeting = isConsultant;
                eval.IsContractorMeeting = isContractor;
                eval.IsDeleted = false;
                eval.HasTendering = HasTendering;
                eval.NoticeNumber = noticeNumber;
                if (eval.HasTendering == true)
                    eval.TenderingNumber = tenderingNumber;
                entity.Evaluations.AddObject(eval);
                entity.SaveChanges();
                foreach (var item in users)
                {
                    entity.UserEvaluationMembers.AddObject(new UserEvaluationMember() { UserId = item.UserId, EvaluationId = eval.EvaluationId });
                }
                foreach (var item in contractors)
                {
                    entity.EvaluationContractors.AddObject(new EvaluationContractor() { ContractorId = item.ContractorId, EvaluationId = eval.EvaluationId });
                }
                entity.SaveChanges();
                CreateLog('C', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                return eval;

            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static int EditEvaluationForm(int evaluationId, int minScore, DateTime meetingDate, string title, string tenderingNumber, List<User> users, List<Contractor> contractors, bool isConsultant, bool isContractor, string noticeNumber, string description, bool HasTendering = false, bool permanentRecord = false)
        {
            try
            {
                var entity = new RTMEntities();
                var eval = (from items in entity.Evaluations where items.EvaluationId == evaluationId select items).FirstOrDefault();
                eval.MinimumScore = minScore;
                eval.MeetingDate = meetingDate;
                eval.Title = title;
                eval.TenderingNumber = tenderingNumber;
                eval.PermanentRecord = permanentRecord;
                eval.IsConsultantMeeting = isConsultant;
                eval.IsContractorMeeting = isContractor;
                eval.NoticeNumber = noticeNumber;
                eval.Description = description;
                entity.SaveChanges();

                var uem = (from items in entity.UserEvaluationMembers where items.EvaluationId == eval.EvaluationId select items).ToList();
                var ec = (from items in entity.EvaluationContractors where items.EvaluationId == eval.EvaluationId select items).ToList();

                foreach (var item in uem)
                {
                    entity.UserEvaluationMembers.DeleteObject(item);
                }
                foreach (var item in ec)
                {
                    entity.EvaluationContractors.DeleteObject(item);
                }
                entity.SaveChanges();
                foreach (var item in users)
                {
                    entity.UserEvaluationMembers.AddObject(new UserEvaluationMember() { UserId = item.UserId, EvaluationId = eval.EvaluationId });
                }
                foreach (var item in contractors)
                {
                    entity.EvaluationContractors.AddObject(new EvaluationContractor() { ContractorId = item.ContractorId, EvaluationId = eval.EvaluationId });
                }
                entity.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                return eval.EvaluationId;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }
        public static int EditEvaluationForm(int evaluationId, string description)
        {
            try
            {
                var entity = new RTMEntities();
                var eval = (from items in entity.Evaluations where items.EvaluationId == evaluationId select items).FirstOrDefault();
                eval.Description = description;
                entity.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                return eval.EvaluationId;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }
        public static Evaluation CreateEvaluation(Evaluation eval, List<User> users)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    eval.PermanentRecord = false;
                    en.AddToEvaluations(eval);
                    foreach (var item in users)
                    {
                        en.UserEvaluationMembers.AddObject(new UserEvaluationMember() { UserId = item.UserId, EvaluationId = eval.EvaluationId });
                    }
                    en.SaveChanges();
                    CreateLog('C', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                    return eval;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static Evaluation UpdateEvaluation(Evaluation eval)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var t = (from items in en.Evaluations where items.EvaluationId == eval.EvaluationId select items).FirstOrDefault();
                    
                    t.Description = eval.Description;
                    t.HasTendering = eval.HasTendering;
                    t.IsConsultantMeeting = eval.IsConsultantMeeting;
                    t.IsContractorMeeting = eval.IsContractorMeeting;
                    t.IsDeleted = eval.IsDeleted;
                    t.MeetingDate = eval.MeetingDate;
                    t.MinimumScore = eval.MinimumScore;
                    t.NoticeNumber = eval.NoticeNumber;
                    t.PermanentRecord = eval.PermanentRecord;
                    t.TenderingNumber = eval.TenderingNumber;
                    t.Title = eval.Title;
                    en.SaveChanges();
                    
                    CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                    return t;
                }

            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

       
        public static Evaluation UpdateEvaluation(Evaluation eval, List<User> users)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    en.Evaluations.Attach(en.Evaluations.First());
                    en.Evaluations.ApplyCurrentValues(eval);
                    var t = (from items in en.Evaluations where items.EvaluationId == eval.EvaluationId select items).FirstOrDefault();
                    t.Description = eval.Description;
                    t.HasTendering = eval.HasTendering;
                    t.IsConsultantMeeting = eval.IsConsultantMeeting;
                    t.IsContractorMeeting = eval.IsContractorMeeting;
                    t.IsDeleted = eval.IsDeleted;
                    t.MeetingDate = eval.MeetingDate;
                    t.MinimumScore = eval.MinimumScore;
                    t.NoticeNumber = eval.NoticeNumber;
                    t.PermanentRecord = eval.PermanentRecord;
                    t.TenderingNumber = eval.TenderingNumber;
                    t.Title = eval.Title;
                    var uem = (from items in en.UserEvaluationMembers where items.EvaluationId == eval.EvaluationId select items).ToList();
                    foreach (var item in uem)
                    {
                        en.UserEvaluationMembers.DeleteObject(item);
                    }
                    en.SaveChanges();
                    var sql = ((System.Data.Objects.ObjectQuery)en.Evaluations).ToTraceString();
                    foreach (var item in users)
                    {
                        en.UserEvaluationMembers.AddObject(new UserEvaluationMember() { UserId = item.UserId, EvaluationId = eval.EvaluationId });
                    }
                    en.SaveChanges();
                    CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                    return t;
                }

            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static int AddEvaulationStandard(List<EvalStandardScore> standards, int evaluationId)
        {
            try
            {
                var entity = new RTMEntities();
                foreach (var item in standards)
                {
                    var temp = new EvaluationStandardRelation();
                    temp.Weight = item.Weight;
                    temp.Score = item.Score;
                    temp.EvaluationId = evaluationId;
                    temp.StandardId = item.StandardId;
                    entity.EvaluationStandardRelations.AddObject(temp);
                }
                entity.SaveChanges();
                CreateLog('C', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                return 1;

            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }

        public static List<Evaluation> SearchEvaluations(int? evaluationId, string tenderingNumber, string noticeNumber, string title, DateTime? startMeetingDate, DateTime? finishMeetingDate, bool? contractor, bool? consultant,bool? type)
        {
            try
            {
                var entity = new RTMEntities();
                var result = from items in entity.Evaluations
                             where (evaluationId == null || items.EvaluationId == evaluationId)
                                 && (tenderingNumber == null || items.TenderingNumber == tenderingNumber)
                                 && (noticeNumber == null || items.NoticeNumber == noticeNumber)
                                 && (title == null || items.Title.Contains(title))
                                 && (startMeetingDate == null || (items.MeetingDate >= startMeetingDate))
                                 && (finishMeetingDate == null || (items.MeetingDate <= finishMeetingDate))
                                 && (contractor == null || items.IsContractorMeeting == contractor)
                                 && (consultant == null || items.IsConsultantMeeting == consultant)
                                 && (items.IsDeleted == false) &&
                                 (type ==null || items.MeetingType == type)
                             select items;
                return result.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static List<EvalStandard> RetrieveEvalStandards(bool isContractor, bool isConsultant)
        {
            try
            {
                var entity = new RTMEntities();
                var result = from items in entity.EvalStandards
                             where items.ContractorStandard == isContractor &&
                                 items.ConsultantStandard == isConsultant

                             select items;
                return result.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static int CreateEvalStandard(int index, string title, bool consultant, bool contractor)
        {
            try
            {
                var entity = new RTMEntities();
                EvalStandard s = new EvalStandard();
                s.Index = index;
                s.Title = title;
                s.ConsultantStandard = consultant;
                s.ContractorStandard = contractor;
                entity.EvalStandards.AddObject(s);
                entity.SaveChanges();
                CreateLog('C', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                return s.StandardId;

            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }

        public static int CreatePosition(string title)
        {
            try
            {
                var entity = new RTMEntities();
                Position pos = new Position();
                pos.PositionTitle = title;
                entity.Positions.AddObject(pos);

                entity.SaveChanges();
                CreateLog('C', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                return pos.PositionId;

            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }

        public static List<User> RetrieveTechnicalCommittee()
        {
            try
            {
                var entity = new RTMEntities();
                var result = from item in entity.Users
                             where item.TechnicalCommittee == true && item.Isdeleted == false
                             select item;
                return result.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static List<User> RetrieveTenderingCommittee()
        {
            try
            {
                var entity = new RTMEntities();
                var result = from item in entity.Users
                             where item.TenderingCommittee == true && item.Isdeleted == false
                             select item;
                return result.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static List<User> RetrieveConsultantCommittee()
        {
            try
            {
                var entity = new RTMEntities();
                var result = from item in entity.Users where item.ConsultantCommittee == true select item;
                return result.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static int CreateContractor(string companyName, string commercialName, string companyType, string province, string city, string address, string postalCode,
            string postalbox, string telephone, string fax, string ceoName, string ceoFamily,
            string ceoSocialNumber, string ceoEmail, string ceoTel, string ceoMobile, bool isContractor, bool isConsultant, bool fieldOfWork1, bool fieldOfWork2, bool fieldOfWork3, string compField1, string compField2,
            int compBase1, int compBase2, bool blackList, bool isInWaitingList, string waitingnote, bool isDocDefect, string defectnote, bool isrejected, string rejectionNote,
            bool isApproved, string approveNote, bool permanentRec, string field1File, string field2File, string recordNumber, string nationalID, bool design, bool procure, bool build, bool finance, bool isdeleted = false,string Tax="")
        {
            try
            {
                var entity = new RTMEntities();
                Contractor c = new Contractor();
                c.Address = address;
                c.ApprovedNote = approveNote;
                c.BlackListed = blackList;

                c.CeoEmailAddress = ceoEmail;
                c.CeoFamily = ceoFamily;
                c.CeoMobilePhone = ceoTel;
                c.CeoName = ceoName;

                c.CeoTelephone = ceoMobile;
                c.City = city;
                c.CommercialName = commercialName;
                c.CompanyBase1 = compBase1;
                c.CompanyBase2 = compBase2;
                c.CompanyField1 = compField1;
                c.CompanyField2 = compField2;
                c.CompanyName = companyName;
                c.CompanyType = companyType;
                c.Fax = fax;
                c.Field1File = field1File;
                c.Field2File = field2File;
                c.FieldofWork1 = fieldOfWork1;
                c.FieldofWork2 = fieldOfWork2;
                c.FieldofWork3 = fieldOfWork3;
                c.CeoSocialNumber = ceoSocialNumber;
                c.IsApproved = isApproved;
                c.IsConsultant = isConsultant;
                c.IsContractor = isContractor;
                c.IsDeleted = isdeleted;
                c.IsDocumentDefected = isDocDefect;
                c.IsInWaitingList = true;
                c.IsRejected = isrejected;

                c.NationalIdNumber = nationalID;
                c.RecordNumber = recordNumber;
                c.PermanentRecord = permanentRec;
                c.PostalBox = postalbox;
                c.PostalCode = postalCode;
                c.Province = province;
                c.RejectionNote = rejectionNote;
                c.Telephone = telephone;
                c.WaitingListNote = waitingnote;

                c.Design = design;
                c.Procurement = procure;
                c.BuildAndOperation = build;
                c.Finance = finance;
                c.TaxNumber = Tax;

                entity.Contractors.AddObject(c);
                entity.SaveChanges();
                CreateLog('C', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                return c.ContractorId;

            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }

        public static int EditContractor(int Id, string companyName, string commercialName, string companyType, string province, string city, string address, string postalCode,
            string postalbox, string telephone, string fax, string ceoName, string ceoFamily,
            string ceoSocialNumber, string ceoEmail, string ceoTel, string ceoMobile, bool isContractor, bool isConsultant, bool fieldOfWork1, bool fieldOfWork2, bool fieldOfWork3, string compField1, string compField2,
            int? compBase1, int? compBase2, bool blackList, bool isInWaitingList, string waitingnote, bool isDocDefect, string defectnote, bool isrejected, string rejectionNote,
            bool isApproved, string approveNote, bool permanentRec, string field1File, string field2File, string recordNumber, string nationalID, bool design, bool procure, bool build, bool finance, bool isdeleted = false,string Tax="")
        {
            try
            {
                var entity = new RTMEntities();
                var c = (from items in entity.Contractors where items.ContractorId == Id select items).FirstOrDefault();
                c.Address = address;
                c.ApprovedNote = approveNote;
                c.BlackListed = blackList;
                c.CeoEmailAddress = ceoEmail;
                c.CeoFamily = ceoFamily;
                c.CeoMobilePhone = ceoTel;
                c.CeoName = ceoName;
                c.CeoSocialNumber = ceoSocialNumber;
                c.CeoTelephone = ceoMobile;
                c.City = city;
                c.CommercialName = commercialName;
                c.CompanyBase1 = compBase1;
                c.CompanyBase2 = compBase2;
                c.CompanyField1 = compField1;
                c.CompanyField2 = compField2;
                c.CompanyName = companyName;
                c.CompanyType = companyType;
                c.Fax = fax;
                c.Field1File = field1File;
                c.Field2File = field2File;
                c.FieldofWork1 = fieldOfWork1;
                c.FieldofWork2 = fieldOfWork2;
                c.FieldofWork3 = fieldOfWork3;
                c.IsApproved = isApproved;
                c.IsConsultant = isConsultant;
                c.IsContractor = isContractor;
                c.IsDeleted = isdeleted;
                c.IsDocumentDefected = isDocDefect;
                c.IsInWaitingList = true;
                c.IsRejected = isrejected;
                c.RecordNumber = recordNumber;
                c.NationalIdNumber = nationalID;
                c.PermanentRecord = permanentRec;
                c.PostalBox = postalbox;
                c.PostalCode = postalCode;
                c.Province = province;
                c.RejectionNote = rejectionNote;
                c.Telephone = telephone;
                c.WaitingListNote = waitingnote;

                c.Design = design;
                c.Procurement = procure;
                c.BuildAndOperation = build;
                c.Finance = finance;
                c.TaxNumber = Tax;

                entity.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                return c.ContractorId;

            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }

        public static int DeleteContractor(int Id)
        {
            var entity = new RTMEntities();
            try
            {
                var c = (from items in entity.Contractors where items.ContractorId == Id select items).FirstOrDefault();
                c.IsDeleted = true;
                c.Password = "@#@";
                entity.SaveChanges();
                CreateLog('D', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                return c.ContractorId;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }

        public static List<Contractor> SearchContractors(string companyName, string nationalId, string commercialName, bool? isContractor, bool? isConsultant,string Field="",string Base="")
        {
            try
            {
                var entity = new RTMEntities();

                bool has = false;
                int number = 0;
                has = Int32.TryParse(Base,out number);
                var t = (from uss in entity.Contractors
                         where (uss.CompanyName.Contains((companyName == null) ? uss.CompanyName : companyName)) &&
                             //(uss.NationalIdNumber.Contains((nationalId == null) ? uss.NationalIdNumber : nationalId)) &&
                         (nationalId == null || uss.NationalIdNumber == nationalId) &&
                         (commercialName == null || uss.CommercialName.Contains(commercialName)) &&
                         (isConsultant == null || uss.IsConsultant == isConsultant) &&
                         (isContractor == null || uss.IsContractor == isContractor) &&
                         (Field == "" || uss.CompanyField1 == Field) &&
                         (! has||uss.CompanyBase1 == number    ) &&
                         (uss.IsApproved == true)&&
                         (uss.IsInWaitingList == false) &&
                         (uss.IsDeleted == false)
                         select uss).ToList();
                
                return t.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static List<Contractor> RetrieveContractorsInWaitingList()
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var result = from items in en.Contractors where items.IsInWaitingList == true where items.IsDeleted==false select items;
                    return result.ToList();
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static List<Contractor> RetrieveApprovedContractors()
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var result = from items in en.Contractors where items.IsApproved == true where items.IsDeleted == false select items;
                    return result.ToList();
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static void ToggleContractorState(Contractor c)
        {

            try
            {
                using (var en = new RTMEntities())
                {
                    var t = (from items in en.Contractors where items.ContractorId == c.ContractorId select items).FirstOrDefault();
                    if (t.IsInWaitingList == true)
                    {
                        t.IsInWaitingList = false;
                        t.IsApproved = true;
                        en.SaveChanges();
                    }
                    else if (t.IsApproved == true)
                    {
                        t.IsApproved = false;
                        t.IsInWaitingList = true;
                        en.SaveChanges();
                    }
                    CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        public static int DeleteEvaluation(int evalId)
        {
            var entity = new RTMEntities();
            try
            {
                var c = (from items in entity.Evaluations where items.EvaluationId == evalId select items).FirstOrDefault();
                c.IsDeleted = true;
                entity.SaveChanges();
                CreateLog('D', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                return c.EvaluationId;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }

        private static List<Contractor> RetrieveEvaluationContractors(int evaluationId)
        {
            try
            {
                var entity = new RTMEntities();

                var t2 = (from items in entity.EvaluationContractors where items.EvaluationId == evaluationId select items.ContractorId).ToList();
                var t = (from uss in entity.Contractors
                         where (t2.Contains((int)uss.ContractorId)) &&
                         (uss.IsDeleted == false)
                         select uss).ToList();

                return t.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static List<ContractorWithTotalScore> RetrieveEvaluationContractorsWithScoreSum(int evaluationId)
        {
            try
            {
                var entity = new RTMEntities();

                var t2 = (from items in entity.EvaluationContractors where items.EvaluationId == evaluationId select items.ContractorId).ToList();
                var t = (from uss in entity.Contractors
                         where (t2.Contains((int)uss.ContractorId)) &&
                         (uss.IsDeleted == false)

                         select new ContractorWithTotalScore()
                         {
                             contractor = uss,
                             totalScore = (from items in entity.EvaluationStandardRelations
                                           where items.EvaluationId == evaluationId && items.ContractorId == uss.ContractorId
                                           select (items.Weight * items.Score) / (100.0)).Sum()
                         });

                return t.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static double RetrieveContractorUpdatedScore(int contractorId, int evaluationId)
        {
            try
            {
                var entity = new RTMEntities();

                var t = (from uss in entity.Contractors
                         where uss.ContractorId == contractorId &&
                         (uss.IsDeleted == false)

                         select

                             new
                             {
                                 totalScore = (from items in entity.EvaluationStandardRelations
                                               where items.EvaluationId == evaluationId && items.ContractorId == uss.ContractorId
                                               select (items.Weight * items.Score) / (100.0)).Sum()
                             }
                         ).FirstOrDefault();
                if (t != null)
                {
                    dynamic o = t;
                    return (double)o.totalScore;
                }
                else
                {
                    return -1;
                }

            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }

        private static int SubmitEvaluationContractorScore(int evaluationId, int contractorId, int evalStandardId, int score, int weight)
        {
            try
            {
                var entity = new RTMEntities();
                EvaluationStandardRelation s = new EvaluationStandardRelation();
                s.ContractorId = contractorId;
                s.StandardId = evalStandardId;
                s.EvaluationId = evaluationId;
                s.Weight = weight;
                s.Score = score;
                entity.EvaluationStandardRelations.AddObject(s);
                entity.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                return s.EvalStandardId;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }

        private static EvaluationStandardRelation RetrieveEvaluationContractorScore(int evaluationId, int contractorId, int evalStandardId)
        {
            try
            {
                var entity = new RTMEntities();
                var result = (
                             from items in entity.EvaluationStandardRelations
                             where items.EvaluationId == evaluationId && items.ContractorId == contractorId && items.EvalStandardId == evalStandardId
                             select items).ToList();
                if (result.Count > 0)
                {
                    return result[0];
                }
                else
                {
                    return null;
                }



            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static List<EvalStandardScore> RetrieveEvalStandarsDataGrid(int contractorId, int evalId, bool isContractor, bool isConsultant)
        {
            try
            {
                var t = DataManagement.RetrieveEvalStandards(isContractor, isConsultant);
                List<EvalStandardScore> result = new List<EvalStandardScore>();
                foreach (var item in t)
                {
                    EvaluationStandardRelation temp = DataManagement.DoesEvalScoreWeightExist(contractorId, evalId, item.StandardId);
                    if (temp != null)
                    {
                        result.Add(new EvalStandardScore()
                        {
                            Score = (double)temp.Score,
                            Weight = (int)temp.Weight,
                            StandardId = item.StandardId,
                            Title = item.Title
                        });
                    }
                    else
                    {
                        result.Add(new EvalStandardScore()
                        {
                            Score = 0,
                            Weight = 0,
                            StandardId = item.StandardId,
                            Title = item.Title
                        });
                    }
                }
                return result;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        private static EvaluationStandardRelation DoesEvalScoreWeightExist(int contractorId, int evalId, int standardId)
        {
            try
            {
                var en = new RTMEntities();
                var x = (
                        from items in en.EvaluationStandardRelations
                        where items.ContractorId == contractorId && items.EvaluationId == evalId && items.StandardId == standardId
                        select items).FirstOrDefault();
                if (x != null)
                    return x;
                else
                    return null;

            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static void SubmitEvaluationScoreWeight(List<EvalStandardScore> list, int evalid, int contractorId)
        {
            try
            {
                var e = new RTMEntities();
                foreach (var item in list)
                {
                    var temp = DoesEvalScoreWeightExist(contractorId, evalid, item.StandardId);
                    if (temp != null)
                    {
                        var update = (from items in e.EvaluationStandardRelations where items.EvalStandardId == temp.EvalStandardId select items).FirstOrDefault();
                        update.Weight = item.Weight;
                        update.Score = item.Score;
                    }
                    else
                    {
                        if (item.Weight == 0)
                            continue;
                        EvaluationStandardRelation t = new EvaluationStandardRelation()
                        {
                            Score = item.Score,
                            Weight = item.Weight,
                            ContractorId = contractorId,
                            EvaluationId = evalid,
                            StandardId = item.StandardId
                        };
                        e.AddToEvaluationStandardRelations(t);
                    }
                }
                e.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {

            }

        }

        public static void UpdateStandards(List<EvalStandard> list, bool isContractor, bool isConsultant)
        {
            try
            {
                var en = new RTMEntities();
                foreach (var sitem in list)
                {
                    var t = (from item in en.EvalStandards where item.StandardId == sitem.StandardId select item).FirstOrDefault();
                    if (t != null)
                    {
                        t.Title = sitem.Title;
                    }
                    else if (!string.IsNullOrEmpty(sitem.Title.Trim()))
                    {
                        sitem.ContractorStandard = isContractor;
                        sitem.ConsultantStandard = isConsultant;
                        en.AddToEvalStandards(sitem);
                    }
                }
                en.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
            }

        }
        public static void UpdatePositions(List<Position> list)
        {
            try
            {
                var en = new RTMEntities();
                foreach (var item in list)
                {
                    var t = (from i in en.Positions where i.PositionId == item.PositionId select i).FirstOrDefault();
                    if (t != null)
                    {
                        t.PositionTitle = item.PositionTitle;
                    }
                    else if (!string.IsNullOrEmpty(item.PositionTitle.Trim()))
                    {
                        en.AddToPositions(item);
                    }
                }
                en.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
            }
        }
        public static List<RTM.Position> RetrievePositions()
        {
            var entity = new RTMEntities();
            try
            {
                var organs = from nodes in entity.Positions select nodes;
                return organs.ToList();
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("در حال حاضر دسترسی به سرور امکان پذیر نیست");
            }
            return null;
        }
        public static void UpdateIssuingReferences(List<IssuingReference> list)
        {
            try
            {
                var en = new RTMEntities();
                foreach (var item in list)
                {
                    var t = (from i in en.IssuingReferences where i.IssuingReferenceId == item.IssuingReferenceId select i).FirstOrDefault();
                    if (t != null)
                    {
                        t.Title = item.Title;
                    }
                    else if (!string.IsNullOrEmpty(item.Title.Trim()))
                    {
                        en.AddToIssuingReferences(item);
                    }
                }
                en.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
            }
        }
        public static List<IssuingReference> RetrieveIssuingReferences()
        {
            var entity = new RTMEntities();
            try
            {
                var organs = from nodes in entity.IssuingReferences select nodes;
                return organs.ToList();
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("در حال حاضر دسترسی به سرور امکان پذیر نیست");
            }
            return null;
        }
        public static void UpdateTenderingTitle(List<TenderingTitle> list)
        {
            try
            {
                var en = new RTMEntities();
                foreach (var item in list)
                {
                    var t = (from i in en.TenderingTitles where i.TenderingTitleId == item.TenderingTitleId select i).FirstOrDefault();
                    if (t != null)
                    {
                        t.Title = item.Title;
                        t.Code = item.Code;
                    }
                    else if (!string.IsNullOrEmpty(item.Title.Trim()))
                    {
                        en.AddToTenderingTitles(item);
                    }
                }
                en.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
            }
        }
        public static List<TenderingTitle> RetrieveTenderingTitle()
        {
            var entity = new RTMEntities();
            try
            {
                var organs = from nodes in entity.TenderingTitles select nodes;
                return organs.ToList();
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("در حال حاضر دسترسی به سرور امکان پذیر نیست");
            }
            return null;
        }
        public static void UpdateContractType(List<ContractType> list)
        {
            try
            {
                var en = new RTMEntities();
                foreach (var item in list)
                {
                    var t = (from i in en.ContractTypes where i.ContractTypeId == item.ContractTypeId select i).FirstOrDefault();
                    if (t != null)
                    {
                        t.ContractType1 = item.ContractType1;
                    }
                    else if (!string.IsNullOrEmpty(item.ContractType1.Trim()))
                    {
                        en.AddToContractTypes(item);
                    }
                }
                en.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Contract)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
            }
        }
        public static List<ContractType> RetrieveContractType()
        {
            var entity = new RTMEntities();
            try
            {
                var organs = from nodes in entity.ContractTypes select nodes;
                return organs.ToList();
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("در حال حاضر دسترسی به سرور امکان پذیر نیست");
            }
            return null;
        }
        public static void UpdateContractDoc(List<ContractDocument> list)
        {
            try
            {
                var en = new RTMEntities();
                foreach (var item in list)
                {
                    var t = (from i in en.ContractDocuments where i.ContractDocumentId == item.ContractDocumentId select i).FirstOrDefault();
                    if (t != null)
                    {
                        t.Title = item.Title;
                    }
                    else if (!string.IsNullOrEmpty(item.Title.Trim()))
                    {
                        en.AddToContractDocuments(item);
                    }
                }
                en.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Contract)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
            }
        }
        public static List<ContractDocument> RetrieveContractDoc()
        {
            var entity = new RTMEntities();
            try
            {
                var organs = from nodes in entity.ContractDocuments select nodes;
                return organs.ToList();
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("در حال حاضر دسترسی به سرور امکان پذیر نیست");
            }
            return null;
        }


        public static List<ContractorDocument> RetrieveContractorDocuments()
        {
            var entity = new RTMEntities();
            try
            {
                var docs = from nodes in entity.ContractorDocuments select nodes;
                return docs.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }
        public static void UpdateContractorDocs(List<ContractorDocument> list)
        {
            try
            {
                var en = new RTMEntities();
                foreach (var item in list)
                {
                    var t = (from i in en.ContractorDocuments where i.ContractorDocumentId == item.ContractorDocumentId select i).FirstOrDefault();
                    if (t != null)
                    {
                        t.Title = item.Title;
                    }
                    else if (!string.IsNullOrEmpty(item.Title))
                    {
                        en.AddToContractorDocuments(item);
                    }
                }
                en.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
            }
        }
        public static int AddContractorFile(string fileName, string version, int contractorId, int contractorDocId, byte[] fileContent)
        {
            try
            {
                var en = new RTMEntities();
                var x = new ContractorFile()
                {
                    Version = version,
                    AttachedDate = DateTime.Now,
                    FileContent = fileContent,
                    FileGuid = Guid.NewGuid(),
                    Name = fileName
                };
                en.AddToContractorFiles(x);
                en.SaveChanges();
                var docfile = new ContractorDocFileRelation()
                {
                    ContractorId = contractorId,
                    ContractorDocumentId = contractorDocId,
                    FileId = x.FileId
                };
                en.AddToContractorDocFileRelations(docfile);
                en.SaveChanges();
                CreateLog('C', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                return x.FileId;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }
        public static int DeleteContractorFile(int fileId)
        {
            try
            {
                var en = new RTMEntities();
                //var x = (from items in en.ContractorFiles where items.FileId == fileId select items).FirstOrDefault();
                var t = (from items in en.ContractorDocFileRelations where items.FileId == fileId select items).FirstOrDefault();
                if (t != null)
                {
                    en.ContractorDocFileRelations.DeleteObject(t);
                    //if (x != null) en.ContractorFiles.DeleteObject(x);
                    var x = new ContractorFile() { FileId = fileId };
                    en.AttachTo("ContractorFiles", x);
                    en.ContractorFiles.DeleteObject(x);
                    en.SaveChanges();
                    CreateLog('D', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                }
                return fileId;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }
        public static List<ContractorFile> RetrieveContractorFile(int contractorId, int docId)
        {
            try
            {
                var entity = new RTMEntities();
                var t = from items in entity.ContractorDocFileRelations
                        where items.ContractorId == contractorId
                            && items.ContractorDocumentId == docId
                        select items.FileId;
                var res = from files in entity.ContractorFiles
                          where t.Contains(files.FileId)
                          select new
                          {
                              AttachedDate = files.AttachedDate,
                              Version = files.Version,
                              FileId = files.FileId,
                              Name = files.Name
                          };
                return res.ToList().ConvertAll<ContractorFile>(a => new ContractorFile { AttachedDate = a.AttachedDate, Version = a.Version, Name = a.Name, FileId = a.FileId });

            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static byte[] RetrieveContractorFile(ContractorFile contractorFile)
        {
            var entity = new RTMEntities();
            try
            {
                var contractor = (from items in entity.ContractorFiles where items.FileId == contractorFile.FileId select items).FirstOrDefault();
                return contractor.FileContent;
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }

        public static int ConfirmEvaluation(int evalId)
        {
            try
            {
                var en = new RTMEntities();
                var eval = (from evals in en.Evaluations where evals.EvaluationId == evalId select evals).FirstOrDefault();
                eval.PermanentRecord = true;
                en.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                return eval.EvaluationId;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }
        public static int AddEvaluationFile(string name, byte[] fileContent, int evalId)
        {
            try
            {
                var en = new RTMEntities();
                var x = new EvaluationAttachementFile()
                {
                    FileGuid = Guid.NewGuid(),
                    Name = name,
                    FileContent = fileContent,
                    EvaluationId = evalId,
                    AttachedDate = DateTime.Now
                };
                en.AddToEvaluationAttachementFiles(x);
                en.SaveChanges();
                CreateLog('C', (((int)(SubSystem.Tendering)).ToString()[0]),"");
                return x.EvaluationFileId;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }
        public static string HasEvaluationFileLocation(int evalId)
        {
            try
            {
                var en = new RTMEntities();
                var x = (from items in en.EvaluationAttachementFiles where items.EvaluationId == evalId orderby items.AttachedDate descending select items.Name).FirstOrDefault();
                if (x != null)
                    return x;
                else
                    return null;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static void DeleteEvaluationFile(int evalId)
        {
            try
            {
                var en = new RTMEntities();
                var x = (from items in en.EvaluationAttachementFiles where items.EvaluationId == evalId orderby items.AttachedDate descending select items.EvaluationFileId).FirstOrDefault();
                var t = new EvaluationAttachementFile() { EvaluationFileId = x };
                en.AttachTo("EvaluationAttachementFiles", t);
                en.EvaluationAttachementFiles.DeleteObject(t);
                en.SaveChanges();
                CreateLog('D', (((int)(SubSystem.Tendering)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {

            }
        }
        public static byte[] RetrieveEvaluationFile(int evalId)
        {
            try
            {
                var en = new RTMEntities();
                var x = (from items in en.EvaluationAttachementFiles where items.EvaluationId == evalId orderby items.AttachedDate descending select items.EvaluationFileId).FirstOrDefault();
                var file = (from items in en.EvaluationAttachementFiles where items.EvaluationFileId == x select items.FileContent).FirstOrDefault();
                return file;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }


        public static Regulation CreateRegulation(Regulation regulation)
        {
            var entity = new RTMEntities();
            try
            {
                regulation.IsDeleted = false;
                entity.AddToRegulations(regulation);
                entity.SaveChanges();
                CreateLog('C', (((int)(SubSystem.Regulation)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
                return null;
            }
            return regulation;
        }
        public static Regulation UpdateRegulation(Regulation regulation)
        {
            var entity = new RTMEntities();
            try
            {
                var regul = (from item in entity.Regulations where item.RegulationId == regulation.RegulationId select item).FirstOrDefault();
                regul.Group = regulation.Group;
                regul.IssuingDate = regulation.IssuingDate;
                regul.ActingReferenceId = regulation.ActingReferenceId;
                regul.IssuingReferenceId = regulation.IssuingReferenceId;
                regul.PermanentRecord = regulation.PermanentRecord;
                regul.Title = regulation.Title;
                regul.Type = regulation.Type;
                entity.SaveChanges();

                //entity.AttachTo("Regulations", regulation);
                entity.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Regulation)).ToString()[0]), "");
                return regul;
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }
        public static int AddRegulationFile(string name, byte[] fileContent, string version, int regulId)
        {
            try
            {
                var en = new RTMEntities();
                var x = new RegulationFile()
                {
                    FileGuid = Guid.NewGuid(),
                    Name = name,
                    FileContent = fileContent,
                    RegulationId = regulId,
                    AttachedDate = DateTime.Now,
                    Version = version
                };
                en.AddToRegulationFiles(x);
                en.SaveChanges();
                CreateLog('C', (((int)(SubSystem.Regulation)).ToString()[0]), "");
                return x.FileId;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }
        public static List<RegulationFile> RetrieveRegulationFile(int regulId)
        {
            try
            {
                var entity = new RTMEntities();
                var res = from files in entity.RegulationFiles
                          where files.RegulationId == regulId
                          select new
                          {
                              AttachedDate = files.AttachedDate,
                              Version = files.Version,
                              FileId = files.FileId,
                              Name = files.Name
                          };
                return res.ToList().ConvertAll<RegulationFile>(a => new RegulationFile { AttachedDate = a.AttachedDate, Version = a.Version, Name = a.Name, FileId = a.FileId });

            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static byte[] RetrieveRegulationFile(RegulationFile regul)
        {
            var entity = new RTMEntities();
            try
            {
                var contractor = (from items in entity.RegulationFiles where items.FileId == regul.FileId select items).FirstOrDefault();
                return contractor.FileContent;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static int DeleteRegulationFile(int regulFileId)
        {
            try
            {
                var en = new RTMEntities();
                var regfile = new RegulationFile() { FileId = regulFileId };
                en.AttachTo("RegulationFiles", regfile);
                en.RegulationFiles.DeleteObject(regfile);
                en.SaveChanges();
                CreateLog('D', (((int)(SubSystem.Regulation)).ToString()[0]), "");
                return regfile.FileId;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }
        public static List<Regulation> SearchRegulations(Regulation r)
        {
            try
            {
                var entity = new RTMEntities();
                var result = from items in entity.Regulations
                             where (r.ActingReferenceId == 0 || items.ActingReferenceId == r.ActingReferenceId)
                                 && (r.Group == "" || items.Group == r.Group)
                                 && (r.IssuingReferenceId == 0 || r.IssuingReferenceId == items.IssuingReferenceId)
                                 && (r.Title == "" || (items.Title.Contains(r.Title)))
                                 && (r.Type == "" || (items.Type == r.Type))
                                 && (r.IssueEveryOne == null || items.IssueEveryOne == r.IssueEveryOne)
                                 && (items.IsDeleted == false)
                             select items;
                return result.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static PaymentDraft CreatePaymentDraft(PaymentDraft paymentDraft)
        {
            var entity = new RTMEntities();
            try
            {

                entity.AddToPaymentDrafts(paymentDraft);
                entity.SaveChanges();
                CreateLog('C', (((int)(SubSystem.Contract)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
                return null;
            }
            return paymentDraft;
        }
        public static PaymentDraft UpdatePaymentDrafts(PaymentDraft p)
        {
            var entity = new RTMEntities();
            try
            {
                var pay = (from item in entity.PaymentDrafts where item.PaymentDraftId == p.PaymentDraftId select item).FirstOrDefault();
                pay.ContractorInsuranceDeficit = p.ContractorInsuranceDeficit;
                pay.PaymentType = p.PaymentType;
                pay.CurrentSituationDraft = p.CurrentSituationDraft;
                pay.Date = p.Date;
                pay.EmployerInsurancePercentage = p.EmployerInsurancePercentage;
                pay.EmplyerInsuranceDeficit = p.EmplyerInsuranceDeficit;
                pay.HasContractorInsurance = p.HasContractorInsurance;
                pay.HasEmployerInsurance = p.HasEmployerInsurance;
                pay.HasJobWellDone = p.HasJobWellDone;
                pay.PerviousSituationDraft = p.PerviousSituationDraft;
                pay.HasTax = p.HasTax;
                pay.JobWellDoneDeficit = p.JobWellDoneDeficit;
                pay.ModelNumber = p.ModelNumber;
                pay.Notes = p.Notes;
                pay.Other = p.Other;
                pay.OtherPercent = p.OtherPercent;
                pay.PayableAmount = p.PayableAmount;
                pay.PaymentDraftNumber = p.PaymentDraftNumber;
                pay.TaxDeficit = p.TaxDeficit;
                pay.ModelTitle = p.ModelTitle;
                pay.PermanentRecord = p.PermanentRecord;
                pay.PaymentType2 = p.PaymentType2;
                pay.TypeComment = p.TypeComment;

                entity.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Contract)).ToString()[0]), "");
                return pay;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static List<PaymentDraft> RetrievePaymentDrafts(Contract contract)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var result = from items in en.PaymentDrafts where items.ContractId == contract.Contractid select items;
                    return result.ToList();
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static FileDataObject RetrievePaymentDraftFile(int? paymentDraftId, int index)
        {
            var entity = new RTMEntities();
            try
            {
                var pf = (from items in entity.PaymentFiles
                          where items.PaymentDraftId == paymentDraftId
                              && items.Index == index
                          orderby items.AttachedDate descending
                          select items).FirstOrDefault();
                FileDataObject result = new FileDataObject()
                {
                    FileContent = pf.FileContent,
                    FileName = pf.Name
                };
                return result;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static int AddPaymentDraftFile(PaymentFile file)
        {
            try
            {
                var en = new RTMEntities();
                file.FileGuid = Guid.NewGuid();
                en.AddToPaymentFiles(file);
                en.SaveChanges();
                CreateLog('C', (((int)(SubSystem.Contract)).ToString()[0]), "");
                return file.FileId;
            }
            catch (System.Exception ex)
            {
                return -1;
            }

        }
        public static void UpdatePaymentDraftTranscripts(List<PaymentDraftTranscript> list, PaymentDraft p)
        {
            try
            {
                var en = new RTMEntities();
                var list2 = from items in en.PaymentDraftTranscripts where items.PaymentDraftId == p.PaymentDraftId select items;
                foreach (var item in list2)
                {
                    en.PaymentDraftTranscripts.DeleteObject(item);
                }
                en.SaveChanges();
                foreach (var item in list)
                {
                    var t = (from i in en.PaymentDraftTranscripts where i.PaymentDraftTranscriptId == item.PaymentDraftTranscriptId select i).FirstOrDefault();
                    if (t != null)
                    {
                        t.Title = item.Title;
                        t.Location = item.Location;
                        t.AttachmentCount = item.AttachmentCount;
                        t.FullAttachment = item.FullAttachment;
                    }
                    else if (!string.IsNullOrEmpty(item.Location.Trim()))
                    {
                        item.PaymentDraftId = p.PaymentDraftId;
                        en.AddToPaymentDraftTranscripts(new PaymentDraftTranscript
                        {
                            AttachmentCount=item.AttachmentCount,
                            FullAttachment = item.FullAttachment,
                            Location = item.Location,
                            PaymentDraftId = item.PaymentDraftId,
                            Title = item.Title
                        });
                    }
                }
                en.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Contract)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
            }
        }
        public static List<PaymentDraftTranscript> RetrievePaymentDraftTranscripts(PaymentDraft p)
        {
            var entity = new RTMEntities();
            try
            {
                var organs = from nodes in entity.PaymentDraftTranscripts where nodes.PaymentDraftId == p.PaymentDraftId select nodes;
                return organs.ToList();
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("در حال حاضر دسترسی به سرور امکان پذیر نیست");
            }
            return null;
        }

        public static ContractorRequest CreateContractorRequest(ContractorRequest c)
        {
            try
            {
                var entity = new RTMEntities();
                entity.AddToContractorRequests(c);
                entity.SaveChanges();
                CreateLog('C', (((int)(SubSystem.Tendering)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
                return null;
            }
            return c;
        }
        public static ContractorRequest UpdateContractorRequest(ContractorRequest c)
        {

            try
            {
                var entity = new RTMEntities();
                var nc = (from item in entity.ContractorRequests where item.ContractorRequestId == c.ContractorRequestId select item).FirstOrDefault();
                nc.Estimatation = c.Estimatation;
                nc.CeoNote = c.CeoNote;
                nc.FundingControlAssignee = c.FundingControlAssignee;
                nc.FundingControlDate = c.FundingControlDate;
                nc.FundingControlNote = c.FundingControlNote;
                nc.FundingPlace = c.FundingPlace;
                nc.FundingPlaceCode = c.FundingPlaceCode;
                nc.FundingRequestDate = c.FundingRequestDate;
                nc.FundingRequestNumber = c.FundingRequestNumber;
                nc.HasCEOAccepted = c.HasCEOAccepted;
                nc.HasFunding = c.HasFunding;
                nc.HasQualityEvaluation = c.HasQualityEvaluation;
                nc.IsDeleted = c.IsDeleted;
                nc.IsPriceList = c.IsPriceList;
                nc.Location = c.Location;
                nc.Note = c.Note;
                nc.ProjectTitle = c.ProjectTitle;
                nc.RequestDate = c.RequestDate;
                nc.RequestNumber = c.RequestNumber;
                nc.RequestingUnit = c.RequestingUnit;
                nc.RequestStatus = c.RequestStatus;
                nc.RequiredField = c.RequiredField;
                nc.RequiredMinRank = c.RequiredMinRank;
                nc.SelectConsultant = c.SelectConsultant;
                nc.SelectContractor = c.SelectContractor;
                nc.SupervisionId = c.SupervisionId;
                nc.TenderingTitleId = c.TenderingTitleId;
                nc.TenderingType = c.TenderingType;
                nc.Year = c.Year;
                nc.NoticeNumber = c.NoticeNumber;

                entity.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                return nc;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static List<ContractorRequest> SearchContractorRequest(ContractorRequest c)
        {
            try
            {
                var entity = new RTMEntities();
                var result = from items in entity.ContractorRequests
                             where
                                 (c.RequestDate == null || items.RequestDate == c.RequestDate) &&
                                 (c.ProjectTitle == "" || items.ProjectTitle.Contains(c.ProjectTitle)) &&
                                 (c.RequestNumber == "" || items.RequestNumber.Contains(c.RequestNumber))
                             select items;
                return result.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static Contract CreateContract(Contract c)
        {
            try
            {
                using (var entity = new RTMEntities())
                {
                    //((IEntityWithChangeTracker)c).SetChangeTracker(null);
                    //Contract temp = new Contract();
                    //temp = c;
                    entity.AddToContracts(c);
                    entity.SaveChanges();
                    CreateLog('C', (((int)(SubSystem.Contract)).ToString()[0]), "");
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
            return c;
        }
        public static Contract UpdateContract(Contract c)
        {

            try
            {
                var entity = new RTMEntities();
                var con = (from items in entity.Contracts where items.Contractid == c.Contractid select items).FirstOrDefault();
                con.AgreementDate = c.AgreementDate;
                con.AgreementNumber = c.AgreementNumber;
                con.Amount25Percent = c.Amount25Percent;
                con.C25PercentNumber = c.C25PercentNumber;
                con.ComplementAmount = c.ComplementAmount;
                con.ComplementedDate = c.ComplementedDate;
                con.ComplementedInformNumber = c.ComplementedInformNumber;
                con.ConsultantId = c.ConsultantId;
                con.ContractBudget = c.ContractBudget;
                con.ContractDate = c.ContractDate;
                con.ContractNumber = c.ContractNumber;
                con.ContractorId = c.ContractorId;
                con.ContractPeriod = c.ContractPeriod;
                con.ContractTtile = c.ContractTtile;
                con.ContractTypeId = c.ContractTypeId;
                con.IsDeleted = c.IsDeleted;
                con.IsTendering = c.IsTendering;
                con.SupervisingUnit = c.SupervisingUnit;
                con.SupervisingUnitHigher = c.SupervisingUnitHigher;
                con.Supervisor1 = c.Supervisor1;
                con.Supervisor2 = c.Supervisor2;
                con.TenderingSystemCode = c.TenderingSystemCode;
                con.PermanentRecord = c.PermanentRecord;
                con.StartDate = c.StartDate;
                con.Location = c.Location;

                //entity.AttachTo("Regulations", regulation);
                entity.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Contract)).ToString()[0]), "");
                return con;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static List<Contract> SearchContracts(string tenderingsys, string contractNumber, int? contractType, DateTime? fromDate, DateTime? toDate, string title, string contractorName = null, string consultantName = null,int? contractorId=null,int? consultantId=null,int? contractId=null)
        {
            try
            {
                var contractors = SearchContractors(contractorName, null, null, null, false).Select(s => s.ContractorId).ToList();
                var consultants = SearchContractors(consultantName, null, null, null, true).Select(s => s.ContractorId).ToList();
                var entity = new RTMEntities();
                
                int contractTypeInt = (contractType == null) ? 0 : (int)contractType;
                var result = from items in entity.Contracts
                             where
                                 (tenderingsys == "" || items.TenderingSystemCode == tenderingsys) &&
                                 (contractNumber == "" || items.ContractNumber.Contains(contractNumber)) &&
                                 (contractorId == null || items.ContractorId == contractorId) &&
                                 (contractId == null || items.Contractid == contractId) &&
                                 (consultantId == null || items.ConsultantId == consultantId) &&
                                 (contractType == null || items.ContractTypeId == contractTypeInt) &&
                                 (fromDate == null || items.ContractDate >= fromDate) &&
                                 (toDate == null || items.ContractDate <= toDate) &&
                                 (title == "" || items.ContractTtile.Contains(title)) &&
                                 (contractorName == null || (items.ContractorId != null && contractors.Contains((int)items.ContractorId))) &&
                                 (consultantName == null || (items.ConsultantId != null && consultants.Contains((int)items.ConsultantId)))
                             select items;
                return result.ToList();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static List<ContractFile> RetrieveContractFiles(int contractId, ContractIndex docIndex)
        {
            try
            {
                var entity = new RTMEntities();
                var docid = (int)((from items in entity.ContractDocuments where items.DocumentIndex == (int)docIndex select items.ContractDocumentId).FirstOrDefault());
                var t = from items in entity.ContractDocFileRelations
                        where items.ContractId == contractId
                            && items.ContractDocId == docid
                        select items.FileId;
                var res = from files in entity.ContractFiles
                          where t.Contains(files.FileId)
                          select new
                          {
                              AttachedDate = files.AttachedDate,
                              Version = files.Version,
                              FileId = files.FileId,
                              Name = files.Name,
                              IncRed = files.IncRed,
                              Is25Percent = files.Is25Percent,
                              Amount = files.Amount,
                              NotificationDate = files.NotificationDate,
                              Percent = files.Percent,
                              isExtend = files.IsExtend,
                              IsComplement = files.IsComplement,
                              NotificationNumber = files.NotificationNumber

                          };
                return res.ToList().ConvertAll<ContractFile>(a => new ContractFile
                {
                    AttachedDate = a.AttachedDate,
                    Version = a.Version,
                    Name = a.Name,
                    FileId = a.FileId,
                    IsComplement = a.IsComplement,
                    Amount = a.Amount,
                    IncRed = a.IncRed,
                    Is25Percent = a.Is25Percent,
                    NotificationDate = a.NotificationDate,
                    Percent = a.Percent,
                    IsExtend = a.isExtend,
                    NotificationNumber = a.NotificationNumber
                });

            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static byte[] RetrieveContractFile(ContractFile contractFile)
        {
            var entity = new RTMEntities();
            try
            {
                var contractor = (from items in entity.ContractFiles where items.FileId == contractFile.FileId select items).FirstOrDefault();
                return contractor.FileContent;
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }
        public static FileDataObject RetrieveContractFile(int contractId, int documentId, int? fileId)
        {
            try
            {
                var entity = new RTMEntities();
                var allFiles = (from items in entity.ContractDocFileRelations
                                where items.ContractId == contractId &&
                                items.ContractDocId == documentId
                                select items.FileId
                                  ).ToList();
                var theFile = (from items in entity.ContractFiles
                               where
                                   allFiles.Contains(items.FileId)
                               orderby items.AttachedDate descending
                               select items.FileId).FirstOrDefault();
                if (fileId != null)
                    theFile = (int)fileId;
                var file = (from items in entity.ContractFiles
                            where
                                items.FileId == theFile
                            select items).FirstOrDefault();
                FileDataObject res = new FileDataObject()
                {
                    FileContent = file.FileContent,
                    FileName = file.Name
                };
                return res;

            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static int AddContractFile(int contractId, ContractIndex docIndex, ContractFile file)
        {
            try
            {
                var en = new RTMEntities();
                int docId = (int)((from items in en.ContractDocuments where items.DocumentIndex == (int)docIndex select items.ContractDocumentId).FirstOrDefault());
                file.FileGuid = Guid.NewGuid();
                en.AddToContractFiles(file);
                en.SaveChanges();
                var docfile = new ContractDocFileRelation()
                {
                    ContractId = contractId,
                    FileId = file.FileId,
                    ContractDocId = docId
                };
                en.AddToContractDocFileRelations(docfile);
                en.SaveChanges();
                CreateLog('C', (((int)(SubSystem.Contract)).ToString()[0]), "");
                return file.FileId;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }
        public static void UpdateContractAttachements(List<ContractFile> list)
        {
            throw new NotImplementedException();
        }
        public static int DeleteContractFile(int fileId)
        {
            try
            {
                var en = new RTMEntities();
                //var x = (from items in en.ContractorFiles where items.FileId == fileId select items).FirstOrDefault();
                var t = (from items in en.ContractDocFileRelations where items.FileId == fileId select items).FirstOrDefault();
                if (t != null)
                {
                    en.ContractDocFileRelations.DeleteObject(t);
                    //if (x != null) en.ContractorFiles.DeleteObject(x);
                    var x = new ContractFile() { FileId = fileId };
                    en.AttachTo("ContractFiles", x);
                    en.ContractFiles.DeleteObject(x);
                    en.SaveChanges();
                    CreateLog('D', (((int)(SubSystem.Contract)).ToString()[0]), "");
                }
                return fileId;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }
        public static double? ContractTotalAmount(Contract c)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var complements = (
                                      from items in en.ContractDocFileRelations
                                      where items.ContractId == c.Contractid &&
                                          (items.ContractDocId == 1 || items.ContractDocId == 2)
                                      select items.FileId).ToList();
                    double? percentage = (double?)(
                                        from items in en.ContractFiles
                                        where complements.Contains(items.FileId)
                                                 && items.Is25Percent == true
                                        select items.Percent).ToList().Sum();
                    double? amount = (double?)(
                                        from items in en.ContractFiles
                                        where complements.Contains(items.FileId)
                                                 && items.IsComplement == true
                                        select items.Amount).ToList().Sum();
                    return (double)(c.ContractBudget) * (percentage / 100 + 1) + amount;


                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static Tendering CreateTendering(Tendering tender)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    en.AddToTenderings(tender);
                    en.SaveChanges();
                    CreateLog('C', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                    return tender;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static Tendering UpdateTendering(Tendering t, List<User> list)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var e = (from items in en.Tenderings where items.TenderingId == t.TenderingId select items).FirstOrDefault();
                    e.AdvertisingAlternationCount = t.AdvertisingAlternationCount;
                    //e.Bids = t.Bids;
                    e.BriefingSessionDate = t.BriefingSessionDate;
                    e.ConsultantId = t.ConsultantId;
                    e.ContractorRequestId = t.ContractorRequestId;
                    e.Description = t.Description;
                    e.DocumentSalePrice = t.DocumentSalePrice;
                    e.DraftWarranty = t.DraftWarranty;
                    e.FiscalYear = t.FiscalYear;
                    e.GuarantyPrice = t.GuarantyPrice;
                    e.HasBriefingSession = t.HasBriefingSession;
                    e.HasConsultant = t.HasConsultant;
                    e.HasQualityEvaluation = t.HasQualityEvaluation;
                    e.IsDeleted = t.IsDeleted;
                    e.IsDocForSale = t.IsDocForSale;
                    e.LcWarranty = t.LcWarranty;
                    e.Location = t.Location;
                    e.PermanentRecord = t.PermanentRecord;
                    e.ProjectCode = t.ProjectCode;
                    e.RecievingDocumentDeadline = t.RecievingDocumentDeadline;
                    e.RecievingDocumentsDate = t.RecievingDocumentsDate;
                    e.RequestPermanentCheck = t.RequestPermanentCheck;
                    e.StageId = t.StageId;
                    e.StockWarranty = t.StockWarranty;
                    e.SuggestionOpenDate = t.SuggestionOpenDate;
                    e.SuggestionRecieveDate = t.SuggestionRecieveDate;
                    e.TenderingNumber = t.TenderingNumber;
                    e.TenderingRecordDate = t.TenderingRecordDate;
                    e.TenderingTitle = t.TenderingTitle;
                    e.TenderingType = t.TenderingType;
                    e.MinScore = t.MinScore;
                    e.IsNotice = t.IsNotice;
                    en.SaveChanges();

                    var l = (from i in en.UserTenderingMembers
                             where i.TenderingId == e.TenderingId
                             select i).ToList();
                    foreach (var item2 in l)
                    {
                        en.UserTenderingMembers.DeleteObject(item2);

                    }
                    en.SaveChanges();
                    foreach (var item in list)
                    {
                        en.AddToUserTenderingMembers(new UserTenderingMember()
                        {
                            UserId = item.UserId,
                            TenderingId = e.TenderingId
                        });
                    }
                    en.SaveChanges();
                    CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                    return e;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static Tendering UpdateTendering(Tendering t)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var e = (from items in en.Tenderings where items.TenderingId == t.TenderingId select items).FirstOrDefault();
                    e.AdvertisingAlternationCount = t.AdvertisingAlternationCount;
                    //e.Bids = t.Bids;
                    e.BriefingSessionDate = t.BriefingSessionDate;
                    e.ConsultantId = t.ConsultantId;
                    e.ContractorRequestId = t.ContractorRequestId;
                    e.Description = t.Description;
                    e.DocumentSalePrice = t.DocumentSalePrice;
                    e.DraftWarranty = t.DraftWarranty;
                    e.FiscalYear = t.FiscalYear;
                    e.GuarantyPrice = t.GuarantyPrice;
                    e.HasBriefingSession = t.HasBriefingSession;
                    e.HasConsultant = t.HasConsultant;
                    e.HasQualityEvaluation = t.HasQualityEvaluation;
                    e.IsDeleted = t.IsDeleted;
                    e.IsDocForSale = t.IsDocForSale;
                    e.LcWarranty = t.LcWarranty;
                    e.Location = t.Location;
                    e.PermanentRecord = t.PermanentRecord;
                    e.ProjectCode = t.ProjectCode;
                    e.RecievingDocumentDeadline = t.RecievingDocumentDeadline;
                    e.RecievingDocumentsDate = t.RecievingDocumentsDate;
                    e.RequestPermanentCheck = t.RequestPermanentCheck;
                    e.StageId = t.StageId;
                    e.StockWarranty = t.StockWarranty;
                    e.SuggestionOpenDate = t.SuggestionOpenDate;
                    e.SuggestionRecieveDate = t.SuggestionRecieveDate;
                    e.TenderingNumber = t.TenderingNumber;
                    e.TenderingRecordDate = t.TenderingRecordDate;
                    e.TenderingTitle = t.TenderingTitle;
                    e.TenderingType = t.TenderingType;
                    e.IsNotice = t.IsNotice;
                    e.MinScore = t.MinScore;
                    en.SaveChanges();
                    CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                    return e;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static Tendering RetrieveContractorRequestTendering(ContractorRequest c)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var result = (from items in en.Tenderings where items.ContractorRequestId == c.ContractorRequestId select items).FirstOrDefault();
                    return result;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static ContractorRequest RetrieveTenderingContractorRequest(Tendering c)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var result = (from items in en.ContractorRequests where items.ContractorRequestId == c.ContractorRequestId select items).FirstOrDefault();
                    return result;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static int AddTenderingFile(TenderingDocumentFile file)
        {
            try
            {
                var en = new RTMEntities();
                en.AddToTenderingDocumentFiles(file);
                en.SaveChanges();
                CreateLog('C', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                return file.TenderingDocumentFileId;
            }
            catch (System.Exception ex)
            {
                return -1;
            }

        }
        public static int RetrieveTenderingDocumentId(TenderingIndex t)
        {
            try
            {
                var en = new RTMEntities();
                int index = (int)t;
                var res = (from items in en.TenderingDocuments where items.DocumentIndex == index select items.TenderingDocumentId).FirstOrDefault();
                return res;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }
        public static int AddTenderingFileRelation(TenderingDocumentFileRelation rel)
        {
            try
            {
                var en = new RTMEntities();
                en.AddToTenderingDocumentFileRelations(rel);
                en.SaveChanges();
                return rel.TenderDocFileRelId;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }
        public static FileDataObject RetrieveTenderingFile(int tenderingId, int documentId, int? contractorId, int? advertisementId, int? meetingId, int? warrantyId)
        {
            try
            {
                var entity = new RTMEntities();
                var allFiles = (from items in entity.TenderingDocumentFileRelations
                                where items.TenderingId == tenderingId &&
                                items.TenderingDocumentId == documentId &&
                                (contractorId == null || items.ContractorId == contractorId) &&
                                (meetingId == null || items.MeetingId == meetingId) &&
                                (warrantyId == null || items.WarrantyId == warrantyId) &&
                                (advertisementId == null || items.AdvertisementId == advertisementId)
                                select items.TenderingDocumentFileId
                                  ).ToList();
                var theFile = (from items in entity.TenderingDocumentFiles
                               where
                                   allFiles.Contains(items.TenderingDocumentFileId)
                               orderby items.AttachedDate descending
                               select items.TenderingDocumentFileId).FirstOrDefault();
                var file = (from items in entity.TenderingDocumentFiles
                            where
                                items.TenderingDocumentFileId == theFile
                            select items).FirstOrDefault();
                FileDataObject res = new FileDataObject()
                {
                    FileContent = file.FileContent,
                    FileName = file.Name
                };
                return res;

            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static int DeleteTenderingFile(int tenderingId, int documentId, int? contractorId, int? advertisementId, int? meetingId, int? warrantyId = null)
        {
            try
            {
                var entity = new RTMEntities();
                var allFiles = (from items in entity.TenderingDocumentFileRelations
                                where items.TenderingId == tenderingId &&
                                items.TenderingDocumentId == documentId &&
                                (contractorId == null || items.ContractorId == contractorId) &&
                                (meetingId == null || items.MeetingId == meetingId) &&
                                (warrantyId == null || items.WarrantyId == warrantyId) &&
                                (advertisementId == null || items.AdvertisementId == advertisementId)
                                select items.TenderingDocumentFileId
                                  ).ToList();
                var fileId = (from items in entity.TenderingDocumentFiles
                              where
                                  allFiles.Contains(items.TenderingDocumentFileId)
                              orderby items.AttachedDate descending
                              select items.TenderingDocumentFileId).FirstOrDefault();
                var x = new TenderingDocumentFile() { TenderingDocumentFileId = fileId };
                var rel = (
                          from items in entity.TenderingDocumentFileRelations
                          where
                              items.TenderingId == tenderingId &&
                              items.TenderingDocumentId == documentId &&
                              (contractorId == null || items.ContractorId == contractorId) &&
                              (meetingId == null || items.MeetingId == meetingId) &&
                              (advertisementId == null || items.AdvertisementId == advertisementId) &&
                              items.TenderingDocumentFileId == fileId
                          select items).FirstOrDefault();
                ;
                entity.AttachTo("TenderingDocumentFiles", x);

                entity.TenderingDocumentFileRelations.DeleteObject(rel);
                entity.SaveChanges();
                entity.TenderingDocumentFiles.DeleteObject(x);
                entity.SaveChanges();
                CreateLog('D', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                return fileId;

            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }
        public static int DeleteTenderingFile(int fileId)
        {
            try
            {
                var en = new RTMEntities();
                //var x = (from items in en.ContractorFiles where items.FileId == fileId select items).FirstOrDefault();
                var t = (from items in en.TenderingDocumentFileRelations where items.TenderingDocumentFileId == fileId select items).FirstOrDefault();
                if (t != null)
                {
                    en.TenderingDocumentFileRelations.DeleteObject(t);
                    //if (x != null) en.ContractorFiles.DeleteObject(x);
                    var x = new TenderingDocumentFile() { TenderingDocumentFileId = fileId };
                    en.AttachTo("TenderingDocumentFiles", x);
                    en.TenderingDocumentFiles.DeleteObject(x);
                    en.SaveChanges();
                    CreateLog('D', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                }
                return fileId;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }
        public static bool HasTenderingFile(int tenderingId, int documentId, int? contractorId, int? advertisementId, int? meetingId)
        {
            try
            {
                var entity = new RTMEntities();
                var allFiles = (from items in entity.TenderingDocumentFileRelations
                                where items.TenderingId == tenderingId &&
                                items.TenderingDocumentId == documentId &&
                                (contractorId == null || items.ContractorId == contractorId) &&
                                (meetingId == null || items.MeetingId == meetingId) &&
                                (advertisementId == null || items.AdvertisementId == advertisementId)
                                select items.TenderingDocumentFileId
                                  ).ToList();
                var fileId = (from items in entity.TenderingDocumentFiles
                              where
                                  allFiles.Contains(items.TenderingDocumentFileId)
                              orderby items.AttachedDate descending
                              select items.TenderingDocumentFileId).FirstOrDefault();
                if (fileId > 0)
                    return true;
                else
                    return false;

            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public static List<Advertisement> RetrieveAdvertisement(Notice n)
        {
            var entity = new RTMEntities();
            try
            {
                var organs = from nodes in entity.Advertisements where nodes.NoticeId == n.NoticeId select nodes;
                return organs.ToList();
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("در حال حاضر دسترسی به سرور امکان پذیر نیست");
            }
            return null;
        }
        public static void UpdateAdveritsement(List<Advertisement> list, Notice n)
        {
            try
            {
                var en = new RTMEntities();
                foreach (var item in list)
                {
                    var t = (from i in en.Advertisements where i.AdvertisementId == item.AdvertisementId select i).FirstOrDefault();
                    if (t != null)
                    {

                        t.AdertisementDate = item.AdertisementDate;
                        t.AdevtisementType = item.AdevtisementType;
                        t.AdvertisementAlternationCount = item.AdvertisementAlternationCount;
                        t.AdvertisementNumber = item.AdvertisementNumber;
                        t.NewspaperName = item.NewspaperName;
                        t.NewsPaperNumber = item.NewsPaperNumber;
                    }
                    else
                    {
                        item.NoticeId = n.NoticeId;
                        en.AddToAdvertisements(item);
                    }
                }
                en.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
            }
        }

        public static Meeting CreateMeeting(Meeting m)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    en.AddToMeetings(m);
                    en.SaveChanges();
                    CreateLog('C', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                    return m;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static Meeting UpdateMeeting(Meeting m)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var t = (from items in en.Meetings where items.MeetingId == m.MeetingId select items).FirstOrDefault();
                    t.ExtendByApplicant = m.ExtendByApplicant;
                    t.ExtendByCommittee = m.ExtendByCommittee;
                    t.ExtendedRecieveDate = m.ExtendedRecieveDate;
                    t.MeetingDate = m.MeetingDate;
                    t.MeetingDescription = m.MeetingDescription;
                    t.MeetingNumber = m.MeetingNumber;
                    t.MeetingPlace = m.MeetingPlace;
                    t.MeetingType = m.MeetingType;
                    t.MinTechnicalScore = m.MinTechnicalScore;
                    t.NeedsTechnicalEvaluation = m.NeedsTechnicalEvaluation;
                    t.OpenBidEnvelopeDate = m.OpenBidEnvelopeDate;
                    t.PermanentRecord = m.PermanentRecord;
                    en.SaveChanges();
                    CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                    return t;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static List<Meeting> RetrieveMeetings(Tendering currentTendering, MeetingTypes meetingType)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var result = from items in en.Meetings
                                 where items.TenderingId == currentTendering.TenderingId &&
                                     items.MeetingType == (int)meetingType

                                 orderby items.MeetingId descending
                                 select items;
                    return result.ToList();
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static List<ContractorTenderingDocumentRecieve> RetrieveTenderingDocumentRecieve(Tendering t)
        {
            var entity = new RTMEntities();
            try
            {
                var organs = from nodes in entity.ContractorTenderingDocumentRecieves where nodes.TenderingId == t.TenderingId select nodes;
                entity = null;
                return organs.ToList();
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("در حال حاضر دسترسی به سرور امکان پذیر نیست");
            }
            return null;
        }
        public static void UpdateTenderingDocumentRecieve(List<ContractorTenderingDocumentRecieve> list, Tendering n)
        {
            try
            {
                var en = new RTMEntities();
                var del = from items in en.ContractorTenderingDocumentRecieves where items.TenderingId == n.TenderingId select items;
                foreach (var item in del)
                {
                    en.ContractorTenderingDocumentRecieves.DeleteObject(item);
                }
                en.SaveChanges();
                en = null;
                en = new RTMEntities();
                en.ContractorTenderingDocumentRecieves.MergeOption = MergeOption.NoTracking;
                foreach (var item in list)
                {
                    var t = (from i in en.ContractorTenderingDocumentRecieves where i.TenderingId == item.TenderingId && i.ContractorId == item.ContractorId select i).FirstOrDefault();
                    if (t != null)
                    {
                        t.BankName = item.BankName;
                        t.ContractorId = item.ContractorId;
                        t.ContractorRepresentativeName = item.ContractorRepresentativeName;
                        t.DraftAmount = item.DraftAmount;
                        t.PaymentDraftDate = item.PaymentDraftDate;
                        t.PaymentDraftNumber = item.PaymentDraftNumber;

                    }
                    else
                    {
                        var t2 = new ContractorTenderingDocumentRecieve();
                        t2.BankName = item.BankName;
                        t2.ContractorId = item.ContractorId;
                        t2.ContractorRepresentativeName = item.ContractorRepresentativeName;
                        t2.DraftAmount = item.DraftAmount;
                        t2.PaymentDraftDate = item.PaymentDraftDate;
                        t2.PaymentDraftNumber = item.PaymentDraftNumber;
                        t2.TenderingId = n.TenderingId;
                        t2.ContractorId = item.ContractorId;

                        en.AddToContractorTenderingDocumentRecieves(t2);
                    }
                }
                en.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
            }
        }

        public static void UpdateMeetingUserParticipants(List<User> list, Meeting meeting)
        {
            try
            {
                var en = new RTMEntities();
                var del = (from items in en.MeetingUserParticipants where items.MeetingId == meeting.MeetingId select items).ToList();
                foreach (var item in del)
                {
                    en.MeetingUserParticipants.DeleteObject(item);
                }
                en.SaveChanges();
                foreach (var item in list)
                {
                    var rel = new MeetingUserParticipant()
                    {
                        MeetingId = meeting.MeetingId,
                        UserId = item.UserId
                    };
                    en.AddToMeetingUserParticipants(rel);
                }
                en.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
            }
            catch (Exception e)
            {

            }
        }
        public static List<User> RetrieveMeetingUserParticipant(Meeting meeting)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var result = from items in en.Users
                                 from items2 in en.MeetingUserParticipants
                                 where items.UserId == items2.UserId &&
                                 items2.MeetingId == meeting.MeetingId
                                 select items;
                    return result.ToList();
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static List<Contractor> RetrieveJustificationMeetingContractor(Meeting meeting)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var result = from items in en.Contractors
                                 from items2 in en.ContractorMeetingJustifications
                                 where items.ContractorId == items2.ContractorId &&
                                 items2.MeetingId == meeting.MeetingId
                                 select items;
                    return result.ToList();
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static void UpdateJustificationMeetingContractors(List<Contractor> list, Meeting meeting)
        {
            try
            {
                var en = new RTMEntities();
                var del = (from items in en.ContractorMeetingJustifications where items.MeetingId == meeting.MeetingId select items).ToList();
                foreach (var item in del)
                {
                    en.ContractorMeetingJustifications.DeleteObject(item);
                }
                en.SaveChanges();
                foreach (var item in list)
                {
                    var rel = new ContractorMeetingJustification()
                    {
                        MeetingId = meeting.MeetingId,
                        ContractorId = item.ContractorId
                    };
                    en.AddToContractorMeetingJustifications(rel);
                }
                en.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
            }
            catch (Exception e)
            {

            }
        }

        public static List<ContractorTenderingSubmitPacket> RetrieveContractorSubmitPackets(Tendering t)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var docpresent = (from items in en.ContractorTenderingDocumentRecieves where items.TenderingId == t.TenderingId select items).ToList();
                    var res = (from items in en.ContractorTenderingSubmitPackets where items.TenderingId == t.TenderingId select items).ToList();
                    if (res.Count > 0)
                        return res;
                    else
                    {
                        foreach (var item in docpresent)
                        {
                            var temp = new ContractorTenderingSubmitPacket()
                            {
                                ContractorId = item.ContractorId,
                                TenderingId = item.TenderingId,
                            };
                            en.AddToContractorTenderingSubmitPackets(temp);
                        }
                    }
                    en.SaveChanges();
                    return (from items in en.ContractorTenderingSubmitPackets where items.TenderingId == t.TenderingId select items).ToList();
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static List<Contractor> RetrieveContractorsWhoSubmitPacket(Tendering t)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var temp = RetrieveContractorSubmitPackets(t);
                    var temp2 = from items in temp select items.ContractorId;
                    var result = from items in en.Contractors
                                 where (temp2.Contains(items.ContractorId))
                                 select items;
                    return result.ToList();
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static void UpdateContractorSubmitPacket(List<ContractorTenderingSubmitPacket> list)
        {
            try
            {
                var en = new RTMEntities();
                foreach (var item in list)
                {
                    var t = (from i in en.ContractorTenderingSubmitPackets where i.ContractorSubmitingDocumentId == item.ContractorSubmitingDocumentId select i).FirstOrDefault();
                    if (t != null)
                    {
                        t.RepresentativeName = item.RepresentativeName;
                        t.SecretaryNumber = item.SecretaryNumber;
                        t.SubmitDate = item.SubmitDate;
                        t.WithdrawDate = item.WithdrawDate;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                en.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<ContractorMeetingOpenPacket> RetrieveContractorOpenPacket(Tendering t, Meeting m)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var docpresent = (from items in en.ContractorTenderingSubmitPackets where items.TenderingId == t.TenderingId && items.SubmitDate != null select items).ToList();
                    var res = (from items in en.ContractorMeetingOpenPackets where items.MeetingId == m.MeetingId select items).ToList();
                    if (res.Count > 0)
                        return res;
                    else
                    {
                        foreach (var item in docpresent)
                        {
                            var temp = new ContractorMeetingOpenPacket()
                            {
                                ContractorId = item.ContractorId,
                                MeetingId = m.MeetingId
                            };
                            en.AddToContractorMeetingOpenPackets(temp);
                        }
                    }
                    en.SaveChanges();
                    return (from items in en.ContractorMeetingOpenPackets where items.MeetingId == m.MeetingId select items).ToList();
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static void UpdateContractoOpenPacket(List<ContractorMeetingOpenPacket> list)
        {
            try
            {
                var en = new RTMEntities();
                foreach (var item in list)
                {
                    var t = (from i in en.ContractorMeetingOpenPackets where i.CMOId == item.CMOId select i).FirstOrDefault();
                    if (t != null)
                    {
                        t.DocumentCondition = item.DocumentCondition;
                        t.IsCertifiedToOpenBid = item.IsCertifiedToOpenBid;
                        t.PacketEval = item.PacketEval;
                        t.Representative = item.Representative;
                        t.WarrantyEval = item.WarrantyEval;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                en.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<Contractor> RetrieveOpenPacketMeetingContractor(Meeting meeting)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var result = from items in en.Contractors
                                 from items2 in en.ContractorMeetingOpenPackets
                                 where items.ContractorId == items2.ContractorId &&
                                 items2.MeetingId == meeting.MeetingId
                                 select items;
                    return result.ToList();
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static List<Contractor> RetrieveWarrantyContractor(Tendering t)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var temp = (
                               from meetings in en.Meetings
                               from contractors in en.Contractors
                               from rels in en.ContractorMeetingOpenPackets
                               where rels.ContractorId == contractors.ContractorId &&
                               meetings.MeetingId == rels.MeetingId &&
                               meetings.TenderingId == t.TenderingId &&
                               rels.PacketEval == true
                               select contractors.ContractorId).ToList();
                    ;
                    var result = (from items in en.Contractors where temp.Contains(items.ContractorId) select items).ToList();
                    return result;

                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static List<Warranty> RetrieveWarranty(Contractor c, Tendering t)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var result = from w in en.Warranties where w.TenderingId == t.TenderingId && w.ContractorId == c.ContractorId select w;
                    return result.ToList();
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static bool UpdateWarranty(List<Warranty> list, Tendering t, Contractor c)
        {
            bool res = true;
            try
            {
                var en = new RTMEntities();
                var del = from items in en.Warranties where items.TenderingId == t.TenderingId && items.ContractorId == c.ContractorId select items;
                foreach (var item in del)
                {
                    en.Warranties.DeleteObject(item);
                }
                en.SaveChanges();
                foreach (var item in list)
                {
                    item.ContractorId = c.ContractorId;
                    item.TenderingId = t.TenderingId;
                    var temp = (from items in en.Warranties where items.Number == item.Number select items).FirstOrDefault();
                    if (temp != null)
                    {
                        res = false;
                        ErrorHandler.ShowErrorMessage("ضمانت نامه با شماره زیر قبلا به ثبت رسیده است.\n" + item.Number);
                        continue;
                    }

                    en.Warranties.AddObject(new Warranty()
                    {
                        ContractorId = c.ContractorId,
                        Amount = item.Amount,
                        BankBranch = item.BankBranch,
                        BankCity = item.BankCity,
                        BankName = item.BankName,
                        Description = item.Description,
                        Number = item.Number,
                        RegisterDate = item.RegisterDate,
                        StockTitle = item.StockTitle,
                        TenderingId = t.TenderingId,
                        ValidityDate = item.ValidityDate,
                        Status = item.Status,
                        Type = item.Type
                    });
                    en.SaveChanges();
                }
                en.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
                return false;
            }
            return res;
        }
        public static List<Warranty> RetrieveWarranty(Contractor c, Tendering t, WarrantyTypes type)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var result = from w in en.Warranties where w.TenderingId == t.TenderingId && w.ContractorId == c.ContractorId && w.Type == (int)type select w;
                    return result.ToList();
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static void UpdateWarranty(List<Warranty> list, Tendering t, Contractor c, WarrantyTypes type)
        {
            try
            {
                var en = new RTMEntities();
                var del = from items in en.Warranties where items.TenderingId == t.TenderingId && items.ContractorId == c.ContractorId && items.Type == (int)type select items;
                foreach (var item in del)
                {
                    en.Warranties.DeleteObject(item);
                }
                en.SaveChanges();
                foreach (var item in list)
                {
                    item.ContractorId = c.ContractorId;
                    item.TenderingId = t.TenderingId;
                    en.Warranties.AddObject(new Warranty()
                    {
                        ContractorId = c.ContractorId,
                        Amount = item.Amount,
                        BankBranch = item.BankBranch,
                        BankCity = item.BankCity,
                        BankName = item.BankName,
                        Description = item.Description,
                        Number = item.Number,
                        RegisterDate = item.RegisterDate,
                        StockTitle = item.StockTitle,
                        TenderingId = t.TenderingId,
                        Type = (int)type,
                        ValidityDate = item.ValidityDate,
                    });
                }
                en.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
            }
        }

        public static List<Bid> RetrieveBids(Tendering t)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    //var docpresent = (from items in en.ContractorTenderingSubmitPackets where items.TenderingId == t.TenderingId && items.SubmitDate != null select items).ToList();
                    var approved = (
                        from items in en.Warranties
                        where items.TenderingId == t.TenderingId
                        where !(from items2 in en.Warranties where items2.ContractorId == items.ContractorId && items2.TenderingId == t.TenderingId && items2.Status == false select items2.WarrantyId).Any()
                        select items.ContractorId
                        ).Distinct().ToList();
                    //var temp = (from items in en.Contractors where approved.Contains(items.ContractorId) select items).ToList();
                    var res = (from items in en.Bids where items.TenderingId == t.TenderingId select items).ToList();
                    if (res.Count > 0 && res.Count == approved.Count)
                        return res;
                    else
                    {
                        foreach (var item in res)
                        {
                            en.Bids.DeleteObject(item);
                            en.SaveChanges();
                        }
                        foreach (var item in approved)
                        {
                            var temp = new Bid()
                            {
                                ContractorId = item,
                                TenderingId = t.TenderingId
                            };
                            en.AddToBids(temp);
                        }
                    }
                    en.SaveChanges();
                    return (from items in en.Bids where items.TenderingId == t.TenderingId select items).ToList();
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static void UpdateBids(List<Bid> list, Tendering t, double coef = 0)
        {
            try
            {
                var en = new RTMEntities();
                var del = from items in en.Bids where items.TenderingId == t.TenderingId select items;
                foreach (var item in del)
                {
                    en.Bids.DeleteObject(item);
                }
                en.SaveChanges();
                foreach (var item in list)
                {
                    en.Bids.AddObject(new Bid()
                    {
                        BidEvaluation = item.BidEvaluation,
                        Coefficient = item.Coefficient,
                        ImpactCoefficient = coef,
                        ContractorId = item.ContractorId,
                        Minus = item.Minus,
                        Plus = item.Plus,
                        TenderingId = t.TenderingId,
                        Bid1 = item.Bid1,
                        QualityScore = item.QualityScore,
                        BalancedPrice = item.BalancedPrice
                    });

                }
                en.SaveChanges();
                CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
            }
            catch (System.Exception ex)
            {
            }
        }

        public static List<Tendering> SearchTenderings(string type, string title, string number, string ids, string reqNumber, DateTime? fromdate = null, DateTime? todate = null, DateTime? reqfromdate = null, DateTime? reqtodate = null, DateTime? resfromdate = null, DateTime? restodate = null, int? requestingUnit = null, int? supervisingUnit = null, string requiredField = "", bool? renewed = null, int? winnerID = null,bool isNotice=false,int? stageId=null)
        {
            try
            {

                int id = 0;
                bool has = Int32.TryParse(ids, out id);
                using (var en = new RTMEntities())
                {
                    var t = (from items in en.ContractorRequests    where 
                             (reqNumber == "" || items.RequestNumber == reqNumber) &&
                             (reqfromdate == null || items.RequestDate >= reqfromdate) &&
                             (reqtodate == null || items.RequestDate <= reqtodate) &&
                             (requestingUnit == null || items.RequestingUnit == requestingUnit) &&
                             (supervisingUnit == null || items.SupervisionId== supervisingUnit) &&
                             (requiredField == "" || items.RequiredField == requiredField)
                             select items.ContractorRequestId).ToList();
                    var t2 = (from items in en.TenderingResults
                              where
                                  (resfromdate == null || items.Date >= resfromdate) &&
                                  (restodate == null || items.Date <= restodate) &&
                                  (winnerID == null || items.FirstContractorWinnerId == winnerID)
                              select items.TenderingId
                                  ).ToList();
                    bool uptoresult = (winnerID != null) || (resfromdate!=null) || (restodate!=null) || (renewed!=null);
                    var res = from items in en.Tenderings
                              where
                                  (type==null || type == "" || items.TenderingType.Contains(type)) &&
                                  (title == "" || items.TenderingTitle.Contains(title)) &&
                                  (number == "" || items.TenderingNumber==number) &&
                                  (!has || items.TenderingId == id) &&
                                  (items.ContractorRequestId == null || t.Contains((int)items.ContractorRequestId)) &&
                                  (fromdate == null || items.TenderingRecordDate >= fromdate) &&
                                  (todate == null || items.TenderingRecordDate <= todate) &&
                                  (uptoresult == false || t2.Contains(items.TenderingId)) &&
                                  (stageId == null ||stageId==0|| items.StageId == stageId) &&
                                  (items.IsNotice == isNotice)
                              select items;
                    return res.ToList();

                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static List<Stage> RetrieveStages()
        {
            var entity = new RTMEntities();
            try
            {
                var organs = from nodes in entity.Stages select nodes;
                return organs.ToList();
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage("در حال حاضر دسترسی به سرور امکان پذیر نیست");
            }
            return null;
        }

        public static Meeting SearchOrCreateMeeting(Tendering t, MeetingTypes meetingtype)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var result = (from items in en.Meetings where items.MeetingType == (int)meetingtype && items.TenderingId == t.TenderingId select items).ToList();
                    if (result.Count > 0)
                    {
                        return result[0];
                    }
                    else
                    {
                        var m = new Meeting()
                            {
                                TenderingId = t.TenderingId,
                                MeetingType = (int)meetingtype
                            };
                        en.AddToMeetings(m);
                        en.SaveChanges();
                        CreateLog('C', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                        return m;
                    }
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static void UpdateTenderingStage(Tendering currentTendering, Stages stage)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var t = (from items in en.Tenderings where items.TenderingId == currentTendering.TenderingId select items).FirstOrDefault();
                    if (TenderingStages.Count == 0)
                        TenderingStages = RetrieveStages();
                    int stageid = (from items in TenderingStages where items.StageNumber == (int)stage select items.StageId).FirstOrDefault();
                    if (t.StageId < stageid)
                    {
                        t.StageId = stageid;
                        en.SaveChanges();
                        CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                        currentTendering.StageId = stageid;
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
        }
        private static List<Stage> TenderingStages = new List<Stage>();
        public static Stages RetrieveTenderingStage(Tendering currentTendering)
        {
            try
            {
                if (TenderingStages.Count == 0)
                {
                    TenderingStages = RetrieveStages();
                }
                return (Stages)(from item in TenderingStages where item.StageId == currentTendering.StageId select item.StageNumber).FirstOrDefault();
            }
            catch (System.Exception ex)
            {
                return Stages.Request;
            }
        }

        public static Notice SearchOrCreateNotice(Tendering t)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var result = (from items in en.Notices where items.TenderingId == t.TenderingId select items).ToList();
                    if (result.Count > 0)
                    {
                        return result[0];
                    }
                    else
                    {
                        var m = new Notice()
                        {
                            TenderingId = t.TenderingId
                        };
                        en.AddToNotices(m);
                        en.SaveChanges();
                        CreateLog('C', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                        return m;
                    }
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static Notice UpdateNotice(Notice n)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var t = (from items in en.Notices where items.NoticeId == n.NoticeId select items).FirstOrDefault();
                    t.AccountNumber = n.AccountNumber;
                    t.AccountOwner = n.AccountOwner;
                    t.BankBranch = n.BankBranch;
                    t.BankName = n.BankName;
                    t.DocumentSellPrice = n.DocumentSellPrice;
                    t.Note = n.Note;
                    t.NoticeNumber = n.NoticeNumber;
                    t.NoticeType = n.NoticeType;
                    t.OpenSuggestionPlace = n.OpenSuggestionPlace;
                    t.PermanentRecord = n.PermanentRecord;
                    t.PresentingPlace = n.PresentingPlace;
                    t.RecievePlace = n.RecievePlace;
                    t.RegisterDate = n.RegisterDate;
                    en.SaveChanges();
                    CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                    return t;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static TenderingResult SearchOrCreateTenderingResult(Tendering t)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var result = (from items in en.TenderingResults where items.TenderingId == t.TenderingId select items).ToList();
                    if (result.Count > 0)
                    {
                        return result[0];
                    }
                    else
                    {
                        var m = new TenderingResult()
                        {
                            TenderingId = t.TenderingId
                        };
                        en.AddToTenderingResults(m);
                        en.SaveChanges();
                        CreateLog('C', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                        return m;
                    }
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static TenderingResult UpdateTenderingResult(TenderingResult n)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var t = (from items in en.TenderingResults where items.TenderingResultId == n.TenderingResultId select items).FirstOrDefault();
                    t.Date = n.Date;
                    t.FirstBid = n.FirstBid;
                    t.FirstCoeffecient = n.FirstCoeffecient;
                    t.FirstContractorWinnerId = n.FirstContractorWinnerId;
                    t.FirstMinus = n.FirstMinus;
                    t.FirstPlus = n.FirstPlus;
                    t.Notes = n.Notes;
                    t.Renewal = n.Renewal;
                    t.RenewalNote = n.RenewalNote;
                    t.SecondBid = n.SecondBid;
                    t.SecondCoefficient = n.SecondCoefficient;
                    t.SecondContractorWinnerId = n.SecondContractorWinnerId;
                    t.SecondMinus = n.SecondMinus;
                    t.SecondPlus = n.SecondPlus;
                    en.SaveChanges();
                    CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                    return t;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }


        public static bool HasAccessToContract(Contract contract)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var x = new RTM.Classes.Converters.PositionConverter();
                    string position = x.Convert(UserData.CurrentUser.PositionId, null, null, null).ToString();
                    if (position.Contains("مدیر کل"))
                        return true;
                    else if (position.Contains("رئیس") || position.Contains("رییس"))
                    {
                        var y = new RTM.Classes.OrganizationalChartConverter();
                        if (y.Convert(UserData.CurrentUser.OrganizationPosition, null, null, null).ToString().Contains("پیمان"))
                            return true;
                    }
                    else if (position.Contains("معاون"))
                    {
                        var y = new RTM.Classes.OrganizationalChartConverter();
                        if (y.Convert(UserData.CurrentUser.OrganizationPosition, null, null, null).ToString().Contains("مالی"))
                            return true;
                        if (UserData.CurrentUser.OrganizationPosition == contract.SupervisingUnit || UserData.CurrentUser.OrganizationPosition == contract.SupervisingUnitHigher)
                            return true;
                    }
                    var temp = (
                                 from items in en.UserContractAccesses
                                 where items.ContractId == contract.Contractid &&
                                 items.UserId == UserData.CurrentUser.UserId
                                 select items).ToList();
                    if (temp.Count > 0)
                        return true;
                    else
                        return false;

                }
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public static List<User> RetrieveContractAccess(Contract contract)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var temp = (
                                 from items in en.UserContractAccesses
                                 from items2 in en.Users
                                 where items.ContractId == contract.Contractid &&
                                 items.UserId == items2.UserId
                                 select items2.UserId).ToList();

                    var res = from items in en.Users where temp.Contains(items.UserId) select items;
                    return res.ToList();
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static void UpdateContractAccess(List<User> users, Contract contract)
        {
            List<UserContractAccess> accesses = new List<UserContractAccess>();
            foreach (var item in users)
            {
                accesses.Add(new UserContractAccess()
                {
                    ContractId = contract.Contractid,
                    UserId = item.UserId
                });
            }
            using (var en = new RTMEntities())
            {
                try
                {
                    var list = from items in en.UserContractAccesses where items.ContractId == contract.Contractid select items;
                    foreach (var item in list)
                    {
                        en.UserContractAccesses.DeleteObject(item);
                    }
                    en.SaveChanges();
                    foreach (var item in accesses)
                    {
                        en.AddToUserContractAccesses(item);
                    }
                    en.SaveChanges();
                    CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                }
                catch (System.Exception ex)
                {

                }
            }
        }

        public static string GenerateTenderingSystemCode(Tendering t, ContractorRequest request)
        {
            try
            {
                string result = "A";
                using (var en = new RTMEntities())
                {
                    var title = (from items in en.TenderingTitles where items.TenderingTitleId == request.TenderingTitleId select items).FirstOrDefault();
                    string second = title.Code;
                    string third = (t.TenderingType.Contains("محدود")) ? "1" : (t.TenderingType.Contains("عموم") ? "2" : (t.TenderingType.Contains("ترک") ? "3" : (t.TenderingType.Contains("انحصار") ? "4" : "5")));
                    string type = (t.TenderingType.Contains("محدود")) ? "محدود" : (t.TenderingType.Contains("عموم") ? "عموم" : (t.TenderingType.Contains("ترک") ? "ترک" : (t.TenderingType.Contains("انحصار") ? "انحصار" : "بین")));
                    string fourth = ((new System.Globalization.PersianCalendar()).GetYear((DateTime)request.RequestDate) % 100).ToString();
                    DateTime date = new DateTime(request.RequestDate.Value.Year, 4, 20); ;
                    DateTime date2;
                    if (request.RequestDate > date)
                    {
                        date = new DateTime(request.RequestDate.Value.Year, 4, 20);
                        date2 = new DateTime(request.RequestDate.Value.Year + 1, 4, 20);
                    }
                    else
                    {
                        date2 = new DateTime(request.RequestDate.Value.Year, 4, 20);
                        date = new DateTime(request.RequestDate.Value.Year - 1, 4, 20);
                    }
                    int count = (from reqs in en.ContractorRequests
                                 from tens in en.Tenderings
                                 where tens.ContractorRequestId == reqs.ContractorRequestId &&
                                 reqs.RequestDate > date && reqs.RequestDate < date2 &&
                                 reqs.TenderingTitleId == request.TenderingTitleId &&
                                 tens.TenderingNumber != null &&
                                 tens.IsNotice == false &&
                                 tens.TenderingType.Contains(type)
                                 select tens.TenderingId
                                     ).Count() + 1;
                    result += second + third + "-" + fourth + "-" + ((count < 10) ? ("00" + count.ToString()) : (count < 100 ? ("0" + count.ToString()) : count.ToString()));
                }
                return result;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static string GenerateNoticeSystemCode(Tendering t, ContractorRequest request)
        {
            try
            {
                string result = "A";
                using (var en = new RTMEntities())
                {
                    var title = (from items in en.TenderingTitles where items.TenderingTitleId == request.TenderingTitleId select items).FirstOrDefault();
                    string second = title.Code;
                    string third = "9"; //(t.TenderingType.Contains("محدود")) ? "1" : (t.TenderingType.Contains("عموم") ? "2" : (t.TenderingType.Contains("ترک") ? "3" : (t.TenderingType.Contains("انحصار") ? "4" : "5")));
                    //string type = (t.TenderingType.Contains("محدود")) ? "محدود" : (t.TenderingType.Contains("عموم") ? "عموم" : (t.TenderingType.Contains("ترک") ? "ترک" : (t.TenderingType.Contains("انحصار") ? "انحصار" : "بین")));
                    string fourth = ((new System.Globalization.PersianCalendar()).GetYear((DateTime)request.RequestDate) % 100).ToString();
                    DateTime date = new DateTime(request.RequestDate.Value.Year, 4, 20);
                    DateTime date2;
                    if (request.RequestDate > date)
                    {
                        date = new DateTime(request.RequestDate.Value.Year, 4, 20);
                        date2 = new DateTime(request.RequestDate.Value.Year + 1, 4, 20);
                    }
                    else
                    {
                        date2 = new DateTime(request.RequestDate.Value.Year, 4, 20);
                        date = new DateTime(request.RequestDate.Value.Year - 1, 4, 20);
                    }
                    int count = (from reqs in en.ContractorRequests
                                 from tens in en.Tenderings
                                 where tens.ContractorRequestId == reqs.ContractorRequestId &&
                                 reqs.RequestDate > date && reqs.RequestDate < date2 &&
                                 reqs.TenderingTitleId == request.TenderingTitleId &&
                                 tens.TenderingNumber != null &&
                                 tens.IsNotice == true 
                                 select tens.TenderingId
                                     ).Count() + 1;
                    result += second + third + "-" + fourth + "-" + ((count < 10) ? ("00" + count.ToString()) : (count < 100 ? ("0" + count.ToString()) : count.ToString()));
                }
                return result;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static List<Object> SearchLogs(SubSystem sub, DateTime? fromdate, DateTime? todate,int? userId)
        {
            try
            {
                string x = ((int)sub).ToString();
                using (var en = new RTMEntities())
                {
                    var result = (from item in en.Logs
                                  from users in en.Users
                                  from pos in en.Positions
                                  where item.Subsystem == x &&
                                  item.UserId == users.UserId &&
                                  users.PositionId == pos.PositionId &&
                                  (fromdate == null || item.Date >= fromdate) &&
                                  (todate == null || item.Date <= todate) &&
                                  (userId==null || userId == 0 || item.UserId == userId)
                                  select new
                                  {
                                      Date = item.Date,
                                      Type = item.Action,
                                      FirstName = users.Name,
                                      LastName = users.Family,
                                      Title = pos.PositionTitle,
                                      Description = item.Description,
                                      Machine = item.MachineName,
                                      Subsystem = item.Subsystem
                                  }).ToList<Object>();

                    return result;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static List<Contractor> RetrieveContractorShortList(Tendering t)
        {
            try
            {
                using (var entity = new RTMEntities())
                {
                    var f = (from items in entity.ContractorTenderingShortLists where items.TenderingId == t.TenderingId select items.ContractorId).ToList();
                    var res = (from items in entity.Contractors where f.Contains(items.ContractorId) select items).ToList();
                    return res;
                }
            }
            catch (System.Exception ex)
            {
                
                return null;
            }
        }
        public static void UpdateContractorShortList(Tendering t,List<Contractor> list)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var del = (from items in en.ContractorTenderingShortLists where items.TenderingId == t.TenderingId select items).ToList();
                    foreach (var item in del)
                    {
                        en.ContractorTenderingShortLists.DeleteObject(item);
                    }
                    en.SaveChanges();
                    foreach (var item in list)
                    {
                        var rel = new ContractorTenderingShortList()
                        {
                            ContractorId = item.ContractorId,
                            TenderingId = t.TenderingId
                        };
                        en.AddToContractorTenderingShortLists(rel);
                    }
                    en.SaveChanges();
                    CreateLog('U', (((int)(SubSystem.Tendering)).ToString()[0]), "");
                }
            }
            catch (System.Exception ex)
            {

            }
        }


        internal static System.Collections.IEnumerable RetrieveTenderingDownloadFiles(Tendering t)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var res = from items in en.TenderingFileDownloads where items.number == t.TenderingNumber select items;
                    return res.ToList();
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        //Added By Naseri 920630
        public static string RetrieveContractInformation(Contract c)
        {
            var entity = new RTMEntities();
            string paymankarname;
            try
            {
                var Paymankar = (from PaymankarInfo in entity.Contractors where PaymankarInfo.ContractorId == c.ContractorId select PaymankarInfo).FirstOrDefault();
                paymankarname = Paymankar.CompanyName;
            }
            catch (System.Exception ex)
            {
                return null;
            }
            return paymankarname;
        }
        public static string RetrieveContractInformationMoshaver(Contract c)
        {
            var entity = new RTMEntities();
            string moshavername;
            try
            {
                var moshaver = (from moshaverInfo in entity.Contractors where moshaverInfo.ContractorId == c.ConsultantId select moshaverInfo).FirstOrDefault();
                moshavername = moshaver.CompanyName;
            }
            catch (System.Exception ex)
            {
                return null;
            }
            return moshavername;
        }
        public static string RetrieveContractInformationVahedNezarat(Contract c)
        {
            var entity = new RTMEntities();
            string VahedNezaratrname;
            try
            {
                var VahedNezarat = (from VahedNezaratInfo in entity.OrganizationalCharts where VahedNezaratInfo.ChartNodeId == c.SupervisingUnit select VahedNezaratInfo).FirstOrDefault();
                VahedNezaratrname = VahedNezarat.Title;
            }
            catch (System.Exception ex)
            {
                return null;
            }
            return VahedNezaratrname;
        }
        public static string RetrieveContractInformationVahedNezaratAlieh(Contract c)
        {
            var entity = new RTMEntities();
            string VahedNezaratAliehname;
            try
            {
                var VahedNezaratAlieh = (from VahedNezaratAliehInfo in entity.OrganizationalCharts where VahedNezaratAliehInfo.ChartNodeId == c.SupervisingUnitHigher select VahedNezaratAliehInfo).FirstOrDefault();
                VahedNezaratAliehname = VahedNezaratAlieh.Title;
            }
            catch (System.Exception ex)
            {
                return null;
            }
            return VahedNezaratAliehname;
        }
        //Added By Naseri 920630
        public static decimal RetrieveContractBudget(PaymentDraft p)
        {
            var entity = new RTMEntities();

            try
            {
                var contract = (from items in entity.Contracts where items.Contractid == p.ContractId select items).First();
                //var contracttype = (from contype in entity.ContractTypes where contype.ContractTypeId = contract.ContractTypeId select contype).First();
                var t = from item in entity.ContractDocFileRelations where item.ContractId == p.ContractId select item.FileId;
                var contractfile = (from cf in entity.ContractFiles where t.Contains(cf.FileId) && cf.Is25Percent == true select cf.Percent).FirstOrDefault();
                if (contractfile == null || Convert.ToString(contractfile) == string.Empty)
                    return (decimal)contract.ContractBudget;
                else
                    return (decimal)((((double)contract.ContractBudget * (double)contractfile) / 100) + (double)contract.ContractBudget);
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }
        public static decimal RetrieveSumPreHavale(int contracttypeid, PaymentDraft p)
        {
            if (contracttypeid == 4)
            {
                try
                {
                    var entity = new RTMEntities();
                    var contract = (from con in entity.Contracts where con.Contractid == p.ContractId select con.ContractTypeId).FirstOrDefault();
                    var sumcurrentsituationdraft = (from item in entity.PaymentDrafts where item.ContractId == p.ContractId && contract.Value == contracttypeid && item.PaymentDraftId != p.PaymentDraftId && p.PaymentType == "صورت وضعيت" select item.CurrentSituationDraft).Sum();
                    if (sumcurrentsituationdraft == null)
                        sumcurrentsituationdraft = 0;
                    return (decimal)sumcurrentsituationdraft;
                }
                catch (System.Exception ex)
                {
                    return -1;
                }
            }
            else if (contracttypeid == 5)
            {
                try
                {
                    var entity = new RTMEntities();
                    var contract = (from con in entity.Contracts where con.Contractid == p.ContractId select con.ContractTypeId).FirstOrDefault();
                    var sumcurrentsituationdraft = (from item in entity.PaymentDrafts where item.ContractId == p.ContractId && contract.Value == contracttypeid && p.PaymentType == "صورت وضعيت" && p.PaymentType2 == "نظارت کارگاهی" select item.CurrentSituationDraft).Sum();
                    if (sumcurrentsituationdraft == null)
                        sumcurrentsituationdraft = 0;
                    return (decimal)sumcurrentsituationdraft;
                }
                catch (System.Exception ex)
                {
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }
        public static int RetrieveContractTypeId(PaymentDraft p)
        {
            var entity = new RTMEntities();
            int contracttypeid;
            try
            {
                var ContractType = (from item in entity.Contracts where item.Contractid == p.ContractId select item).FirstOrDefault();
                contracttypeid = (int)ContractType.ContractTypeId;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
            return contracttypeid;
        }
        //Added By Naseri 920630
    }

}


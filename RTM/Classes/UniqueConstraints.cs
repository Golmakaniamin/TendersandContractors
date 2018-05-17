using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTM.Classes
{
    class UniqueConstraints
    {
        
        public static bool ValidContractNumber(string contractNumber,Contract c)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var t = (from items in en.Contracts where items.ContractNumber == contractNumber select items).FirstOrDefault();
                    if (t == null || t.Contractid == c.Contractid)
                        return true;
                    else
                        return false;
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage(Errors.ConnectionError);
                return false;
            }
        }

        internal static bool ValidPaymentDraft(string paymentNumber,PaymentDraft p)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var t = (from items in en.PaymentDrafts where items.PaymentDraftNumber == paymentNumber select items).FirstOrDefault();
                    if (t == null || t.PaymentDraftId == p.PaymentDraftId)
                        return true;
                    else
                        return false;
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage(Errors.ConnectionError);
                return false;
            }
        }

        internal static bool ValidRequestNumber(string p,ContractorRequest c)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var t = (from items in en.ContractorRequests where items.RequestNumber == p select items).FirstOrDefault();
                    if (t == null || t.ContractorRequestId == c.ContractorRequestId)
                        return true;
                    else
                        return false;
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage(Errors.ConnectionError);
                return false;
            }
        }

        internal static bool ValidSocialSecurityNumber(string p, User u)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var t = (from items in en.Users where items.SocialNumber == p select items).FirstOrDefault();
                    if (t == null || t.UserId == u.UserId)
                        return true;
                    else
                        return false;
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage(Errors.ConnectionError);
                return false;
            }
        }

        internal static Tendering ExistTenderingNumber(string p,Contract c)
        {
            try
            {
                using (var en = new RTMEntities())
                {
                    var t = (from items in en.Tenderings where items.TenderingNumber == p select items).FirstOrDefault();
                    if (t == null || t.TenderingNumber ==c.TenderingSystemCode )
                        return null;
                    else
                        return t;
                }
            }
            catch (System.Exception ex)
            {
                ErrorHandler.ShowErrorMessage(Errors.ConnectionError);
                return null;
            }
        }
    }
}

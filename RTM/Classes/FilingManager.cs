using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RTM.Classes
{
    class FileDataObject
    {
        public string FileName { set; get; }
        public byte[] FileContent { set; get; }
    }
    public delegate void FilingJobDone();
    class FilingManager
    {
        public static event FilingJobDone TransactionFinished;
        private static BusyIndicator busy = new BusyIndicator();
        public static bool UploadTenderingFile(int tenderingId, TenderingIndex docIndex, int? contractorId, string version, Grid layoutRoot,int? advertisementId=null,int? meetingId=null,int? warrantyId = null)
        {
            TenderingDocumentFile f = new TenderingDocumentFile();
            TenderingDocumentFileRelation rel = new TenderingDocumentFileRelation();
            rel.ContractorId = contractorId;
            rel.TenderingDocumentId = DataManagement.RetrieveTenderingDocumentId(docIndex);
            if (rel.TenderingDocumentId == -1)
                return false;
            rel.TenderingId = tenderingId;
            rel.AdvertisementId = advertisementId;
            rel.MeetingId = meetingId;
            rel.WarrantyId = warrantyId;
            f.Version = version;
            f.AttachedDate = DateTime.Now;
            f.FileGuid = Guid.NewGuid();
            string fileLocation = OpenFileHandler.OpenFileToUpload();
            if (fileLocation == null)
                return false;
            layoutRoot.Children.Add(busy);
            Task<bool>.Factory.StartNew(delegate
            {
                f.FileContent = OpenFileHandler.GetFileFromLocation(fileLocation);
                f.Name = System.IO.Path.GetFileName(fileLocation);

                if (DataManagement.AddTenderingFile(f) != -1)
                {
                    rel.TenderingDocumentFileId = f.TenderingDocumentFileId;
                    if (DataManagement.AddTenderingFileRelation(rel) == -1)
                    {
                        return false;
                    }
                    f = null;
                    GC.Collect();
                    return true;
                }
                else
                {
                    return false;
                }

            }).ContinueWith( prev =>
            {
                layoutRoot.Children.Remove(busy);
                bool result = prev.Result;
                if (result)
                {
                    ErrorHandler.NotifyUser("فایل با موفقیت ثبت شد.");
                    if (TransactionFinished != null)
                        TransactionFinished();
                }
                else
                {
                    ErrorHandler.ShowErrorMessage("ثبت فایل امکان پذیر نبود لطفا دوباره سعی کنید.");
                }
                
            }, TaskScheduler.FromCurrentSynchronizationContext());
            return true;
        }
        public static bool DownloadTenderingFile(int tenderingId, TenderingIndex docIndex, int? contractorId, string version, Grid layoutRoot, int? advertisementId = null, int? meetingId = null, int? warrantyId = null)
        {
            int docid = DataManagement.RetrieveTenderingDocumentId(docIndex);
            if (docid == -1)
                return false;
            layoutRoot.Children.Add(busy);
            Task<bool>.Factory.StartNew(delegate
            {
                FileDataObject t = DataManagement.RetrieveTenderingFile(tenderingId,docid,contractorId,advertisementId,meetingId,warrantyId);
                if (t == null)
                    return false;
                OpenFileHandler.OpenFileFromByte(t.FileContent, t.FileName);
                t = null;
                GC.Collect();
                return true;


            }).ContinueWith(Pre =>
            {
                layoutRoot.Children.Remove(busy);
                if (!Pre.Result)
                    ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NoFile"]);
            }, TaskScheduler.FromCurrentSynchronizationContext());
            return true;
        }
        public static bool DeleteTenderingFile(int tenderingId, TenderingIndex docIndex, int? contractorId, string version, Grid layoutRoot, int? advertisementId = null, int? meetingId = null, int? warrantyId = null)
        {
            if (!HasTenderingFile(tenderingId, docIndex, contractorId, version, layoutRoot, advertisementId, meetingId) && warrantyId==null)
            {
                ErrorHandler.ShowErrorMessage("فایل ثبت شده وجود ندارد!ابتدا فایل را بارگذاری کنید");
                return false;
            }
            if (!UserData.CurrentAccessRight.TenderingDelete)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return false;
            }
            int docid = DataManagement.RetrieveTenderingDocumentId(docIndex);
            if (docid == -1)
                return false;
            if (ErrorHandler.PromptUserForPermision(ErrorHandler.ErrorMessages["Prompt"]) == MessageBoxResult.No)
            {
                return false ;
            } 
            layoutRoot.Children.Add(busy);
            Task.Factory.StartNew(delegate
            {
                DataManagement.DeleteTenderingFile(tenderingId, docid, contractorId,advertisementId,meetingId,warrantyId);
            }).ContinueWith(delegate
            {
                layoutRoot.Children.Remove(busy);
                if (TransactionFinished != null)
                    TransactionFinished();
            }, TaskScheduler.FromCurrentSynchronizationContext());
            return true;
        }
        public static bool HasTenderingFile(int tenderingId, TenderingIndex docIndex, int? contractorId, string version, Grid layoutRoot, int? advertisementId = null, int? meetingId = null)
        {
            int docid = DataManagement.RetrieveTenderingDocumentId(docIndex);
            if (docid == -1)
                return false;
            return DataManagement.HasTenderingFile(tenderingId, docid, contractorId, advertisementId, meetingId);
            
        }
        public static bool DeleteTenderingFile(int fileId,Grid layoutRoot)
        {
            if (!UserData.CurrentAccessRight.TenderingDelete)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return false ;
            }
            if (fileId <=0)
                return false;
            if (ErrorHandler.PromptUserForPermision(ErrorHandler.ErrorMessages["Prompt"]) == MessageBoxResult.No)
            {
                return false;
            }
            layoutRoot.Children.Add(busy);
            Task.Factory.StartNew(delegate
            {
                DataManagement.DeleteTenderingFile(fileId);
            }).ContinueWith(delegate
            {
                layoutRoot.Children.Remove(busy);
                if (TransactionFinished != null)
                    TransactionFinished();
            }, TaskScheduler.FromCurrentSynchronizationContext());
            return true;
        }


        public static bool UploadContractFile(int contractId, ContractIndex docIndex,string version,Grid layoutRoot)
        {
            ContractFile f = new ContractFile();
            f.Version = version;
            f.AttachedDate = DateTime.Now;
            f.FileGuid = Guid.NewGuid();
            string fileLocation = OpenFileHandler.OpenFileToUpload();
            if (fileLocation == null)
                return false;
            layoutRoot.Children.Add(busy);
            Task<bool>.Factory.StartNew(delegate
            {
                f.FileContent = OpenFileHandler.GetFileFromLocation(fileLocation);
                f.Name = System.IO.Path.GetFileName(fileLocation);

                if (DataManagement.AddContractFile(contractId,docIndex,f) != -1)
                {
                    f = null;
                    GC.Collect();
                    return true;
                }
                else
                {
                    return false;
                }

            }).ContinueWith(prev =>
            {
                layoutRoot.Children.Remove(busy);
                bool result = prev.Result;
                if (result)
                {
                    ErrorHandler.NotifyUser("فایل با موفقیت ثبت شد.");
                    if (TransactionFinished != null)
                        TransactionFinished();
                }
                else
                {
                    ErrorHandler.ShowErrorMessage("ثبت فایل امکان پذیر نبود لطفا دوباره سعی کنید.");
                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
            return true;
        }
        public static bool DownloadContractFile(int contractId, ContractIndex docIndex, int? fileId, Grid layoutRoot)
        {
            int docid = (int)docIndex;
            if (docid == -1)
                return false;
            layoutRoot.Children.Add(busy);
            Task<bool>.Factory.StartNew(delegate
            {
                FileDataObject t = DataManagement.RetrieveContractFile(contractId,docid,fileId);
                if (t == null)
                    return false;
                OpenFileHandler.OpenFileFromByte(t.FileContent, t.FileName);
                t = null;
                GC.Collect();
                return true;


            }).ContinueWith(Pre =>
            {
                layoutRoot.Children.Remove(busy);
                if (!Pre.Result)
                    ErrorHandler.ShowErrorMessage(ErrorHandler.ErrorMessages["NoFile"]);
                if (TransactionFinished != null)
                    TransactionFinished();
            }, TaskScheduler.FromCurrentSynchronizationContext());
            return true;
        }
        public static bool DeleteContractFile(int contractId, ContractIndex docIndex, int fileId, Grid layoutRoot)
        {
            if (!UserData.CurrentAccessRight.ContractDelete)
            {
                ErrorHandler.ShowErrorMessage("امکان انجام این عملیات وجود ندارد");
                return false;
            }
            int docid = (int)(docIndex);
            if (docid == -1)
                return false;
            if (ErrorHandler.PromptUserForPermision(ErrorHandler.ErrorMessages["Prompt"]) == MessageBoxResult.No)
            {
                return false;
            }
            layoutRoot.Children.Add(busy);
            Task.Factory.StartNew(delegate
            {
                DataManagement.DeleteContractFile(fileId);
            }).ContinueWith(delegate
            {
                layoutRoot.Children.Remove(busy);
                if (TransactionFinished != null)
                    TransactionFinished();
            }, TaskScheduler.FromCurrentSynchronizationContext());
            return true;
        }

        public static FileDataObject GetFileDataObject()
        {
            FileDataObject result = new FileDataObject();
            string fileLocation = OpenFileHandler.OpenFileToUpload();
            if (fileLocation == null)
                return null;
            result.FileContent = OpenFileHandler.GetFileFromLocation(fileLocation);
            result.FileName = System.IO.Path.GetFileName(fileLocation);
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Classes.FileServiceProxy
{
    //public class FileServiceClientProxy : ClientBase<IFileManagerService>, IFileManagerService, IDisposable
    //{
    //    public FileServiceClientProxy()
    //        : base("FileManager")
    //    {
    //    }

 

    //    #region IDisposable Members

    //    void IDisposable.Dispose()
    //    {
    //        if (this.State == CommunicationState.Opened)
    //            this.Close();
    //    }

    //    #endregion

    //    public System.IO.Stream DownloadFile(string path)
    //    {
    //        return base.Channel.DownloadFile(path);
    //    }

    //    //public OperationResultInfo UploadFile(FileTransferMessage fileMessage)
    //    //{
    //    //    return base.Channel.UploadFile(fileMessage);
    //    //}
    //}
}

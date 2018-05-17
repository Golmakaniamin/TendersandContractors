using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Imaging;
using Classes.FileServiceProxy;

namespace RTM.Classes
{
    class OpenFileHandler
    {
        public static string GetFileLocation(string windowTitle, string filter = "pictures(*.jpeg)|*.jpeg|Pictures(*.jpg)|*.jpg |Pictures(*.png)|*.png | All|*.*")
        {
            OpenFileDialog ofl = new OpenFileDialog();
            ofl.Title = windowTitle;
            ofl.Filter = filter;
            bool? result = ofl.ShowDialog();
            if (result == true)
            {
                return ofl.FileName;
            }
            return "";
        }
        public static string OpenFileToUpload()
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Title = "فایل مورد نظر خود را انتخاب کنید.",
                RestoreDirectory = true,
                CheckFileExists = true
            };
            dlg.ShowDialog();
            if (dlg.FileName != "")
            {
                return dlg.FileName;
            }
            else
            {
                return null;
            }
        }
     
        
        public static byte[] GetFileFromLocation(string location)
        {
            try
            {
                FileStream fs = new FileStream(location, FileMode.Open, FileAccess.Read);
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();
                return data;
            }
            catch (System.Exception ex)
            {

            }
            return null;
        }

        public static void OpenFileFromByte(byte[] fileContent, string fileName)
        {
            if (fileContent == null)
            {
                ErrorHandler.ShowErrorMessage("در حال حاضر دسترسی به این فایل امکان پذیر نیست");
                return;
            }
            if (!Directory.Exists(@"temp\"))
                Directory.CreateDirectory(@"temp\");
            FileStream fs;
            try
            {
            	fs = new FileStream(@"temp\"+fileName, FileMode.Create);
            }
            catch (System.Exception ex)
            {

                OpenFileFromByte(fileContent, "1"+fileName);
                return;
            }
            
            BinaryWriter bw = new BinaryWriter(fs);
            try
            {
                bw.Write(fileContent);
                fileContent = null;
                GC.Collect();
                System.Diagnostics.Process.Start(@"temp\"+fileName);
            }
            catch(Exception error)
            {
                //Console.Write(error.Message);
            }
            finally
            {
                fs.Close();
                bw.Close();
            }
            
        }

        public static BitmapImage RetrieveUserImage(RTM.User user)
        {
            try
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                if (user.Picture == null)
                {
                    return null;
                }
                bitmap.StreamSource = new MemoryStream(user.Picture);
                bitmap.EndInit();
                return bitmap;
            }
            catch (System.Exception ex)
            {

            }
            return null;
        }
        public static BitmapImage RetrieveImage(byte[] Picture)
        {
            try
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                if (Picture == null)
                {
                    return null;
                }
                bitmap.StreamSource = new MemoryStream(Picture);
                bitmap.EndInit();
                return bitmap;
            }
            catch (System.Exception ex)
            {

            }
            return null;
        }

        //public static string UploadFileToServer(string serverFileLocation, string windowTitle = "Upload", string filter = "pdf|*.pdf|Pictures|*.jpg |All |*.*")
        //{
        //    OpenFileDialog dlg = new OpenFileDialog()
        //    {
        //        Title = "Select a file to upload",
        //        RestoreDirectory = true,
        //        CheckFileExists = true
        //    };

        //    dlg.ShowDialog();

        //    if (!string.IsNullOrEmpty(dlg.FileName))
        //    {
        //        string virtualPath = serverFileLocation;
        //        virtualPath += System.IO.Path.GetFileName(dlg.FileName);

        //        using (Stream uploadStream = new FileStream(dlg.FileName, FileMode.Open))
        //        {

        //            using (var client = new FileServiceClientProxy())
        //                client.UploadFile(new FileTransferMessage() { Path = virtualPath, DataStream = uploadStream });
        //        }
        //        return System.IO.Path.GetFileName(dlg.FileName);
        //    }
        //    return "";
        //}

        //public static void DownloadFileFromServer(string serverFileLocation, string windowTitle = "Upload", string filter = "pdf|*.pdf|Pictures|*.jpg |All |*.*")
        //{
        //    string path = serverFileLocation;
        //    SaveFileDialog dlg = new SaveFileDialog()
        //    {
        //        RestoreDirectory = true,
        //        OverwritePrompt = true,
        //        Title = "Save as...",
        //        FileName = System.IO.Path.GetFileName(path)
        //    };

        //    dlg.ShowDialog();

        //    if (!string.IsNullOrEmpty(dlg.FileName))
        //    {
        //        using (FileStream output = new FileStream(dlg.FileName, FileMode.Create))
        //        {
        //            Stream downloadStream;

        //            using (FileServiceClientProxy client = new FileServiceClientProxy())
        //            {
        //                downloadStream = client.DownloadFile(path);
        //            }

        //            downloadStream.CopyTo(output);
        //        }
        //    }
        //}

        //public static void DownloadFileFromServerToTemp(string serverFileLocation,string fileName, string windowTitle = "Upload", string filter = "pdf|*.pdf|Pictures|*.jpg |All |*.*")
        //{
        //    string path = serverFileLocation;
        //    string directory = Path.GetDirectoryName(fileName);
        //    if (!Directory.Exists(directory))
        //        Directory.CreateDirectory(directory);
        //    using (FileStream output = new FileStream(fileName, FileMode.Create))
        //    {
        //        Stream downloadStream;

        //        using (FileServiceClientProxy client = new FileServiceClientProxy())
        //        {
        //            downloadStream = client.DownloadFile(path);
        //        }
        //        downloadStream.CopyTo(output);
        //    }
        //    System.Diagnostics.Process.Start(fileName);
        //}
    }
}

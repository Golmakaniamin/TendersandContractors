using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace RTM.Classes
{
    class ErrorHandler
    {
        public static Dictionary<string, string> ErrorMessages = new Dictionary<string, string>()
        {
           {"FailedSave","ثبت با مشکل مواجه شد."},
           {
               "NotSaved","قبل از بارگذاری فایل باید ثبت صورت گیرد."
           },
           {
               "SuccessfulSave","ثبت با موفقیت انجام شد."
           },
           {
               "NotSelected","هیچ موردی انتخاب نشده است."
           },
           {
               "NoFile","فایلی ثبت نشده است."
           },
           {
               "Prompt","این فایل پاک شود ؟"
           },
           {
               "StageError","ابتدا مراحل قبلی ثبت مناقصه را به پایان رسانید"
           }

        };
        public static void ShowErrorMessage(string message)
        {
            System.Windows.MessageBox.Show(message, "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static MessageBoxResult PromptUserForPermision(string message)
        {
            return MessageBox.Show(message, "", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        public static void NotifyUser(string message)
        {
            System.Windows.MessageBox.Show(message, "نتیجه عملیات", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTM.Classes
{
    class Errors
    {
        public static string ConnectionError = " در حال حاضر دسترسی به سرور امکان پذیر نیست لطفا مجددا سعی کنید";
        public static string InvalidNumber = "شماره وارد شده قبلا در سیستم ثبت شده است.";
        public static string NotFoundTendering = "مناقصه مورد نظر در سیستم یافت نشد";
        public static string FoundTendering = "مناقصه مورد نظر در سیستم یافت شد";
        public static string NotFoundNotice = "فراخوان مورد نظر در سیستم یافت نشد";
        public static string FoundNotice = "فراخوان مورد نظر در سیستم یافت شد";
        public static string PermanentRecord = "ثبت دائم با موفقیت انجام شد";
        public static string Saved = "ثبت با موفقیت انجام شد";
        public static string FailedSave = "ثبت با مشکل مواجه شد";
        public static string Permanented = "سند به تایید نهایی رسیده است";
        public static string NoFile = "فایلی ثبت نشده است.";
        public static string Deleted = "حذف با موفقیت انجام شد";

        public static string NotSelected = "موردی انتخاب نشده است";

        public static string DatesMismatch = "توالی تاریخ ها رعایت نشده است";

        public static string ServerError = "تماس با سرور با مشکل مواجه شد";
        public static string NotSaved = "ابتدا فرم را ثبت کنید";

        public static string NotSearched = "ابتدا جستجو را انجام دهید";

        public static string OperationNotAllowed = "عملیات امکان پذیر نمی یاشد";

        public static string IncompleteNotice = "ارزیابی کیفی برای این فراخوان صورت نگرفته است";
    }
}

namespace Restaurant.Application.Constants;

public static class Messages
{
    public static class Validation
    {
        public const string Required = "وارد کردن {PropertyName} الزامی است.";
        public const string MaxLength = "{PropertyName} نمیتواند بیشتر از {MaxLength} کاراکتر باشد.";
        public const string RegularExpression = "فرمت عبارت وارد شده اشتباه است.";
        public const string MaxFileSize = "اندازه فایل بیش از حد مجاز است";
        public const string FileExtensionNotValid = "فرمت فایل غیر مجاز میباشد";
        public const string GreaterThanZero = "0 باید بزرگتر از {PropertyName} باشد";
        public const string FromAndToDateGreaterThan = "زمان شروع نمیتواند از زمان پایان بزرگتر باشد";
        public const string GreaterThanNowDateTime = "زمان شروع نمیتواند عقبتر از زمان فعلی باشد";
        public const string EqualFromAndToDateDays = "تاریخ شروع و پایان باید در یک روز باشد";
    }

    public static class Subjects
    {
        public const string LoginCodeMailSubject = "کد ورود به حساب کاربری";
    }

    public static class Errors
    {
        public const string CodeNotValid = "کد درست نیست";
        public const string TitleOrSlugIsExists = "این عنوان یا Slug قبلا ثبت شده است";
        public const string FileUploadFiled = "آپلود فایل با شکست مواجه شد";
        public const string TimeNotFree = "زمان آزاد نیست";
        public const string BranchClosedInThisTime = "شعبه در این زمان بسته است";
        public const string OrderIsNotForThisUser = "سفارش برای این کاربر نیست";
        public const string UserHasDuringOrPayingOrder = "کاربر شفارش در حال انجام یا در حال پرداخت دارد";
        public const string VerifyPaymentFiled = "تائید پرداخت با شکست مواجه شد";
        public const string OrderPaid = "سفارش پرداخت شده است";
        public const string OnlyDuringOrdersCanBeDeleted = "فقط سفارش های در جریان را میتوان حذف کرد";
        public const string OnlyPayingOrdersCanBeCanceled = "فقط سفارش های در جریان را میتوان حذف کرد";
    }
}
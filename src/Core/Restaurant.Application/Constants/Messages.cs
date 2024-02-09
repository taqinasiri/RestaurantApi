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
    }
}
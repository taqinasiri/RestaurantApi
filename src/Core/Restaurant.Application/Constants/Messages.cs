namespace Restaurant.Application.Constants;

public static class Messages
{
    public static class Validation
    {
        public const string Required = "وارد کردن {PropertyName} الزامی است.";
        public const string MaxLength = "{PropertyName} نمیتواند بیشتر از {MaxLength} کاراکتر باشد.";
        public const string RegularExpression = "فرمت عبارت وارد شده اشتباه است.";
    }

    public static class Subjects
    {
        public const string LoginCodeMailSubject = "کد ورود به حساب کاربری";
    }
}
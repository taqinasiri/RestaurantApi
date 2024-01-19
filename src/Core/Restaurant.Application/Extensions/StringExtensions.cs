namespace Restaurant.Application.Extensions;

public static class StringExtensions
{
    public static bool HasValue(this string value,bool ignoreWhiteSpace = true)
        => ignoreWhiteSpace ? !string.IsNullOrWhiteSpace(value) : !string.IsNullOrEmpty(value);

    public static int ToInt(this string value)
        => Convert.ToInt32(value);

    public static decimal ToDecimal(this string value)
        => Convert.ToDecimal(value);

    public static string ToNumeric(this int value)
        => value.ToString("N0");

    public static string ToNumeric(this decimal value)
        => value.ToString("N0");

    public static string ToCurrency(this int value)
        => value.ToString("C0");

    public static string ToCurrency(this decimal value)
        => value.ToString("C0");

    public static string En2Fa(this string str)
        => str.Replace("0","۰").Replace("1","۱").Replace("2","۲").Replace("3","۳").Replace("4","۴").Replace("5","۵").Replace("6","۶").Replace("7","۷").Replace("8","۸").Replace("9","۹");

    public static string Fa2En(this string str)
        => str.Replace("۰","0").Replace("۱","1").Replace("۲","2").Replace("۳","3").Replace("۴","4").Replace("۵","5").Replace("۶","6").Replace("۷","7").Replace("۸","8").Replace("۹","9").Replace("٠","0").Replace("١","1").Replace("٢","2").Replace("٣","3").Replace("٤","4").Replace("٥","5").Replace("٦","6").Replace("٧","7").Replace("٨","8").Replace("٩","9");

    public static string FixPersianChars(this string str)
        => str.Replace("ﮎ","ک")
            .Replace("ﮏ","ک")
            .Replace("ﮐ","ک")
            .Replace("ﮑ","ک")
            .Replace("ك","ک")
            .Replace("ي","ی")
            .Replace(" "," ")
            .Replace("‌"," ")
            .Replace("ھ","ه");//.Replace("ئ", "ی");

    public static string CleanString(this string str)
        => str.Trim().FixPersianChars().Fa2En().NullIfEmpty();

    public static string NullIfEmpty(this string str)
        => str?.Length == 0 ? null : str;
}
namespace Restaurant.Application.Constants;

public static class EmailTemplates
{
    public static string LoginCodeEmail(string code,string email) =>
    $"""
        <div style="display: flex;justify-content: center;color: #F3EDC8;" dir="rtl">
            <div style="background-color: #9A031E;padding: 10px;width: 500px;border-radius: 20px;">
                <h1 style="text-align: center;">رستوران</h1>
                <hr />
                <h2 style="text-align: center;">درخواست کد ورود به حساب کاربری</h2>
                <p>سلام {email} عزیز</p>
                <p>کد شخصی شما جهت ورود به حساب کاربری : </p>
                <h3 style="text-align: center;">{code}</h3>
                <hr />
                <p>اگر شما این کد را درخواست نکرده‌اید میتوانید این ایمیل را نادیده بگیرید.</p>
            </div>
        </div>
     """;
}
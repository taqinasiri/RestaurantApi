﻿namespace Restaurant.Application.Constants;

public static class RegularExpressions
{
    public const string PhoneNumberOrEmail = @"^([\w-\.]+@([\w-]+\.)+[\w-]{2,})|09[\d]{9}$";
    public const string Email = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
    public const string PhoneNumber = @"^(0|0098|\+98)9\d{9}$";
    public const string UserName = @"^[A-Za-z0-9]+$";
    public const string VerificationCode = @"^[0-9]{1,6}$";
    public const string Slug = @"^[A-Za-z0-9]+(?:-[A-Za-z0-9]+)*$";
    public const string Base64 = @"^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$";
}
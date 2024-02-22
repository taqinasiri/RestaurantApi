﻿using Dto.Payment;
using ZarinPal.Class;

namespace Restaurant.Infrastructure.Payment;

public class ZarinPalSandboxPaymentService : IPaymentService
{
    private readonly ZarinPal.Class.Payment _payment = new Expose().CreatePayment();

    public async ValueTask<string> Payment(int amount,string merchantId,string callbackUrl,string? email,string? mobile,string? description = null)
    {
        var result = await _payment.Request(new DtoRequest()
        {
            Amount = amount,
            MerchantId = merchantId,
            CallbackUrl = callbackUrl,
            Email = email,
            Mobile = mobile,
            Description = description ?? "Description"
        },ZarinPal.Class.Payment.Mode.sandbox);

        return result.Authority;
    }

    public async ValueTask<(bool isSuccess, int? refId)> Verify(int amount,string merchantId,string authority,string status)
    {
        if(!status.Equals("OK",StringComparison.OrdinalIgnoreCase))
            return (false, null);

        var verification = await _payment.Verification(new DtoVerification()
        {
            Amount = amount,
            MerchantId = merchantId,
            Authority = authority,
        },ZarinPal.Class.Payment.Mode.sandbox);

        if(verification.Status is not 100 and not 101)
            return (false, null);

        return (true, verification.RefId);
    }
}
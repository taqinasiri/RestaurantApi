namespace Restaurant.Application.Contracts.Infrastructure;

public interface IPaymentService
{
    ValueTask<string> Payment(int amount,string merchantId,string callbackUrl,string? email,string? mobile,string? description = null);

    ValueTask<(bool isSuccess, int? refId)> Verify(int amount,string merchantId,string authority,string status);
}
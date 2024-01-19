using Restaurant.Api.Models;

namespace Restaurant.Api.Attributes;

public class ProducesResponseOkApiResultAttribute<TData> : ProducesResponseTypeAttribute where TData : class
{
    public ProducesResponseOkApiResultAttribute() : base(typeof(ApiResult<TData>),StatusCodes.Status200OK)
    {
    }
}
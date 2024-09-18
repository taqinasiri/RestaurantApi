using Newtonsoft.Json;
using Restaurant.Application.Models;
using System.Net;

namespace Restaurant.Api.Models;

public class ApiResult(bool isSuccess,HttpStatusCode statusCode,string message = null!)
{
    //public bool IsSuccess { get; set; } = isSuccess;
    //public HttpStatusCode StatusCode { get; set; } = statusCode;
    public string Message { get; set; } = message ?? statusCode.ToString();

    #region Errors

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public List<ValidationError>? ValidationErrors { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public List<string>? Errors { get; set; }

    #endregion Errors
}

public class ApiResult<TData>(bool isSuccess,HttpStatusCode statusCode,TData? data,string message = null!) : ApiResult(isSuccess,statusCode,message) where TData : class
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public TData? Data { get; set; } = data;
}
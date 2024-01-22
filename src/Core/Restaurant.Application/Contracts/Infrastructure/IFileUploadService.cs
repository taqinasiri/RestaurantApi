using Restaurant.Application.Models;

namespace Restaurant.Application.Contracts.Infrastructure;

public interface IFileUploadService
{
    ValueTask<FileUploadResult> UploadBase64(string base64,string path,string? fileName = null);
}
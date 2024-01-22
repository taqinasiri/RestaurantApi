using Restaurant.Application.Helpers;
using Restaurant.Application.Models;

namespace Restaurant.Infrastructure.File;

public class FileUploadService : IFileUploadService
{
    public async ValueTask<FileUploadResult> UploadBase64(string base64,string path,string? fileName = null)
    {
        base64 = base64.RemoveBase64Header();
        string fileExtension = base64.GetBase64Extension();
        fileName ??= StringHelper.GenerateGuid();
        path.CreateDirectoryIfNotExists();
        await base64.SaveBase64FileAsync(fileName,fileExtension,path);
        return new(true,fileName);
    }
}
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
        return new(true,$"{fileName}.{fileExtension}",fileExtension,(int)base64.GetBase64FileSize());
    }

    public void DeleteFile(string path,string fileName)
        => FileHelper.Delete(fileName,path);

    public async ValueTask<FileUploadResult> ReUploadBase64(string base64,string path,string oldFileName,string? newFileName = null)
    {
        var result = await UploadBase64(base64,path,newFileName);

        if(oldFileName is not null)
            DeleteFile(path,oldFileName);

        return result;
    }
}
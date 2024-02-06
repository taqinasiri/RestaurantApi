namespace Restaurant.Application.Contracts.Infrastructure;

public interface IFileUploadService
{
    ValueTask<FileUploadResult> UploadBase64(string base64,string path,string? fileName = null);

    void DeleteFile(string path,string fileName);

    ValueTask<FileUploadResult> ReUploadBase64(string base64,string path,string oldFileName,string? newFileName = null);
}
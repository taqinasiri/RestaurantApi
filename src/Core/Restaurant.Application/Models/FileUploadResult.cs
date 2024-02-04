namespace Restaurant.Application.Models;

public record class FileUploadResult(bool IsSuccedded,string? FileName = null,string? FileExtention = null,int FileSize = 0);
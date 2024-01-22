namespace Restaurant.Application.Models;

public record class FileUploadResult(bool IsSuccedded,string? fileName = null);
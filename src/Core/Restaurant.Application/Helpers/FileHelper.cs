using Microsoft.AspNetCore.Components.Forms;

namespace Restaurant.Application.Helpers;

public static class FileHelper
{
    #region Base64

    public static async Task SaveBase64FileAsync(this string base64,string fileName,string fileExtension,string path)
    {
        var bytes = Convert.FromBase64String(base64);
        string filePath = Path.Combine(path,$"{fileName}.{fileExtension}");
        await File.WriteAllBytesAsync(filePath,bytes);
    }

    public static string GetBase64Extension(this string base64)
        => base64[..5].ToUpper() switch
        {
            "IVBOR" => "png",
            "/9J/4" => "jpg",
            "AAAAF" => "mp4",
            "JVBER" => "pdf",
            "AAABA" => "ico",
            "UMFYI" => "rar",
            "E1XYD" => "rtf",
            "U1PKC" => "txt",
            "77U/M" => "srt",
            _ => string.Empty
        };

    public static long GetBase64FileSize(this string base64)
    {
        var bytes = Convert.FromBase64String(base64);
        return bytes.Length;
    }

    public static string RemoveBase64Header(this string base64)
    {
        var base64Splited = base64.Split(',');
        if(base64Splited.Length > 1)
            return base64Splited[1];
        return base64;
    }

    public static bool IsValidBase64(this string base64)
    {
        try
        {
            Convert.FromBase64String(base64);
            return true;
        }
        catch(FormatException)
        {
            return false;
        }
    }

    public static async Task<string> ConvertToBase64(this IBrowserFile file)
    {
        var memoryStream = new MemoryStream();
        await file.OpenReadStream().CopyToAsync(memoryStream);
        var bytes = memoryStream.ToArray();
        return Convert.ToBase64String(bytes);
    }

    #endregion Base64

    #region Delete

    public static void Delete(this string path)
    {
        if(File.Exists(path))
            File.Delete(path);
    }

    public static void Delete(this string fileName,string folderPath)
        => Delete(Path.Combine(folderPath,fileName));

    #endregion Delete

    #region Directory

    public static void CreateDirectoryIfNotExists(this string path)
    {
        if(!Path.Exists(path))
            Directory.CreateDirectory(path);
    }

    public static bool DirectoryIsExists(this string path)
        => Path.Exists(path);

    public static string CombineWithCurrentDirectory(this string path)
        => Path.Combine(Directory.GetCurrentDirectory(),path);

    #endregion Directory
}
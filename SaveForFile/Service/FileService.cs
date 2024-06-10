using SaveForFile.Interface;
using Serilog;

namespace SaveForFile.Service;

public class FileService : IFileService
{
    private readonly string _basePath = string.Empty;
    private const string _fileFolderName = "resumes";

    public string FileFolderName => _fileFolderName;

    public FileService(IWebHostEnvironment environment)
    {
        _basePath = environment.WebRootPath;
    }
    public Task<bool> DeleteFileAsync(string relativeFilePath)
    {
        string absoluteFilePath = Path.Combine(_basePath, relativeFilePath);

        if (!File.Exists(absoluteFilePath)) return Task.FromResult(false);

        try
        {
            File.Delete(absoluteFilePath);
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
    }

    public async Task<string> SaveFileAsync(IFormFile file)
    {
        if (!Directory.Exists(_basePath))
        {
            Log.Error("wwwroot is not exist!");
            Directory.CreateDirectory(_basePath);
        }

        if (!Directory.Exists(Path.Combine(_basePath, _fileFolderName)))
        {
            Log.Error("resumes not exist!");
            Directory.CreateDirectory(Path.Combine(_basePath, _fileFolderName));
        }

        string fileName = MakeName(file.FileName);
        string partPath = Path.Combine(_fileFolderName, fileName);
        string path = Path.Combine(_basePath, partPath);

        var stream = File.Create(path);
        await file.CopyToAsync(stream);
        stream.Close();

        return partPath;
    }

    private string MakeName(string fileName)
        => $"{Guid.NewGuid()}-{fileName}";
}
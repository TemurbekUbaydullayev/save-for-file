namespace SaveForFile.Interface;

public interface IFileService
{
    public string FileFolderName { get; }
    Task<string> SaveFileAsync(IFormFile file);
    Task<bool> DeleteFileAsync(string relativeImagePath);
}

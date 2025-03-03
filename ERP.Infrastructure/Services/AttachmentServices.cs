
namespace ERP.Infrastructure.Services;

public class AttachmentServices : IAttachmentServices
{
    public void Delete(string filePath)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine("Invalid file path.");
                return;
            }

            var oldImagePath = Path.Combine(ConstPathRoot.PathWWWRoot, filePath);

            if (File.Exists(oldImagePath))
            {
                File.Delete(oldImagePath);
                Console.WriteLine($"File deleted: {oldImagePath}");
            }
            else
                Console.WriteLine("File not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting file: {ex.Message}");
        }
    }

    public async Task<(bool isSaved, string fileName)> UploadFileAsync(IFormFile file, string folderName)
    {
        try
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var pathFolder = Path.Combine(ConstPathRoot.PathWWWRoot, folderName);

            if (!Directory.Exists(pathFolder))
                Directory.CreateDirectory(pathFolder);

            var filePath = Path.Combine(pathFolder, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                await file.CopyToAsync(fileStream);
            }

            return (true, fileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error uploading file: {ex.Message}");
            return (false, string.Empty);
        }
    }

}

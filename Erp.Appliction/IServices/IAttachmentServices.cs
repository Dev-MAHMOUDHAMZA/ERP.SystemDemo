

using Microsoft.AspNetCore.Http;

namespace Application.IServices;
public interface IAttachmentServices
{
    Task<(bool isSaved, string fileName)> UploadFileAsync(IFormFile file, string folderPath);
    void Delete(string filePath);

}

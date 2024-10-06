using Microsoft.AspNetCore.Http;

namespace Library.Service.Abstracts
{
    public interface IFileService
    {
        public Task<string> UploadImage(string Location, IFormFile file);
    }
}

using Application.DTO;
using Microsoft.AspNetCore.Http;

namespace Application.Service.Interface
{
    public interface IFileService
    {
        public byte[] GetFile(string fileName);
        public Task<FileDetailDTO> SaveFileToDisk(IFormFile file);
        public Task<List<FileDetailDTO>> SaveFilesToDisk(IList<IFormFile> file);
    }
}

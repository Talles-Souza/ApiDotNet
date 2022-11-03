using Application.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interface
{
    public interface IFileService
    {
        public byte[] GetFile(string fileName);
        public Task<FileDetailDTO> SaveFileToDisk(IFormFile file);
        public Task<List<FileDetailDTO>> SaveFilesToDisk(IList<IFormFile> file);
    }
}

using Application.DTO;
using Application.Service.Interface;
using Microsoft.AspNetCore.Http;

namespace Application.Service
{
    public class FileService : IFileService
    {
        private readonly string basePath;
        private readonly IHttpContextAccessor context;

        public FileService(IHttpContextAccessor context)
        {
            this.context = context;
            basePath = Directory.GetCurrentDirectory() + "\\UploadDir\\";
        }

        public byte[] GetFile(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<List<FileDetailDTO>> SaveFilesToDisk(IList<IFormFile> file)
        {
            return null;
            
        }

        public async Task<FileDetailDTO> SaveFileToDisk(IFormFile file)
        {
            FileDetailDTO fileDetail = new FileDetailDTO();
            
            
            var fileType =  Path.GetExtension(file.FileName);
            var baseUrl = context.HttpContext.Request.Host;
            

            if (fileType.ToLower() == ".pdf" || fileType.ToLower() == ".jpg" ||
                fileType.ToLower() == ".png" || fileType.ToLower() == ".jpeg" )
            {
                var docName = Path.GetFileName(file.FileName);
                if(file != null && file.Length > 0)
                {
                   
                    var destination = Path.Combine(basePath,"",docName);
                    fileDetail.DocumentName = docName;
                    fileDetail.DocType = fileType;
                    fileDetail.DocUrl = Path.Combine(baseUrl + "/api/File/uploadFile/" + fileDetail.DocumentName);
                    using var stream = new FileStream(destination, FileMode.Create);
                    await file.CopyToAsync(stream);
                }
            }
            return fileDetail;
        }
    }
}

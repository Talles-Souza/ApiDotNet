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
            var filePath = basePath+ fileName;  

            return File.ReadAllBytes(filePath);
        }

        public async Task<List<FileDetailDTO>> SaveFilesToDisk(IList<IFormFile> files)
        {
            List<FileDetailDTO> list = new List<FileDetailDTO>();
            foreach (var file in files)
            {
                list.Add(await SaveFileToDisk(file));
            }  
            return list;
            
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

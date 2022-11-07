using Application.DTO;
using Application.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }
        
        
        [HttpPost("uploadFile")]
        [ProducesResponseType((200), Type = typeof(FileDetailDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Produces("application/json")]
        public async Task<ActionResult> UploadOneFile([FromForm] IFormFile file)
        {
            FileDetailDTO detail = await _fileService.SaveFileToDisk(file);

            return new  OkObjectResult(detail);
        }

        [HttpPost("uploadMultipleFiles")]
        [ProducesResponseType((200), Type = typeof(List<FileDetailDTO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Produces("application/json")]
        public async Task<ActionResult> UploadManyFiles([FromForm] List<IFormFile> files)
        {
            List<FileDetailDTO> details = await _fileService.SaveFilesToDisk(files);

            return new  OkObjectResult(details);
        }

        [HttpGet("downloadFile/{fileName}")]
        [ProducesResponseType((200), Type = typeof(byte[]))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Produces("application/octet-stream")]
        public async Task<ActionResult> GetFileAsync(string fileName)
        {
            byte[] buffer  =  _fileService.GetFile(fileName);
            if (buffer != null)
            {
                HttpContext.Response.ContentType = 
                    $"application/{Path.GetExtension(fileName).Replace(".", "")}";
                HttpContext.Response.Headers.Add("content-length", buffer.Length.ToString());
                await HttpContext.Response.Body.WriteAsync(buffer, 0, buffer.Length); 
            }
            return new ContentResult();
        }
    }
}

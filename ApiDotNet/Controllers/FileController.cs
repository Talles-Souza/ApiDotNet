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
        public async Task<IActionResult> UploadOneFile([FromForm] IFormFile file)
        {
            FileDetailDTO detail = await _fileService.SaveFileToDisk(file);
            return new OkObjectResult(detail);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileManager.Interfaces;
using FileManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace FileManager.Controllers
{
    [Route("api/files/")]
    [ApiController]
    public class FileController(IFileService fileService) : ControllerBase
    {
        private readonly IFileService _fileService = fileService;
        [HttpPost("upload")]
        public async Task<string> Upload(IFormFile file)
        {
            return await _fileService.UploadFile(file);
        }
        // [HttpGet("download")]
        // public async Task<ActionResult> Download(string fileName)
        // {
        //     var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files\\Uploads\\", fileName);

        //     var provider = new FileExtensionContentTypeProvider();
        //     if(!provider.TryGetContentType(fileName, out var contentType))
        //     {
        //         contentType = "application/octet-stream";
        //     }

        //     var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
        //     return File(bytes, contentType, Path.GetFileName(filePath));
        // }
    
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileManager.Controllers
{
    [Route("api/files/")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<string> Upload([FromForm] FileUpload obj)
        {
            if (obj.File.Length > 0)
            {
                try
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "\\Files\\");
                    var dir = Directory.GetCurrentDirectory();
                    Console.WriteLine("Directory = " + dir );
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    using (FileStream fileStream = System.IO.File.Create(filePath + obj.File.FileName))
                    {
                        await obj.File.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();
                        return filePath + obj.File.FileName;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Upload failed";
            }
             
        }
    }
}
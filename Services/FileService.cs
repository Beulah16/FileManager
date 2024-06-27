using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileManager.Interfaces;
using Microsoft.AspNetCore.StaticFiles;

namespace FileManager.Services
{
    public class FileService : IFileService
    {

        public async Task<string> UploadFile(IFormFile file)
        {
            if (file.Length > 0)
            {
                try
                {
                    var provider = new FileExtensionContentTypeProvider();
                    provider.Mappings.Add(".ipynb", "application/x-ipynb+json");
                    
                    if(!provider.TryGetContentType(file.FileName, out var contentType))
                    {
                        return "Not a valid file type";
                    }

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files\\Uploads\\");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    using FileStream fileStream = System.IO.File.Create(filePath + file.FileName);
                    await file.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();
                    return file.FileName;
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
        public Task<byte[]> DownloadFile(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
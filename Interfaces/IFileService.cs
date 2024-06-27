using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FileManager.Interfaces
{
    public interface IFileService
    {
        public Task<string> UploadFile(IFormFile file);
        public Task<byte[]> DownloadFile(string fileName);
    }
}
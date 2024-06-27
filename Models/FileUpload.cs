using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.Models
{
    public class FileData
    {
        public Guid Id { get; set; }
        public IFormFile File { get; set; } = null!;
        public string FileName { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public DateTime UploadedOn { get; set; }
    }
}
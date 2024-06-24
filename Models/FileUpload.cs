using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileManager.Models
{
    public class FileUpload
    {
        public int Id { get; set; }
        public IFormFile File { get; set; } = null!;
        public string Name { get; set; } = string.Empty;
    }
}
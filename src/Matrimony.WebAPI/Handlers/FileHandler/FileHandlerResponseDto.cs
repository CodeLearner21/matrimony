using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matrimony.WebAPI.Handlers.FileHandler
{
    public class FileHandlerResponseDto
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string DirectoryName { get; set; }
        public DateTime DateCreated { get; set; }        
    }
}

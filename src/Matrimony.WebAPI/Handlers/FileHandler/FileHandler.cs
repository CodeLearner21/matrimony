using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.WebAPI.Handlers.FileHandler
{
    public class FileHandler
    {
        private readonly IHostingEnvironment _hostingEnv;
        public FileHandler(IHostingEnvironment hostingEnv)
        {
            _hostingEnv = hostingEnv;
        }
        public async Task<FileHandlerResponseDto> UploadUserFile(IFormFile file, string userName)
        {
            if (file == null || file.Length == 0 || string.IsNullOrWhiteSpace(userName))
                return null;            
            
            try
            {
                var uploadFolder = $"{_hostingEnv.WebRootPath}{Path.DirectorySeparatorChar}media{Path.DirectorySeparatorChar}upload{Path.DirectorySeparatorChar}{MD5Hash(userName)}";
                var userDirectory = Directory.CreateDirectory(uploadFolder);
                var fileExtention = Path.GetExtension(file.FileName);
                var tempfileName = $"{Guid.NewGuid()}{fileExtention}";
                var filePath = Path.Combine(userDirectory.FullName, tempfileName);
                using (var stream = File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }

                FileInfo fi = new FileInfo(filePath);
                if (fi == null)
                    return null;

                return new FileHandlerResponseDto
                {
                    Type = file.ContentType,
                    DateCreated = fi.CreationTime,
                    Name = tempfileName,
                    Title = Path.GetFileNameWithoutExtension(file.FileName),
                    DirectoryName = userDirectory.Name
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string RenameFile(string fileName)
        {
            return fileName.Replace(" ", "-").Replace("'", "-").Replace(".", "-").ToLower();
        }

        private static string MD5Hash(string input)
        {            
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}

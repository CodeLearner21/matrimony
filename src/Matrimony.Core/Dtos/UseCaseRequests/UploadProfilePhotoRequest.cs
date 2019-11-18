using Matrimony.Core.Dtos.UseCaseResponses;
using Matrimony.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.UseCaseRequests
{
    public class UploadProfilePhotoRequest : IUseCaseRequest<UploadProfilePhotoResponse>
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string DirectoryName { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserName { get; set; }

        public UploadProfilePhotoRequest(string type, string title, string name, string directoryName, DateTime dateCreated, string userName)
        {
            Type = type;
            Title = title;
            Name = name;
            DirectoryName = directoryName;
            DateCreated = dateCreated;
            UserName = userName;
        }
    }
}

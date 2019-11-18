using Matrimony.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.UseCaseResponses
{
    public class UploadProfilePhotoResponse : UseCaseResponseMessage
    {
        public string Id { get; set; }
        public IEnumerable<string> Errors { get; }

        public UploadProfilePhotoResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public UploadProfilePhotoResponse(string id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;     
        }
    }
}

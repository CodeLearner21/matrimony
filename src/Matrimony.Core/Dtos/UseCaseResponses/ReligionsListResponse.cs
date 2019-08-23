using Matrimony.Core.Domain.Entities;
using Matrimony.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.UseCaseResponses
{
    public class ReligionsListResponse : UseCaseResponseMessage
    {
        public IEnumerable<ReligionEntity> Religions { get; set; }
        public IEnumerable<string> Errors { get; }

        public ReligionsListResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public ReligionsListResponse(IEnumerable<ReligionEntity> religions, bool success = false, string message = null) : base(success, message)
        {
            Religions = religions;
        }
    }
}

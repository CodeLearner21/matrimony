using Matrimony.Core.Domain.Entities;
using Matrimony.Core.Interfaces;
using System.Collections.Generic;

namespace Matrimony.Core.Dtos.UseCaseResponses
{
    public class GetFilesByPortfolioIdResponse : UseCaseResponseMessage
    {
        public IEnumerable<PortfolioFile> Files { get; set; }
        public IEnumerable<string> Errors { get; }

        public GetFilesByPortfolioIdResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetFilesByPortfolioIdResponse(IEnumerable<PortfolioFile> files, bool success = false, string message = null) : base(success, message)
        {
            Files = files;
        }


    }
}

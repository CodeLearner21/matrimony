using Matrimony.Core.Domain.Entities;
using Matrimony.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.UseCaseResponses
{
    public class GetAllPortfolioTypesResponse : UseCaseResponseMessage
    {
        public IEnumerable<PortfolioTypeDomain> PortfolioTypes { get; set; }
        public IEnumerable<string> Errors { get; }

        public GetAllPortfolioTypesResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public GetAllPortfolioTypesResponse(IEnumerable<PortfolioTypeDomain> portfolioTypes, bool success = false, string message = null) : base(success, message)
        {
            PortfolioTypes = portfolioTypes;
        }
    }
}

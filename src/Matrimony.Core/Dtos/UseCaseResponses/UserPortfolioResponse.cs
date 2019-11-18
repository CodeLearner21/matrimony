using Matrimony.Core.Domain.Entities;
using Matrimony.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.UseCaseResponses
{
    public class UserPortfolioResponse : UseCaseResponseMessage
    {
        public UserPortfolio UserPortfolio { get; set; }
        public IEnumerable<string> Errors { get; }
        public UserPortfolioResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public UserPortfolioResponse(UserPortfolio userPortfolio, bool success = false, string message = null) : base(success, message)
        {
            UserPortfolio = userPortfolio;
        }
    }
}

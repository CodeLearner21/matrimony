﻿using Matrimony.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Dtos.UseCaseResponses
{
    public class CreatePortfolioResponse : UseCaseResponseMessage
    {
        public int Id { get; set; }
        public IEnumerable<string> Errors { get; }

        public CreatePortfolioResponse(IEnumerable<string> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public CreatePortfolioResponse(int id, bool success = false, string message = null) : base(success, message)
        {
            Id = id;
        }
    }
}

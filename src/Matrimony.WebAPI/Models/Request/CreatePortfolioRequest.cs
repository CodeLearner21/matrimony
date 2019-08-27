using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matrimony.WebAPI.Models.Request
{
    public class CreatePortfolioRequest
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string UserId { get; set; }
        public int PortfolioTypeId { get; set; }

    }
}

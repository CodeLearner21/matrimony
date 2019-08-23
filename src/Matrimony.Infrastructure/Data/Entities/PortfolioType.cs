using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Infrastructure.Data.Entities
{
    public class PortfolioType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Portfolio> Portfolios { get; set; }
    }
}

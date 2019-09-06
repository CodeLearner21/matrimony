using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Domain.Entities
{
    public class PortfolioTypeDomain
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PortfolioTypeDomain(string name, int id = 0)
        {
            Id = id;
            Name = name;
        }
    }
}

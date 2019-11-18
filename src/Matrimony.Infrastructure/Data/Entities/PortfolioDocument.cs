using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Matrimony.Infrastructure.Data.Entities
{
    public class PortfolioDocument
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string DirectoryName { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid PortfolioId { get; set; }        
        public Portfolio Portfolio { get; set; }
    }
}

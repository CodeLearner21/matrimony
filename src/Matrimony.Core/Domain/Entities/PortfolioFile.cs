using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Domain.Entities
{
    public class PortfolioFile
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string DirectoryName { get; set; }        
        public DateTime DateCreated { get; set; }
        public string PortfolioId { get; set; }

        public PortfolioFile(string type, string title, string fileName, string directoryName, DateTime dateCreated, string portfolioId, string id = null)
        {
            Id = id;
            Type = type;
            Title = title;
            Name = fileName;
            DirectoryName = directoryName;
            DateCreated = dateCreated;
            PortfolioId = portfolioId;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Infrastructure.Data.Entities
{
    public class SubCaste
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CasteId { get; set; }
        public Caste Caste { get; set; }
    }
}

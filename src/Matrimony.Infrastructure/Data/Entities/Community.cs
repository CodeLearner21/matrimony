using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Infrastructure.Data.Entities
{
    public class Community
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ReligionId { get; set; }
        public Religion Religion { get; set; }

        public IEnumerable<Caste> Castes { get; set; }
    }
}

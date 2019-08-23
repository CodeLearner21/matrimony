using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Infrastructure.Data.Entities
{
    public class Caste
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CommunityId { get; set; }
        public Community Community { get; set; }

        public IEnumerable<SubCaste> SubCastes { get; set; }
    }
}

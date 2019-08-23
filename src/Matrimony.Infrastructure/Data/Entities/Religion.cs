using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Infrastructure.Data.Entities
{
    public class Religion
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Community> Communities { get; set; }
    }
}

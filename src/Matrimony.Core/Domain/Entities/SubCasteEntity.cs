using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Domain.Entities
{
    public class SubCasteEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CasteId { get; set; }
    }
}

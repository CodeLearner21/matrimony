using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Domain.Entities
{
    public class CasteEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CommunityEntityId { get; set; }

        public IEnumerable<SubCasteEntity> SubCastes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Domain.Entities
{
    public class CommunityEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ReligionEntityId { get; set; }

        public IEnumerable<CasteEntity> Castes { get; set; }

        public CommunityEntity(string name, int religionId, int id = 0)
        {
            Id = id;
            Name = name;
            ReligionEntityId = religionId;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Core.Domain.Entities
{
    public class ReligionEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<CommunityEntity> Communities { get; set; }

        public ReligionEntity(string name, IEnumerable<CommunityEntity> communities, int id = 0)
        {
            Id = id;
            Name = name;
            Communities = communities;
        }
    }
}

using Pokemons.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Core.Domain.Entities
{
    public class Region : AuditableBaseEntity
    {
        
        public string Name { get; set; }

        //Collection
        public ICollection<Pokemon> Pokemons { get; set; }
    }
}

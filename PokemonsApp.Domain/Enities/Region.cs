<<<<<<< HEAD
﻿using Pokemons.Core.Domain.Common;
using System;
=======
﻿using System;
>>>>>>> 5b9ee33994f341d7a6339b8ef121b513d12da1d9
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Core.Domain.Entities
{
<<<<<<< HEAD
    public class Region : AuditableBaseEntity
    {
        
=======
    public class Region
    {
        public int Id { get; set; }

>>>>>>> 5b9ee33994f341d7a6339b8ef121b513d12da1d9
        public string Name { get; set; }

        //Collection
        public ICollection<Pokemon> Pokemons { get; set; }
    }
}

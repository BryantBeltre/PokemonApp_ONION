<<<<<<< HEAD
﻿using Pokemons.Core.Domain.Common;
using Pokemons.Core.Domain.Enities;
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
    public class Pokemon : AuditableBaseEntity
    {
        
=======
    public class Pokemon
    {
        public int Id { get; set; }

>>>>>>> 5b9ee33994f341d7a6339b8ef121b513d12da1d9
        public string Name { get; set; }

        public string UrlImg { get; set; }


        public int IdRegion { get; set; }
        public int IdTipo { get; set; }
   


        //Navegation properti
        public Region region { get; set; }
        public Tipo Tipo { get; set; }


<<<<<<< HEAD
        public int UserId { get; set; }
        //Navegation properti

        public User user { get; set; }


=======
>>>>>>> 5b9ee33994f341d7a6339b8ef121b513d12da1d9
    }
}

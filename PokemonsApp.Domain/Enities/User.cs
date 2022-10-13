using Pokemons.Core.Domain.Common;
using Pokemons.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Core.Domain.Enities
{
    public class User : AuditableBaseEntity
    {

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }


        public ICollection<Pokemon> pokemons { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Core.Domain.Entities
{
    public class Tipo
    {
        public int Id { get; set; }

        public string Name { get; set; }


        //collecion
        public ICollection<Pokemon> pokemons { get; set;}

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Core.Application.ViewModel.Pokemones
{
    public class PokemonViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UrlImg { get; set; }

        public int IdRegion { get; set; }
        public string Region { get; set; }
        public int RegionId { get; set; }

        public int IdType { get; set; }
        public string Tipo { get; set; }



    }
}

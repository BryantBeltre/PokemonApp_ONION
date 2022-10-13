using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Core.Application.ViewModel.Pokemones
{
    public class SavePokemon
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "El nombre es un campo obligatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El UrlImg es un campo obligatorio")]
        public string UrlImg { get; set; }

        [Required(ErrorMessage = "La region es un campo obligatorio")]
        public int IdRegion { get; set; }

        [Required(ErrorMessage = "El tipo es un campo obligatorio")]
        public int IdType { get; set; }

    }
}

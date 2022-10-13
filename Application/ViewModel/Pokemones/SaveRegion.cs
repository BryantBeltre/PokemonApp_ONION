using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Core.Application.ViewModel.Pokemones
{
    public class SaveRegion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es un campo obligatorio")]
        public string Name { get; set; }
    }
}

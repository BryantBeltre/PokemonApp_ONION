using Pokemons.Core.Application.ViewModel.Pokemones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Core.Application.Interfaces.Services
{
    public interface IPokemonService
    {
        Task UpdatePokemon(SavePokemon sp);
        
        Task AddPokemon(SavePokemon sp);
        
        Task Delete(int id);

        Task<SavePokemon> GetByIdSavePokemon(int id);

        Task<List<PokemonViewModel>> GetAllViewModel();

    }
}

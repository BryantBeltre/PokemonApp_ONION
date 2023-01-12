using Pokemons.Core.Application.ViewModel.Pokemones;
using Pokemons.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Core.Application.Interfaces.Services
{
    public interface IPokemonService : IGenericService<SavePokemon, PokemonViewModel>
    {
        Task UpdatePokemon(SavePokemon sp);
        
        Task<List<PokemonViewModel>> GetAllViewModelFiltrer(PokemonFiltrerViewModel filtres);
    }
}

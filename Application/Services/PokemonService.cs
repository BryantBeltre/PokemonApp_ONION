using Pokemons.Core.Application.Interfaces;
using Pokemons.Core.Application.Interfaces.Services;
using Pokemons.Core.Application.ViewModel.Pokemones;
using Pokemons.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _PokemonRepository;


        public PokemonService(IPokemonRepository PokemonRepository)
        {
            _PokemonRepository = PokemonRepository;
        }


        public async Task UpdatePokemon(SavePokemon sp)
        {
            Pokemon pokemon = new();
            pokemon.Id = sp.Id;
            pokemon.Name = sp.Name;
            pokemon.UrlImg = sp.UrlImg;
            pokemon.IdRegion = sp.IdRegion;
            pokemon.IdTipo = sp.IdType;

            await _PokemonRepository.UpdateAsync(pokemon);
        }

        public async Task AddPokemon(SavePokemon sp)
        {
            Pokemon pokemon = new();
            pokemon.Name = sp.Name;
            pokemon.UrlImg = sp.UrlImg;
            pokemon.IdRegion = sp.IdRegion;
            pokemon.IdTipo = sp.IdType;

            await _PokemonRepository.AddAsync(pokemon);
        }

        public async Task Delete(int id)
        {
            var pokemon = await _PokemonRepository.GetByIdAsync(id);
            await _PokemonRepository.DeleteAsync(pokemon);

        }

        public async Task<SavePokemon> GetByIdSavePokemon(int id)
        {
            var pokemons = await _PokemonRepository.GetByIdAsync(id);

            SavePokemon sv = new();
            sv.Id = pokemons.Id;
            sv.Name = pokemons.Name;
            sv.UrlImg = pokemons.UrlImg;
            sv.IdRegion = pokemons.IdRegion;
            sv.IdType = pokemons.IdTipo;

            return sv;

        }

        public async Task<List<PokemonViewModel>> GetAllViewModel()
        {
            var pokemonsList = await _PokemonRepository.GetAllAsync();

            return pokemonsList.Select(pokemon => new PokemonViewModel
            {
                Name = pokemon.Name,
                UrlImg = pokemon.UrlImg,
                Id = pokemon.Id,
                IdRegion = pokemon.IdRegion,
                IdType = pokemon.IdTipo


            }).ToList();
        }



    }
}

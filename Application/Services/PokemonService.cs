using Microsoft.AspNetCore.Http;
using Pokemons.Core.Application.Helpers;
using Pokemons.Core.Application.Interfaces;
using Pokemons.Core.Application.Interfaces.Services;
using Pokemons.Core.Application.ViewModel.Pokemones;
using Pokemons.Core.Application.ViewModel.User;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel userViewModel;


        public PokemonService(IPokemonRepository PokemonRepository, IHttpContextAccessor httpContextAccessor)
        {
            _PokemonRepository = PokemonRepository;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }


        public async Task Update(SavePokemon sp)
        {
            Pokemon pokemon = new();
            pokemon.Id = sp.Id;
            pokemon.Name = sp.Name;
            pokemon.UrlImg = sp.UrlImg;
            pokemon.IdRegion = sp.IdRegion;
            pokemon.IdTipo = sp.IdType;

            await _PokemonRepository.UpdateAsync(pokemon);
        }

        public async Task Add(SavePokemon sp)
        {
            Pokemon pokemon = new();
            pokemon.Name = sp.Name;
            pokemon.UrlImg = sp.UrlImg;
            pokemon.IdRegion = sp.IdRegion;
            pokemon.IdTipo = sp.IdType;
            pokemon.UserId = userViewModel.Id;

            await _PokemonRepository.AddAsync(pokemon);
        }

        public async Task Delete(int id)
        {
            var pokemon = await _PokemonRepository.GetByIdAsync(id);
            await _PokemonRepository.DeleteAsync(pokemon);

        }

        public async Task<SavePokemon> GetById(int id)
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
            var pokemonsList = await _PokemonRepository.GetAllAsyncInclude(new List<string> { "region", "Tipo" });

            return pokemonsList.Where(pokemon => pokemon.UserId == userViewModel.Id).Select(pokemon => new PokemonViewModel
            {
                Name = pokemon.Name,
                UrlImg = pokemon.UrlImg,
                Id = pokemon.Id,
                NameRegion = pokemon.region.Name,
                NameType = pokemon.Tipo.Name

            }).ToList();
        }

        public async Task<List<PokemonViewModel>> GetAllViewModelFiltrer(PokemonFiltrerViewModel filtres)
        {
            var pokemonsList = await _PokemonRepository.GetAllAsyncInclude(new List<string> { "region", "Tipo" });

            var pokemonListViewModel= pokemonsList.Where(pokemon => pokemon.UserId == userViewModel.Id).Select(pokemon => new PokemonViewModel
            {
                Name = pokemon.Name,
                UrlImg = pokemon.UrlImg,
                Id = pokemon.Id,
                NameRegion = pokemon.region.Name,
                NameType = pokemon.Tipo.Name

            }).ToList();
            if (filtres.PokemonId != null )
            {
                pokemonListViewModel = pokemonListViewModel.Where(p => p.Id == filtres.PokemonId.Value).ToList();
            }

            return pokemonListViewModel;
        }



    }
}

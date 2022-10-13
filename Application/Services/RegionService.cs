using Microsoft.AspNetCore.Http;
using Pokemons.Core.Application.Helpers;
using Pokemons.Core.Application.Interfaces;
using Pokemons.Core.Application.Interfaces.Repositories;
using Pokemons.Core.Application.Interfaces.Services;
using Pokemons.Core.Application.ViewModel.Pokemones;
using Pokemons.Core.Application.ViewModel.Region;
using Pokemons.Core.Application.ViewModel.User;
using Pokemons.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RegionService : IRegionService
    {

        private readonly IRegionRepository _regionRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel userViewModel;

        public RegionService(IRegionRepository regionRepository, IHttpContextAccessor httpContextAccessor)
        {
            _regionRepository = regionRepository;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }

        public async Task<List<RegionViewModel>> GetAllViewModel()
        {
            var regionlist = await _regionRepository.GetAllAsyncInclude(new List<string> { "Pokemons"});

            return regionlist.Select(region => new RegionViewModel
            {
                Id = region.Id,
                Name = region.Name,
                PokemonQuantity = region.Pokemons.Where(pokemon=> pokemon.UserId == userViewModel.Id).Count()
                
            }).ToList();
        }

        public async Task Update(SaveRegion sr)
        {
            Region region = new();
            region.Id = sr.Id;
            region.Name = sr.Name;

            await _regionRepository.UpdateAsync(region);
        }

        public async Task Add(SaveRegion sr)
        {
            Region region = new();
            region.Id = sr.Id;
            region.Name = sr.Name;
            

            await _regionRepository.AddAsync(region);
        }

        public async Task Delete(int id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            await _regionRepository.DeleteAsync(region);

        }

        public async Task<SaveRegion> GetById(int id)
        {
            var region = await _regionRepository.GetByIdAsync(id);

            SaveRegion sr = new();

            sr.Id = region.Id;
            sr.Name = region.Name;

            return sr;
        } 

    }
}

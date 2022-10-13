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
    public class RegionService : IRegionService
    {

        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<List<RegionViewModel>> GetAllRegioViewModel()
        {
            var regionlist = await _regionRepository.GetAllRegion();

            return regionlist.Select(region => new RegionViewModel
            {
                Id = region.Id,
                Name = region.Name
            }).ToList();
        }

        public async Task UpdateRegion(SaveRegion sr)
        {
            Region region = new();
            region.Id = sr.Id;
            region.Name = sr.Name;

            await _regionRepository.UpdateRegionAsync(region);
        }

        public async Task AddRegion(SaveRegion sr)
        {
            Region region = new();
            region.Id = sr.Id;
            region.Name = sr.Name;

            await _regionRepository.AddRegionAsync(region);
        }

        public async Task DeleteRegion(int id)
        {
            var region = await _regionRepository.GetAsyncRegionCyId(id);
            await _regionRepository.DeleteRegionAsync(region);

        }

        public async Task<SaveRegion> GetRegionById(int id)
        {
            var region = await _regionRepository.GetAsyncRegionCyId(id);

            SaveRegion sr = new();

            sr.Id = region.Id;
            sr.Name = region.Name;

            return sr;
        } 

    }
}

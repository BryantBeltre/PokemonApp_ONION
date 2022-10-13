using Pokemons.Core.Application.ViewModel.Pokemones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Core.Application.Interfaces.Services
{
    public interface IRegionService
    {
        Task<List<RegionViewModel>> GetAllRegioViewModel();

        Task UpdateRegion(SaveRegion sr);

        Task AddRegion(SaveRegion sr);

        Task DeleteRegion(int id);

        Task<SaveRegion> GetRegionById(int id);
    }
}

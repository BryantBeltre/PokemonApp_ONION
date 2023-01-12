using Pokemons.Core.Application.ViewModel.Region;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Core.Application.Interfaces.Services
{
    public interface IRegionService : IGenericService<SaveRegion, RegionViewModel>
    {
        Task<List<RegionViewModel>> GetAllRegioViewModel();

        Task UpdateRegion(SaveRegion sr);

        Task AddRegion(SaveRegion sr);

        Task DeleteRegion(int id);

        Task<SaveRegion> GetRegionById(int id);
    }
}

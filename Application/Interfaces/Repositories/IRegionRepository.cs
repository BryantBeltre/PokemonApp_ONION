using Pokemons.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Core.Application.Interfaces
{
    public interface IRegionRepository
    {
        Task AddRegionAsync(Region region);

        Task UpdateRegionAsync(Region region);

        Task DeleteRegionAsync(Region region);

        Task<List<Region>> GetAllRegion();

        Task<Region> GetAsyncRegionCyId(int id);
    }
}

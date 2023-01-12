using Microsoft.EntityFrameworkCore;
using Pokemons.Core.Application.Interfaces;
using Pokemons.Core.Application.Interfaces.Repositories;
using Pokemons.Core.Domain.Entities;
using Pokemons.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class RegionRepository : GenericRepository<Region>, IRegionRepository
    {
        private readonly ApplicationContext _dbContext;
        
        public RegionRepository(ApplicationContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddRegionAsync(Region region)
        {
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRegionAsync(Region region)
        {
            _dbContext.Entry(region).State = EntityState.Modified; 
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteRegionAsync(Region region)
        {
            _dbContext.Set<Region>().Remove(region);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Region>> GetAllRegion()
        {
            return await _dbContext.Set<Region>().ToListAsync();
        }

        public async Task<Region> GetAsyncRegionCyId(int id)
        {
            return await _dbContext.Set<Region>().FindAsync(id);
        }
    }
}

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

        
    }
}

using Microsoft.EntityFrameworkCore;
using Pokemons.Infrastructure.Persistence.Contexts;
using System;
using Pokemons.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemons.Core.Application.Interfaces;
using Pokemons.Core.Application.Interfaces.Repositories;

namespace Application.Repository
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly ApplicationContext _dbContext;

        public GenericRepository(ApplicationContext dbContext) { 
            
            _dbContext = dbContext;
   
        }

        public virtual async Task AddAsync(Entity entity)
        {
            await _dbContext.Set<Entity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        
        }

        public virtual async Task UpdateAsync(Entity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Entity entity)
        {
            _dbContext.Set<Entity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<List<Entity>> GetAllAsync()
        {
            return await _dbContext.Set<Entity>().ToListAsync();
        }

        public virtual async Task<List<Entity>> GetAllAsyncInclude(List<String> properties)
        {
            var query = _dbContext.Set<Entity>().AsQueryable();
            
            foreach (var property in properties)
            {
                query = query.Include(property);
            }

            return await query.ToListAsync();

        }

        public virtual async Task<Entity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Entity>().FindAsync(id);
        }


    }
}

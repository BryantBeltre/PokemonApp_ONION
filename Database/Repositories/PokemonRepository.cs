using Microsoft.EntityFrameworkCore;
using Pokemons.Infrastructure.Persistence.Contexts;
using System;
using Pokemons.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemons.Core.Application.Interfaces;

namespace Application.Repository
{
    public class PokemonRepository : GenericRepository<Pokemon>, IPokemonRepository
    {
        private readonly ApplicationContext _dbContext;

        public PokemonRepository(ApplicationContext dbContext) : base(dbContext)
        {
            
            _dbContext = dbContext;
   
        }

        public async Task AddAsync(Pokemon pokemons)
        {
            await _dbContext.Pokemon.AddAsync(pokemons);
            await _dbContext.SaveChangesAsync();
        
        }

        public async Task UpdateAsync(Pokemon pokemons)
        {
            _dbContext.Entry(pokemons).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pokemon pokemons)
        {
            _dbContext.Set<Pokemon>().Remove(pokemons);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Pokemon>> GetAllAsync()
        {
            return await _dbContext.Set<Pokemon>().ToListAsync();
        }

        public async Task<Pokemon> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Pokemon>().FindAsync(id);
        }


    }
}

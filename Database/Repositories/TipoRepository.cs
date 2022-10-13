using Microsoft.EntityFrameworkCore;
using Pokemons.Core.Application.Interfaces;
using Pokemons.Core.Domain.Entities;
using Pokemons.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class TipoRepository : ITypeRepository
    {
        private readonly ApplicationContext _DbContext;

        public TipoRepository(ApplicationContext DbContext)
        {
            _DbContext = DbContext;
        }

        public async Task AddTypeAsync(Tipo type)
        {
            await _DbContext.Tipo.AddAsync(type);
            await _DbContext.SaveChangesAsync();
        }

        public async Task UpdateTypeAsync(Tipo type)
        {
            _DbContext.Entry(type).State = EntityState.Modified;
            await _DbContext.SaveChangesAsync();
        } 

        public async Task DeleteTypeAsync(Tipo type)
        {
            _DbContext.Set<Tipo>().Remove(type);
            await _DbContext.SaveChangesAsync();
        }

        public async Task<List<Tipo>> GetAllType()
        {
            return await _DbContext.Set<Tipo>().ToListAsync();
        }

        public async Task<Tipo> GetTypeById(int id)
        {
            return await _DbContext.Set<Tipo>().FindAsync(id);
        }

    }
}

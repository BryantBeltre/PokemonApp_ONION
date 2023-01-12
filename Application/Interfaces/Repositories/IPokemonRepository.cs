using Pokemons.Core.Application.Interfaces.Repositories;
using Pokemons.Core.Domain.Enities;
using Pokemons.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Core.Application.Interfaces
{
    public interface IPokemonRepository : IGenericRepository<Pokemon>
    {
        Task AddAsync(Pokemon pokemons);

        Task UpdateAsync(Pokemon pokemons);

        Task DeleteAsync(Pokemon pokemons);

        Task<List<Pokemon>> GetAllAsync();

        Task<Pokemon> GetByIdAsync(int id);
    }
}

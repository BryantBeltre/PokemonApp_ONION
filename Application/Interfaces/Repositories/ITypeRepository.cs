using Pokemons.Core.Application.Interfaces.Repositories;
using Pokemons.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Core.Application.Interfaces
{
    public interface ITypeRepository : IGenericRepository<Tipo>
    {
        Task AddTypeAsync(Tipo type);

        Task UpdateTypeAsync(Tipo type);

        Task DeleteTypeAsync(Tipo type);

        Task<List<Tipo>> GetAllType();

        Task<Tipo> GetTypeById(int id);

    }
}

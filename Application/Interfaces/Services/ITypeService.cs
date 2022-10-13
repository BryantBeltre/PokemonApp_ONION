using Pokemons.Core.Application.ViewModel.Pokemones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Core.Application.Interfaces.Services
{
    public interface ITypeService
    {
        Task<List<TypeViewModel>> GetAllTypes();

        Task AddType(SaveType st);

        Task UpdateType(SaveType st);

        Task<SaveType> GetTypeById(int id);

        Task DeleteType(int id);
    }
}

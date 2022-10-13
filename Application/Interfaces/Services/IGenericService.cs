using Pokemons.Core.Application.ViewModel.Pokemones;
using Pokemons.Core.Application.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Core.Application.Interfaces.Services
{
    public interface IGenericService<SaveViewModel, ViewModel>
        where SaveViewModel : class
        where ViewModel : class
    {
        Task Update(SaveViewModel sp);

        Task Add(SaveViewModel sp);

        Task Delete(int id);

        Task<SaveViewModel> GetById(int id);

        Task<List<ViewModel>> GetAllViewModel();


    }
       
}

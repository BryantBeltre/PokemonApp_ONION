using Pokemons.Core.Application.ViewModel.Pokemones;
using Pokemons.Core.Application.ViewModel.User;
using Pokemons.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<SaveUser, UserViewModel>
    {
        Task<UserViewModel> Login(LoginViewModel loginView);
    }    
        
}

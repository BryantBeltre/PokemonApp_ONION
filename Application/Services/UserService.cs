using Pokemons.Core.Application.Interfaces;
using Pokemons.Core.Application.Interfaces.Services;
using Pokemons.Core.Application.ViewModel.User;
using Pokemons.Core.Domain.Enities;
using Pokemons.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;


        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Login(LoginViewModel loginView)
        {
            User users = await _userRepository.LoginAsync(loginView);

            if (users == null)
            {
                return null;
            }

            UserViewModel userView = new();
            userView.Id = users.Id;
            userView.Username = users.Username;
            userView.Password = users.Password;
            userView.Name = users.Name;
            userView.Email = users.Email;
            userView.Phone = users.Phone;

            return userView;
        }

        public async Task Update(SaveUser sp)
        {
            User users = new();
            users.Id = sp.Id;
            users.Username = sp.Username;
            users.Password = sp.Password;
            users.Name = sp.Name;
            users.Email = sp.Email;
            users.Phone = sp.Phone;

            await _userRepository.UpdateAsync(users);
        }

        public async Task Add(SaveUser sp)
        {
            User users = new();
            users.Username = sp.Username;
            users.Password = sp.Password;
            users.Name = sp.Name;
            users.Email = sp.Email;
            users.Phone = sp.Phone;

            await _userRepository.AddAsync(users);
        }

        public async Task Delete(int id)
        {
            var users = await _userRepository.GetByIdAsync(id);
            await _userRepository.DeleteAsync(users);

        }

        public async Task<SaveUser> GetById(int id)
        {
            var users = await _userRepository.GetByIdAsync(id);

            SaveUser su = new();
            su.Id = users.Id;
            su.Username = users.Username;
            su.Password = users.Password;
            su.Name = users.Name;
            su.Email =users.Email;
            su.Phone = users.Phone;


            return su;

        }

        public async Task<List<UserViewModel>> GetAllViewModel()
        {
            var userList = await _userRepository.GetAllAsyncInclude(new List<string> { "Pokemon" });

            return userList.Select(user => new UserViewModel
            {
                Username = user.Username,
                Password = user.Password,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone

            }).ToList();
        }

    }
}

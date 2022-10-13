using Microsoft.AspNetCore.Http;
using Pokemons.Core.Application.Helpers;
using Pokemons.Core.Application.Interfaces;
using Pokemons.Core.Application.Interfaces.Services;
using Pokemons.Core.Application.ViewModel.Pokemones;
using Pokemons.Core.Application.ViewModel.Tipo;
using Pokemons.Core.Application.ViewModel.User;
using Pokemons.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository _typeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel userViewModel;

        public TypeService(ITypeRepository typeRepository, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _typeRepository = typeRepository;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }

        public async Task<List<TypeViewModel>> GetAllViewModel()
        {
            var typeList = await _typeRepository.GetAllAsyncInclude(new List<string> { "pokemons" });

            return typeList.Select(type => new TypeViewModel
            {
                Id = type.Id,
                Name = type.Name,
                PokemonQuantity = type.pokemons.Where(pokemon => pokemon.UserId == userViewModel.Id).Count()

            }).ToList();
        }

        public async Task Add(SaveType st)
        {
            Tipo tipo = new();

            tipo.Id = st.Id;
            tipo.Name = st.Name;

            await _typeRepository.AddAsync(tipo);

        }

        public async Task Update(SaveType st)
        {
            Tipo tipo = new();

            tipo.Id = st.Id;
            tipo.Name = st.Name;

            await _typeRepository.UpdateAsync(tipo);

        }

        public async Task<SaveType> GetById(int id)
        {
            var tipo = await _typeRepository.GetByIdAsync(id);

            SaveType save = new();

            save.Id = tipo.Id;
            save.Name = tipo.Name;

            return save;
        }

        public async Task Delete(int id)
        {
            var type = await _typeRepository.GetByIdAsync(id);

            await _typeRepository.DeleteAsync(type);

            
        }

    }
}

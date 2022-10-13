using Pokemons.Core.Application.Interfaces;
using Pokemons.Core.Application.Interfaces.Services;
using Pokemons.Core.Application.ViewModel.Pokemones;
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
        private readonly  ITypeRepository _typeRepository;

        public TypeService(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<List<TypeViewModel>> GetAllTypes()
        {
            var type = await _typeRepository.GetAllType();

            return type.Select(type => new TypeViewModel {
                Id = type.Id,
                Name = type.Name
            }).ToList();
        }

        public async Task AddType(SaveType st)
        {
            Tipo tipo = new();

            tipo.Id = st.Id;
            tipo.Name = st.Name;

            await _typeRepository.AddTypeAsync(tipo);

        }

        public async Task UpdateType(SaveType st)
        {
            Tipo tipo = new();

            tipo.Id = st.Id;
            tipo.Name = st.Name;

            await _typeRepository.UpdateTypeAsync(tipo);

        }

        public async Task<SaveType> GetTypeById(int id)
        {
            var tipo = await _typeRepository.GetTypeById(id);

            SaveType save = new();

            save.Id = tipo.Id;
            save.Name = tipo.Name;

            return save;
        }

        public async Task DeleteType(int id)
        {
            var type = await _typeRepository.GetTypeById(id);

            await _typeRepository.DeleteTypeAsync(type);

            
        }

    }
}

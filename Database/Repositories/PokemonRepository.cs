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
    }
}

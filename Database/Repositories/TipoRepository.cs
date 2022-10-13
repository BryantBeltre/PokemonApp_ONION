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
    public class TipoRepository : GenericRepository<Tipo>, ITypeRepository
    {
        private readonly ApplicationContext _DbContext;

        public TipoRepository(ApplicationContext DbContext) : base(DbContext)
        {
            _DbContext = DbContext;
        }

       
    }
}

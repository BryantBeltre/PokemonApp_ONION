using Application;
using Application.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokemons.Core.Application.Interfaces;
using Pokemons.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Infrastructure.Persistence
{
    //Extension Method - Decorator
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuraction)
        {
            #region Context
            if (configuraction.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuraction.GetConnectionString("DefaultConnetion"), 
                m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName )));
            }
            #endregion

            #region Repositories
            
            #region RepositoryPokemon
            services.AddTransient<IPokemonRepository, PokemonRepository>();
            #endregion

            #region RepositoryType
            services.AddTransient<ITypeRepository, TipoRepository>();
            #endregion

            #region RepositoryRegion
            services.AddTransient<IRegionRepository, RegionRepository>();
            #endregion

            #endregion


        }

    }
}

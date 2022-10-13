using Application;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokemons.Core.Application.Interfaces;
using Pokemons.Core.Application.Interfaces.Services;
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
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuraction)
        {
         
            #region Repositories
            
            #region RepositoryPokemon
            services.AddTransient<IPokemonService, PokemonService>();
            #endregion

            #region RepositoryType
            services.AddTransient<IRegionService, RegionService>();
            #endregion

            #region RepositoryRegion
            services.AddTransient<ITypeService, TypeService>();
            #endregion

            #endregion
             
        }

    }
}

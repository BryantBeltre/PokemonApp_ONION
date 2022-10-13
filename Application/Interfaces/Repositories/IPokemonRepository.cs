﻿using Pokemons.Core.Application.Interfaces.Repositories;
using Pokemons.Core.Domain.Enities;
using Pokemons.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Core.Application.Interfaces
{
    public interface IPokemonRepository : IGenericRepository<Pokemon>
    {
 
    }
}

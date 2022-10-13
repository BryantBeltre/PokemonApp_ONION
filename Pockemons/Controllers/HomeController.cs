using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pockemons.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Pokemons.Infrastructure.Persistence.Contexts;
using Pokemons.Core.Application.Interfaces.Services;

namespace Pockemons.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPokemonService _pokemonServices;

        public HomeController(IPokemonService pokemonServices)
        {
            _pokemonServices = pokemonServices;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pokemonServices.GetAllViewModel());
        }

    }
}

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
using Pokemons.Core.Application.ViewModel.Pokemones;
using WebApp.Pockemons.Middlewares;

namespace Pockemons.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPokemonService _pokemonServices;
        private readonly IRegionService _regionServices;
        private readonly ValidateUserSession _validateUSerSession;

        public HomeController(IPokemonService pokemonServices, IRegionService regionServices, ValidateUserSession validateUSerSession)
        {
            _pokemonServices = pokemonServices;
            _regionServices = regionServices;
            _validateUSerSession = validateUSerSession;


        }

        public async Task<IActionResult> Index(PokemonFiltrerViewModel pfv)
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            ViewBag.Pokemons = await _pokemonServices.GetAllViewModel();
            return View(await _pokemonServices.GetAllViewModelFiltrer(pfv));
        }

    }
}

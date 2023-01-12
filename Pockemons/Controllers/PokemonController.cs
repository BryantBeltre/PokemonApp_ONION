using Application.Services;

using Microsoft.AspNetCore.Mvc;
using Pokemons.Core.Application.Interfaces.Services;
using Pokemons.Core.Application.ViewModel.Pokemones;
using System.Threading.Tasks;
using WebApp.Pockemons.Middlewares;

namespace Pockemons.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokemonService _pokemonServices;
        private readonly IRegionService _regionService;
        private readonly ITypeService _typeService;
        private readonly ValidateUserSession _validateUSerSession;

        public PokemonController(IPokemonService pokemonServices, IRegionService regionService, ITypeService typeService, ValidateUserSession validateUSerSession)
        {
            _pokemonServices = pokemonServices;
            _regionService = regionService;
            _typeService = typeService;
            _validateUSerSession = validateUSerSession;

        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            return View(await _pokemonServices.GetAllViewModel());
        }

        public async Task<IActionResult> Create()
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
        }
            SavePokemon  sp= new();
            sp.Regions = await _regionService.GetAllViewModel();
            sp.Types = await _typeService.GetAllViewModel();
            return View("SavePokemon",sp);
        }

        [HttpPost]
        public async Task <IActionResult> Create(SavePokemon sp)
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                sp.Regions = await _regionService.GetAllViewModel();
                sp.Types = await _typeService.GetAllViewModel();
                return View("SavePokemon",sp);
            }

            await _pokemonServices.Add(sp);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });            
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            SavePokemon sp = await _pokemonServices.GetById(id);
            sp.Regions = await _regionService.GetAllViewModel();
            sp.Types = await _typeService.GetAllViewModel();
            return View("SavePokemon",sp );
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemon sp)
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                sp.Types = await _typeService.GetAllViewModel();
                sp.Regions = await _regionService.GetAllViewModel();
                return View("SavePokemon", sp);
            }

            await _pokemonServices.Update(sp);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            return View(await _pokemonServices.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            await _pokemonServices.Delete(id);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }

    }
}

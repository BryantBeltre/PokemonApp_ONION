using Application.Services;

using Microsoft.AspNetCore.Mvc;
using Pokemons.Core.Application.Interfaces.Services;
using Pokemons.Core.Application.ViewModel.Pokemones;
using System.Threading.Tasks;

namespace Pockemons.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokemonService _pokemonServices;

        public PokemonController(IPokemonService pokemonServices)
        {
            _pokemonServices = pokemonServices;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pokemonServices.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SavePokemon", new SavePokemon());
        }

        [HttpPost]
        public async Task <IActionResult> Create(SavePokemon sp)
        {
            if (!ModelState.IsValid)
            {
                return View("SavePokemon",sp);
            }

            await _pokemonServices.AddPokemon(sp);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });            
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SavePokemon", await _pokemonServices.GetByIdSavePokemon(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemon sp)
        {
            await _pokemonServices.UpdatePokemon(sp);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _pokemonServices.GetByIdSavePokemon(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _pokemonServices.Delete(id);
            return RedirectToRoute(new { controller = "Pokemon", action = "Index" });
        }

    }
}

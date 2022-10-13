using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Pokemons.Core.Application.Interfaces.Services;
using Pokemons.Core.Application.ViewModel.Pokemones;
using Pokemons.Core.Application.ViewModel.Region;
using System.Threading.Tasks;
using WebApp.Pockemons.Middlewares;

namespace Pockemons.Controllers
{
    public class RegionController : Controller
    {

        private readonly IRegionService _regionService;
        private readonly ValidateUserSession _validateUSerSession;

        public RegionController(IRegionService regionService, ValidateUserSession validateUSerSession)
        {
            _regionService = regionService;
            _validateUSerSession = validateUSerSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            return View(await _regionService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            return View("SaveRegion", new SaveRegion());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveRegion sr)
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", sr);
            }

            await _regionService.Add(sr);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            return View("SaveRegion", await _regionService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveRegion sr)
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            await _regionService.Update(sr);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            return View(await _regionService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            await _regionService.Delete(id);
            return RedirectToRoute(new { controller = "Region", action = "Index" });

        }

        


    }
}
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Pokemons.Core.Application.Interfaces.Services;
using Pokemons.Core.Application.ViewModel.Pokemones;
using System.Threading.Tasks;

namespace Pockemons.Controllers
{
    public class RegionController : Controller
    {

        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _regionService.GetAllRegioViewModel());
        }

        public IActionResult Create()
        {
            return View("SaveRegion", new SaveRegion());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveRegion sr)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", sr);
            }

            await _regionService.AddRegion(sr);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveRegion", await _regionService.GetRegionById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveRegion sr)
        {
            await _regionService.UpdateRegion(sr);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _regionService.GetRegionById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _regionService.DeleteRegion(id);
            return RedirectToRoute(new { controller = "Region", action = "Index" });

        }

        


    }
}
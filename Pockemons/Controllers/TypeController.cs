using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Pokemons.Core.Application.Interfaces.Services;
using Pokemons.Core.Application.ViewModel.Pokemones;
using Pokemons.Core.Application.ViewModel.Tipo;
using System.Threading.Tasks;
using WebApp.Pockemons.Middlewares;

namespace Pockemons.Controllers
{
    public class TypeController : Controller
    {

        private readonly ITypeService _typeservice;
        private readonly ValidateUserSession _validateUSerSession;

        public TypeController(ITypeService typeservice, ValidateUserSession validateUSerSession)
        {
            _validateUSerSession = validateUSerSession;
            _typeservice = typeservice;


        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            return View(await _typeservice.GetAllViewModel()) ;
        }

        public IActionResult Create()
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            return View("SaveType", new SaveType());

        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveType st)
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View("SaveType", st);
            }

            await _typeservice.Add(st);

            return RedirectToRoute(new {controller="Type", action="Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
        }
            return View("SaveType", await _typeservice.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveType st)
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            await _typeservice.Update(st);
            return RedirectToRoute(new {controller ="Type", action="Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            return View(await _typeservice.GetById(id));
                   
        }

        [HttpPost]
        public async Task<IActionResult> DeleteC(int id)
        {
            if (!_validateUSerSession.HasUser())
        {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            await _typeservice.Delete(id);
            return RedirectToRoute(new { controller = "Type", action = "Index" });
        }



    }
}

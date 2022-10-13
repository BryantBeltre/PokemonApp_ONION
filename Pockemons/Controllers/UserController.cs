using Microsoft.AspNetCore.Mvc;
using Pokemons.Core.Application.Helpers;
using Pokemons.Core.Application.Interfaces.Services;
using Pokemons.Core.Application.ViewModel.User;
using System.Threading.Tasks;
using WebApp.Pockemons.Middlewares;

namespace Pockemons.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ValidateUserSession _validateUSerSession;

        public UserController(IUserService userService, ValidateUserSession validateUSerSession)
        {
            _userService = userService;
            _validateUSerSession = validateUSerSession;
        }

        public async Task<IActionResult> Index()
        {
            if (_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel lv)
        {
            if (_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View(lv);

            }
            UserViewModel userViewModel = await _userService.Login(lv);
            if (userViewModel !=null)
            {
                HttpContext.Session.Set<UserViewModel>("user", userViewModel);
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                ModelState.AddModelError("userValidation", "Datos de acceso incorrecto"); 
            }

            return View(lv );
        }

        public IActionResult Register()
        {
            if (_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View(new SaveUser());
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new {controller = "User", action="Index" });
        }

        [HttpPost]
        public async Task <IActionResult> Register(SaveUser su)
        {
            if (_validateUSerSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View(su);

            }
            await _userService.Add(su);
            return RedirectToRoute(new { controller = "User", action = "Index" }); 
        }



    }
}

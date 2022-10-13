using Microsoft.AspNetCore.Http;
using Pokemons.Core.Application.Helpers;
using Pokemons.Core.Application.ViewModel.User;

namespace WebApp.Pockemons.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool HasUser()
        {
            UserViewModel userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
            if (userViewModel == null)
            {
                return false;
            }

            return true;


        }
    }
}

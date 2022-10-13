using Pokemons.Core.Application.ViewModel.Region;
using Pokemons.Core.Application.ViewModel.Tipo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Core.Application.ViewModel.User
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Es necesario crear su nombre de usuario")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Debe colocar una contraseña contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}

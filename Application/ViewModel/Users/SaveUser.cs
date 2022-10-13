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
    public class SaveUser
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Es necesario crear su nombre de usuario")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Cree una contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof (Password), ErrorMessage= "Contraseña diferente, intentelo otra vez")]
        [Required(ErrorMessage = "Debe confirmar su contraseña")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Es obligatorio colacar su nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Es obligatorio colacar su correo")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Es obligatorio colacar su telefono")]
        [DataType(DataType.Text)]
        public string Phone { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons.Core.Domain.Entities
{
    public class Pokemon
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UrlImg { get; set; }


        public int IdRegion { get; set; }
        public int IdTipo { get; set; }
   


        //Navegation properti
        public Region region { get; set; }
        public Tipo Tipo { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Genero
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public ICollection<Pelicula> Pelicula { get; set; }
        public ICollection<Serie> Serie { get; set; }
    }
}

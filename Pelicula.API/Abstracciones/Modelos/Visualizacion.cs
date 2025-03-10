using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Visualizacion
    {
        public int Id { get; set; }
        public int IdPelicula { get; set; }
        public Pelicula Pelicula { get; set; }
        public int IdSerie { get; set; }
        public Serie Serie { get; set; }
    }
}

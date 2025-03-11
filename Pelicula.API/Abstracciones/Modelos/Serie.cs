using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Serie
    {
        public string Titulo { get; set; } = string.Empty;
        public string ImagenUrl { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaEstreno { get; set; } = DateTime.MinValue;
        public double Calificacion { get; set; } = 0.0;
    }
}

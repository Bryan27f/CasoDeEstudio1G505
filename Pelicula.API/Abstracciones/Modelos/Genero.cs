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
        public int id { get; set; }
        public string name { get; set; }
    }

    public class GeneroResponse
    {
        public List<Genero> generos { get; set; }
    }
}
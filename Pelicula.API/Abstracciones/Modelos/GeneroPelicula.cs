using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class GeneroPelicula
    {


        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class GeneroPeliculaResponse
    {
        [JsonPropertyName("genres")]
        public List<GeneroPelicula> Generos { get; set; }
    }
}
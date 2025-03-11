using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Modelos;

namespace Servicios
{
    public class SerieService
    {
        public async Task<IEnumerable<Serie>> GetSeriesPorGenero(string genero)
        {
            var series = new List<Serie>
           {
               new Serie { Titulo = "Breaking Bad", ImagenUrl = "https://image.tmdb.org/breakingbad.jpg", Descripcion = "Un profesor de química se convierte en narcotraficante.", FechaEstreno = new DateTime(2008, 1, 20), Calificacion = 9.5 },
               new Serie { Titulo = "Better Call Saul", ImagenUrl = "https://image.tmdb.org/bettercallsaul.jpg", Descripcion = "Historia de un abogado en su camino al crimen.", FechaEstreno = new DateTime(2015, 2, 8), Calificacion = 8.9 }
           };
            return await Task.FromResult(series);
        }
    }
}

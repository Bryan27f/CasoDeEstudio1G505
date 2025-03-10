using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
namespace Reglas
{
    public class GeneroPeliculaReglas : IGeneroPeliculasReglas
    {
        private readonly IGeneroPeliculaServicio _generoPeliculaServicio;
        private readonly IConfiguracion _configuracion;

        public GeneroPeliculaReglas(IGeneroPeliculaServicio generoPeliculaServicio, IConfiguracion configuracion)
        {
            _generoPeliculaServicio = generoPeliculaServicio;
            _configuracion = configuracion;
        }

        public async Task<List<GeneroPelicula>> ObtenerGeneros()
        {
            return await _generoPeliculaServicio.ObtenerGeneros();
        }
    }
}
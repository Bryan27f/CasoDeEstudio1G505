using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
namespace Reglas
{
    public class GeneroReglas : IGeneroReglas
    {
        private readonly IGeneroServicio _generoServicio;
        private readonly IConfiguracion _configuracion;

        public GeneroReglas(IGeneroServicio generoServicio, IConfiguracion configuracion)
        {
            _generoServicio = generoServicio;
            _configuracion = configuracion;
        }

        public async Task<List<Genero>> ObtenerGeneros()
        {
            return await _generoServicio.ObtenerGeneros();
        }
    }
}
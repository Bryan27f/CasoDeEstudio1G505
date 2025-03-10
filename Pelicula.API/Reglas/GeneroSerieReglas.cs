using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
namespace Reglas
{
    public class GeneroSerieReglas : IGeneroSeriesReglas
    {
        private readonly IGeneroSerieServicio _generoSerieServicio;
        private readonly IConfiguracion _configuracion;

        public GeneroSerieReglas(IGeneroSerieServicio generoSerieServicio, IConfiguracion configuracion)
        {
            _generoSerieServicio = generoSerieServicio;
            _configuracion = configuracion;
        }

        public async Task<List<GeneroSerie>> ObtenerGeneros()
        {
            return await _generoSerieServicio.ObtenerGeneros();
        }
    }
}
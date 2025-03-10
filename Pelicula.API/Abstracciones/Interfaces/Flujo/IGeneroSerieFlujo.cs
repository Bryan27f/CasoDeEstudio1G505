using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IGeneroSerieFlujo
    {
        Task<IEnumerable<GeneroSerieResponse>> Obtener();
        
    }
}

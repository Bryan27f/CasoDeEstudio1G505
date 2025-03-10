using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IGeneroFlujo
    {
        Task<IEnumerable<GeneroResponse>> Obtener();
        
    }
}

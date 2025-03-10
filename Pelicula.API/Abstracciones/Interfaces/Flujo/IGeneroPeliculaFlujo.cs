using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.Flujo
{
    public interface IGeneroPeliculaFlujo
    {
        Task<IEnumerable<GeneroPeliculaResponse>> Obtener();
        
    }
}

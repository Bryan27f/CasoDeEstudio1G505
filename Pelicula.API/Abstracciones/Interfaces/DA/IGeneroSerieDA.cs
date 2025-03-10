using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IGeneroSerieDA
    {
        Task<IEnumerable<GeneroSerieResponse>> Obtener();
    }
}

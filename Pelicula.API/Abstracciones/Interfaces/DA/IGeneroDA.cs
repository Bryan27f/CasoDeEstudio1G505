using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IGeneroDA
    {
        Task<IEnumerable<GeneroResponse>> Obtener();
    }
}

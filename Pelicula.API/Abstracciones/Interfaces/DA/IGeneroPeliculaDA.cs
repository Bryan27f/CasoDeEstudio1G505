using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.DA
{
    public interface IGeneroPeliculaDA
    {
        Task<IEnumerable<GeneroPeliculaResponse>> Obtener();
    }
}

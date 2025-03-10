using Abstracciones.Modelos;

namespace Interfaces.DA
{
    public interface IRepositorioPelicula
    {
        Task<IEnumerable<Pelicula>> GetMoviesByGenreAsync(int IdGenero);
    }
}

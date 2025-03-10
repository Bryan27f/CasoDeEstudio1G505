using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Modelos
{
    public class PeliculaRepository : IRepositorioPelicula
    {
        private readonly ApplicationDbContext _context;

        public PeliculaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int IdGenero)
        {
            return await _context.Pelicula
                .Where(m => m.IdGenero == IdGenero)
                .ToListAsync();
        }
    }

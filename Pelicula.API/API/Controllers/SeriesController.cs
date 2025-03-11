using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Servicios;

namespace API.Controllers
{
    [Route("api/[controller]")]
[ApiController]
public class SeriesController : ControllerBase
{
    private readonly TMDBService _tmdbService;

    public SeriesController(TMDBService tmdbService)
    {
        _tmdbService = tmdbService;
    }

    // Endpoint para obtener todos los géneros
    [HttpGet("genres")]
    public async Task<IActionResult> GetGenres()
    {
        try
        {
            var genres = await _tmdbService.GetGenresAsync();
            return Ok(genres);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // Endpoint para obtener series por género
    [HttpGet("series/{genreId}")]
    public async Task<IActionResult> GetSeriesByGenre(string genreId)
    {
        try
        {
            var series = await _tmdbService.GetSeriesByGenreAsync(genreId);
            return Ok(series);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

}

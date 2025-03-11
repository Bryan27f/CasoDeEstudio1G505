using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Servicios;

namespace API.Controllers
{
    [ApiController]
    [Route("api/series")]
    public class SerieController : ControllerBase
    {
        private readonly SerieService _serieService = new SerieService();
        [HttpGet("{genero}")]
        public async Task<IActionResult> GetSeriesPorGenero(string genero)
        {
            var series = await _serieService.GetSeriesPorGenero(genero);
            return Ok(series);
        }
    }
}

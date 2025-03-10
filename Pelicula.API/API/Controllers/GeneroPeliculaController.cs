using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstracciones.Modelos;
using Abstracciones.Interfaces.Servicios;


[Route("api/[controller]")]
[ApiController]
public class GeneroPeliculaController : ControllerBase
{
    private readonly IGeneroPeliculaServicio _generoServicio;

    public GeneroPeliculaController(IGeneroPeliculaServicio generoServicio)
    {
        _generoServicio = generoServicio;
    }

    [HttpGet("ObtenerGenerosDePeliculas")]
    public async Task<IActionResult> ObtenerGeneros()
    {
        var generos = await _generoServicio.ObtenerGeneros();
        return Ok(generos);
    }
}

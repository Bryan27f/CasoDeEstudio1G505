using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstracciones.Modelos;
using Abstracciones.Interfaces.Servicios;


[Route("api/[controller]")]
[ApiController]
public class GeneroSerieController : ControllerBase
{
    private readonly IGeneroSerieServicio _generoServicio;

    public GeneroSerieController(IGeneroSerieServicio generoServicio)
    {
        _generoServicio = generoServicio;
    }

    [HttpGet("ObtenerGenerosDeSeries")]
    public async Task<IActionResult> ObtenerGeneros()
    {
        var generos = await _generoServicio.ObtenerGeneros();
        return Ok(generos);
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstracciones.Modelos;
using Abstracciones.Interfaces.Servicios;


[Route("api/[controller]")]
[ApiController]
public class GeneroController : ControllerBase
{
    private readonly IGeneroServicio _generoServicio;

    public GeneroController(IGeneroServicio generoServicio)
    {
        _generoServicio = generoServicio;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerGeneros()
    {
        var generos = await _generoServicio.ObtenerGeneros();
        return Ok(generos);
    }
}

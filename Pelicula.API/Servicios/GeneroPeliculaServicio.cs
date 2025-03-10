using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using System.Text.Json;


public class GeneroPeliculaServicio : IGeneroPeliculaServicio
{
    private readonly IConfiguracion _configuracion;
    private readonly IHttpClientFactory _httpClient;

    public GeneroPeliculaServicio(IConfiguracion configuracion, IHttpClientFactory httpClient)
    {
        _configuracion = configuracion;
        _httpClient = httpClient;
    }

    public async Task<List<GeneroPelicula>> ObtenerGeneros()
    {
        var endpoint = _configuracion.ObtenerMetodo("ApiEndPointsGenero", "ObtenerGeneros");
        var servicioGenero = _httpClient.CreateClient("ServicioGenero");

        var token = _configuracion.ObtenerValor("AuthToken");
        servicioGenero.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        var respuesta = await servicioGenero.GetAsync(endpoint);

        if (!respuesta.IsSuccessStatusCode)
        {
            Console.WriteLine($"Error en la respuesta HTTP: {respuesta.StatusCode}");
            return new List<GeneroPelicula>();
        }

        var resultado = await respuesta.Content.ReadAsStringAsync();
        Console.WriteLine("Contenido de la respuesta: " + resultado);

        if (string.IsNullOrWhiteSpace(resultado))
        {
            Console.WriteLine("La respuesta de la API está vacía.");
            return new List<GeneroPelicula>();
        }

        var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var resultadoDeserializado = JsonSerializer.Deserialize<GeneroPeliculaResponse>(resultado, opciones);

        if (resultadoDeserializado?.Generos == null || resultadoDeserializado.Generos.Count == 0)
        {
            Console.WriteLine("La API devolvió una lista vacía de géneros.");
            return new List<GeneroPelicula>();
        }

        return resultadoDeserializado.Generos;
    }
} 
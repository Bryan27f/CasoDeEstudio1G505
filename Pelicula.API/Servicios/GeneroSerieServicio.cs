using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using System.Text.Json;


public class GeneroSerieServicio : IGeneroSerieServicio
{
    private readonly IConfiguracion _configuracion;
    private readonly IHttpClientFactory _httpClient;

    public GeneroSerieServicio(IConfiguracion configuracion, IHttpClientFactory httpClient)
    {
        _configuracion = configuracion;
        _httpClient = httpClient;
    }

    public async Task<List<GeneroSerie>> ObtenerGeneros()
    {
        var endpoint = _configuracion.ObtenerMetodo("ApiEndPointsGenero", "ObtenerGeneros");
        var servicioGenero = _httpClient.CreateClient("ServicioGenero");

        var token = _configuracion.ObtenerValor("AuthToken");
        servicioGenero.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        var respuesta = await servicioGenero.GetAsync(endpoint);

        if (!respuesta.IsSuccessStatusCode)
        {
            Console.WriteLine($"Error en la respuesta HTTP: {respuesta.StatusCode}");
            return new List<GeneroSerie>();
        }

        var resultado = await respuesta.Content.ReadAsStringAsync();
        Console.WriteLine("Contenido de la respuesta: " + resultado);

        if (string.IsNullOrWhiteSpace(resultado))
        {
            Console.WriteLine("La respuesta de la API está vacía.");
            return new List<GeneroSerie>();
        }

        var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var resultadoDeserializado = JsonSerializer.Deserialize<GeneroSerieResponse>(resultado, opciones);

        if (resultadoDeserializado?.Generos == null || resultadoDeserializado.Generos.Count == 0)
        {
            Console.WriteLine("La API devolvió una lista vacía de géneros.");
            return new List<GeneroSerie>();
        }

        return resultadoDeserializado.Generos;
    }
} 
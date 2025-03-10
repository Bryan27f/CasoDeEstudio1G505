using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using System.Text.Json;


public class GeneroServicio : IGeneroServicio
{
    private readonly IConfiguracion _configuracion;
    private readonly IHttpClientFactory _httpClient;

    public GeneroServicio(IConfiguracion configuracion, IHttpClientFactory httpClient)
    {
        _configuracion = configuracion;
        _httpClient = httpClient;
    }

    public async Task<List<Genero>> ObtenerGeneros()
    {
        var endpoint = _configuracion.ObtenerMetodo("ApiEndPointsGenero", "ObtenerGeneros");
        var servicioGenero = _httpClient.CreateClient("ServicioGenero");

        var token = _configuracion.ObtenerValor("AuthToken");
        servicioGenero.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        var respuesta = await servicioGenero.GetAsync(endpoint);
        respuesta.EnsureSuccessStatusCode();
        var resultado = await respuesta.Content.ReadAsStringAsync();

        Console.WriteLine("Contenido de la respuesta: " + resultado);

        var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        try
        {
            var resultadoDeserializado = JsonSerializer.Deserialize<GeneroResponse>(resultado, opciones);

            if (resultadoDeserializado == null || resultadoDeserializado.generos == null)
            {
                Console.WriteLine("La respuesta deserializada es nula o no contiene generos.");
                return new List<Genero>();
            }

            return resultadoDeserializado.generos;
        }
        catch (JsonException ex)
        {
            Console.WriteLine("Error de deserialización: " + ex.Message);
            return new List<Genero>();
        }
    }
}
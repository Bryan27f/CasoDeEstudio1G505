using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Abstracciones.Modelos;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using System.Net.Http.Headers;


public class GeneroServicio : IGeneroServicio
{
    private readonly IConfiguracion _configuracion;
    private readonly IHttpClientFactory _httpClientFactory;

    public GeneroServicio(IConfiguracion configuracion, IHttpClientFactory httpClientFactory)
    {
        _configuracion = configuracion;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<Genero>> ObtenerGeneros()
    {
        // Verificamos que la configuración está bien cargada
        var urlBase = _configuracion.ObtenerMetodo("ApiEndPointsGenero", "UrlBase") ?? "";
        var metodo = _configuracion.ObtenerMetodo("ApiEndPointsGenero", "ObtenerGeneros") ?? "";

        Console.WriteLine($"URL Base: {urlBase}");
        Console.WriteLine($"Método: {metodo}");

        if (string.IsNullOrWhiteSpace(urlBase) || string.IsNullOrWhiteSpace(metodo))
        {
            throw new Exception("Error: La URL base o el método no están configurados correctamente.");
        }

        var client = _httpClientFactory.CreateClient("ServicioGenero");

        // Agregamos el token al Header
        var token = _configuracion.ObtenerMetodo("Token", "Bearer");
        if (!string.IsNullOrEmpty(token))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        var urlCompleta = $"{urlBase}/{metodo}";
        Console.WriteLine($"Realizando solicitud a: {urlCompleta}");

        var response = await client.GetAsync(urlCompleta);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Genero>>(content) ?? new List<Genero>();
    }
}
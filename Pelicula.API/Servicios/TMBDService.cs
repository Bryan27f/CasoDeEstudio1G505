using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Abstracciones.Modelos; // Import the namespace for Serie class

namespace Servicios
{
    public class TMDBService
    {
        private readonly string apiKey = "1cb8e4016616cc8be86f315d35405e05";
        private readonly string baseUrl = "https://api.themoviedb.org/3/";
        private readonly RestClient _client;

        public TMDBService()
        {
            _client = new RestClient(baseUrl);
        }

        // Método para obtener todos los géneros
        public async Task<List<Genero>> GetGenresAsync()
        {
            var request = new RestRequest("genre/movie/list");
            request.AddQueryParameter("api_key", apiKey);
            request.AddQueryParameter("language", "es-ES");

            var response = await _client.GetAsync(request);

            if (response.IsSuccessful && response.Content != null)
            {
                var genresResponse = JsonConvert.DeserializeObject<GenreResponse>(response.Content);
                return genresResponse.Genres;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }

        // Método para obtener las series por género
        public async Task<List<Serie>> GetSeriesByGenreAsync(int genreId)
        {
            var request = new RestRequest("discover/movie");
            request.AddQueryParameter("api_key", apiKey);
            request.AddQueryParameter("with_genres", genreId.ToString());
            request.AddQueryParameter("language", "es-ES");

            var response = await _client.GetAsync(request);

            if (response.IsSuccessful && response.Content != null)
            {
                var seriesResponse = JsonConvert.DeserializeObject<SeriesResponse>(response.Content);
                var seriesList = new List<Serie>();
                foreach (var serieDto in seriesResponse.Results)
                {
                    seriesList.Add(new Serie
                    {
                        Titulo = serieDto.Name,
                        Descripcion = serieDto.Overview,
                        FechaEstreno = DateTime.Parse(serieDto.FirstAirDate),
                        Calificacion = serieDto.VoteAverage
                    });
                }
                return seriesList;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }
    }

    public class GenreResponse
    {
        public List<Genero> Genres { get; set; }
    }

    public class SeriesResponse
    {
        public List<SerieDTO> Results { get; set; }
    }

    public class SerieDTO
    {
        public string Name { get; set; }
        public string Overview { get; set; }
        public string FirstAirDate { get; set; }
        public double VoteAverage { get; set; }
    }
    public class Genero
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
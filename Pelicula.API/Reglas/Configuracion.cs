﻿using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Abstracciones.Modelos.Servicios;
using Microsoft.Extensions.Configuration;

namespace Reglas
{
    public class Configuracion : IConfiguracion
    {
        private readonly IConfiguration _configuration;

        public Configuracion(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ObtenerMetodo(string seccion, string nombre)
        {
            string? UrlBase = ObtenerUrlBase(seccion);
            var Metodo = _configuration.GetSection(seccion).Get<APIEndPoint>().Metodos.Where(x => x.Nombre == nombre).FirstOrDefault().Valor;
            return $"{UrlBase}/{Metodo}";
        }

        private string? ObtenerUrlBase(string seccion)
        {
            return _configuration.GetSection(seccion).Get<APIEndPoint>().UrlBase;
        }

        public string ObtenerValor(string llave)
        {
            return _configuration.GetSection(llave).Value;
        }

    }
}
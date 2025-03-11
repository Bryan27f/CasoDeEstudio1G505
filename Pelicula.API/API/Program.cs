using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Reglas;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();


// Registrar HttpClient y GeneroServicio
builder.Services.AddHttpClient("ServicioGenero", client =>
{
    client.BaseAddress = new Uri("https://api.themoviedb.org/3/"); // <- URL base
}); 
builder.Services.AddSingleton<IConfiguracion, Configuracion>();

// Asegurarse de que GeneroServicio implementa IGeneroServicio
builder.Services.AddScoped<IGeneroPeliculasReglas, GeneroPeliculaReglas>();
builder.Services.AddScoped<IGeneroPeliculaServicio, GeneroPeliculaServicio>();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();



builder.Services.AddControllers(); // Habilitamos los controladores
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); // Mapeamos los controladores
app.Run();
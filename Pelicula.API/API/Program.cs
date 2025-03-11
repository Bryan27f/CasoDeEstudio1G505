using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Reglas;
using Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
builder.Services.AddScoped<IGeneroReglas, GeneroReglas>();
builder.Services.AddScoped<IGeneroServicio, GeneroServicio>();

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

builder.Services.AddScoped<TMDBService>();
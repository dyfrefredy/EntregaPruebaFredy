using AutoMapper;
using Business.Classes;
using Business.Interfaces;
using Common.Automapper;
using Data.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Crea una variable con la cadena de conexi�n
var con = builder.Configuration.GetConnectionString("AppConnection");
// Construye el contexto
builder.Services.AddDbContext<bd_prueba_fredyContext>(x => x.UseSqlServer(con));
// Configuraci�n de las interfaces para que los controladores las puedan usar
builder.Services.AddScoped<IUsuarioBusiness, UsuarioBusiness>();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperModelToDto());
    mc.AddProfile(new MapperDtoToModel());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Agrega configuraci�n CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();

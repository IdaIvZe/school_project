using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using School.Application.InterfacesService;
using School.Application.Mappings;
using School.Application.Services;
using School.Domain.Interfaces;
using School.Infrastructure.Persistence.Repository;
//coneccion base de datos 
using Microsoft.EntityFrameworkCore;
using School.Infrastructure.Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddAutoMapper(typeof(AnyType));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IPersonaService, PersonaService>();

// 1. Extraer la cadena de conexión del archivo appsettings.json
var connectionString = builder.Configuration.GetConnectionString("SupabaseConnection");

builder.Services.AddDbContext<LocalDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("LocalConnection")));

// 2. Registrar el DbContext en el contenedor de servicios
builder.Services.AddDbContext<RemoteDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//Se usa de esta manera si no se tiene un interfaz para el servicio
//builder.Services.AddScoped<PersonaService>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

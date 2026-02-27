using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using School.Application.InterfacesService;
using School.Infrastructure.Service;

using School.Application.Mappings;
//using School.Infrastructure.MappingsRepository;
using School.Application.Services;
using School.Domain.Interfaces;
using School.Infrastructure.Persistence.Repository;
using School.Infrastructure.Persistence.Data;
using School.Infrastructure.Sync;
using School.Api.ExtensionsTest;

//coneccion base de datos 
using Microsoft.EntityFrameworkCore;
using School.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

//Connection a la base de datos 
builder.Services.AddDbContext<LocalDbContext>( options => options.UseNpgsql(builder.Configuration.GetConnectionString("LocalConnection")));
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DataBaseConnectionService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
//builder.Services.AddAutoMapper(typeof(MappingProfileRepository));
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IPersonaService, PersonaService>();
builder.Services.AddScoped<IDataBaseConnectionTester, DataBaseConnectionTester>();
builder.Services.AddScoped(typeof(SyncRepository<>));

// 1. Extraer la cadena de conexión del archivo appsettings.json

//builder.Services.AddDbContext<LocalDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("LocalConnection")));

var connectionString = builder.Configuration.GetConnectionString("supabaseConnection");
// 2. Registrar el DbContext en el contenedor de servicios
builder.Services.AddDbContext<RemoteDbContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

await app.TestDataBaseAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Se usa de esta manera si no se tiene un interfaz para el servicio
//builder.Services.AddScoped<PersonaService>();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

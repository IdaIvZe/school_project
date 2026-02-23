using School.Application.Services;
using School.Domain;
using School.Domain.Entities;
using School.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace School.Infrastructure.Persistence.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        public PersonaRepository() { }

       // string _fileDataPersona = "School.Infrastructure\\Persistence\\Data\\DataPersona.json";

       string _fileDataPersona = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..",
                                        "School.Infrastructure", "Persistence", "Data", "DataPersona.json");
       
        public async Task<Persona> crearPersona(Persona persona)
        {
            try
            {

                List<Persona> personas;
                var respuesta = new Respuesta<Persona>();
                
                 Console.WriteLine(_fileDataPersona);
                //////////////////////////////
                if (persona != null)
                {
                    if (File.Exists($" aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa{_fileDataPersona}"))
                    {
                        string leerJson = await File.ReadAllTextAsync(_fileDataPersona);
                        personas = JsonSerializer.Deserialize<List<Persona>>(leerJson) ?? new List<Persona>();
                    }
                    else
                    {
                        personas = new List<Persona>();
                    }

                    personas.Add(persona);

                    string actualizarJson = JsonSerializer.Serialize(personas, new JsonSerializerOptions { WriteIndented = true } );

                    await File.WriteAllTextAsync(_fileDataPersona, actualizarJson);

                    return persona;
                }
                /////////////////////////////

                throw new ArgumentNullException(nameof(persona), "El registro no puede instanciarce vacio");
               
                

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"No se pudo crear la persona, error tipo: {ex}");
                
            }

        }





        public async Task<List<Persona>> obtenerPersonasPorRol(string rol)
        {
            try
            {

                List<Persona> personasRol;

                if (File.Exists(_fileDataPersona))
                {
                    string leerJson = await File.ReadAllTextAsync(_fileDataPersona);

                    personasRol = JsonSerializer.Deserialize<List<Persona>>(leerJson) ?? new List<Persona>();



                    List<Persona> personasRolesEspecificos = personasRol.FindAll(persona => persona.rol == rol);

                    return personasRolesEspecificos;
                }

                throw new ArgumentNullException($"Error de coneccion con archivo de datos");

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Fallo al momento de obtener usuarios con rol especifico; error tipo: {ex}");
            }
          
        }



        public async Task<Persona> validarCredenciales(string password, string username)
        {
            try
            {

                if (File.Exists(_fileDataPersona))
                {

                    string leerJson = await File.ReadAllTextAsync(_fileDataPersona);

                    var usuarios = JsonSerializer.Deserialize<List<Persona>>(leerJson) ?? new List<Persona>();

                    Persona existeUsuario = usuarios.Single(usuario => usuario.password == password);


                    if ((existeUsuario != null) && (existeUsuario.password == password))
                    {

                        return existeUsuario;

                    }

                    throw new ArgumentNullException(nameof(username), "Credenciales no validas usuario no encontrado o contraseña incorrecta");

                }

                throw new ArgumentNullException($"Error de coneccion con archivo de datos");
            }
            catch(Exception ex)
            {

                throw new InvalidDataException($"El password o usario incorrectos o no encontrado; error tipo: {ex}");
               
            }

        }
    
      
    }
}

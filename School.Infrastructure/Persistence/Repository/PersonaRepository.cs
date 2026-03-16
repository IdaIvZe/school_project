using School.Application.Services;
using School.Domain;
using School.Domain.Entities;
using School.Domain.Interfaces;
using School.Domain.Enums;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using School.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using School.Application.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace School.Infrastructure.Persistence.Repository
{
    public class PersonaRepository: IPersonaRepository
    {
        private readonly LocalDbContext _context;
        private readonly IMapper _mapper;
        public PersonaRepository(LocalDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<Persona> AddAsync(Persona persona)
        {
            await _context.Personas.AddAsync(persona);
            await _context.SaveChangesAsync();

            return persona;
        }


        public async Task<Persona> UpdateAsync(int id, Persona persona)
        {
            var objPersona = await _context.Personas.FindAsync(id);

            if (objPersona == null) throw new BusinessException("Perrsona no encontrada");

            if(!persona.Nombres.IsNullOrEmpty())
            objPersona.Nombres   =   persona.Nombres;

            if (!persona.Apellidos.IsNullOrEmpty())
                objPersona.Apellidos =   persona.Apellidos;

            if (!persona.Direccion.IsNullOrEmpty())
                objPersona.Direccion =   persona.Direccion;

            if (!persona.Telefono.IsNullOrEmpty())
                objPersona.Telefono  =   persona.Telefono;

            if (!persona.NombreUsuario.IsNullOrEmpty())
                objPersona.NombreUsuario =   persona.NombreUsuario;

            if (!persona.Email.IsNullOrEmpty())
                objPersona.Email     =   persona.Email;

                objPersona.Estado    =   persona.Estado;
                objPersona.FechaActualizacion =  DateTime.UtcNow;
                objPersona.SyncStatus    =   SyncStatus.Pending;

            if (!persona.Rol.IsNullOrEmpty())
                objPersona.Rol       = persona.Rol;

            await _context.SaveChangesAsync();

            return objPersona;
        }


        public async Task DeleteAsync(int id)
        {
            var persona = await _context.Personas.FindAsync(id);


            if (persona != null)
            {
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }

        }



        public async Task<Persona> GetByIdAsync(int id)
        {
            return await _context.Personas.FindAsync(id);
        }


        public async Task<List<Persona>> GetAllByPendingSyncAsync()
        {
            return await _context.Personas.Where(p => p.SyncStatus == SyncStatus.PendingInsert).ToListAsync();
        }


        public async Task<PaginacionResponse<Persona>> GetAllByRol(string rol, int page = 0, int size = 100)
        {

            int offset = (page -1) * size;

            var query = _context.Personas
                .Where(p => p.Rol == rol)
                .OrderBy(p => p.Id);

            int totalRegistros = await query.CountAsync();

            //Aplicar paginacion y ejecutar 
            var datos = await query
                .Skip(offset)
                .Take(size)
                .ToListAsync();

            return new PaginacionResponse<Persona>
            {
                Datos = datos,
                PaginaActual = page,
                TamañoPagina = size,
                TotalRegistros = totalRegistros,
                TotalPaginas = (int)Math.Ceiling((double)totalRegistros / size),
                TieneAnterior = page > 1,
                TieneSiguiente = page * size < totalRegistros
            };  

            // return await _context.Personas.Where(p => p.Rol == rol).ToListAsync();
        }


        public async Task<bool> ValidateCredential( string userName, string password)
        {
           var user = await _context.Personas.AnyAsync(p => p.NombreUsuario == userName && p.Password == password);

            return user;

        }


        public async Task<PersonaCredenciales> GetCredential(string userName)
        {
            PersonaCredenciales personCredential = new PersonaCredenciales();

            var credential = await _context.Personas
                .Where(p => p.NombreUsuario == userName)
                .Select(p => new
                {
                    NombreUsuario = p.NombreUsuario,
                    Password = p.Password,
                    Nombres = p.Nombres,
                    Apellidos = p.Apellidos,
                    Rol = p.Rol

                }
                ).FirstOrDefaultAsync();


            personCredential.NombreUsuario = credential.NombreUsuario;
            personCredential.Password = credential.Password;
            personCredential.Nombres = credential.Nombres;
            personCredential.Apellidos = credential.Apellidos;
            personCredential.Rol = credential.Rol;


            return personCredential;
                     
        }


        //public async  Task<Persona> GetPersonById(int idPersona)
        //{

        //    await _context.Personas.ejre;

        //}
     

    }
}

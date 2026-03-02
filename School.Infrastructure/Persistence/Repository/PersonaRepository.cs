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

            if (!persona.nombreUsuario.IsNullOrEmpty())
                objPersona.nombreUsuario =   persona.nombreUsuario;

            if (!persona.Email.IsNullOrEmpty())
                objPersona.Email     =   persona.Email;

                objPersona.Estado    =   persona.Estado;
                objPersona.FechaActualizacion =  DateTime.UtcNow;
                objPersona.SyncStatus    =   SyncStatus.Pending;

            if (!persona.rol.IsNullOrEmpty())
                objPersona.rol       = persona.rol;

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



        public async Task<Persona> getByIdAsync(int id)
        {
            return await _context.Personas.FindAsync(id);
        }


        public async Task<List<Persona>> getAllByPendingSyncAsync()
        {
            return await _context.Personas.Where(p => p.SyncStatus == SyncStatus.PendingInsert).ToListAsync();
        }


        public async Task<List<Persona>> getAllByRol(string rol)
        {
            return await _context.Personas.Where(p => p.rol == rol).ToListAsync();
        }


        public async Task<bool> validateCredential( string userName, string password)
        {
           var user = await _context.Personas.AnyAsync(p => p.nombreUsuario == userName && p.password == password);

            return user;

        }


        public async Task<PersonaCredenciales> getCredential(string userName)
        {
            PersonaCredenciales personCredential = new PersonaCredenciales();

            var credential = await _context.Personas
                .Where(p => p.nombreUsuario == userName)
                .Select(p => new
                {
                    nombreUsuario = p.nombreUsuario,
                    password = p.password,
                    nombres = p.Nombres,
                    apellidos = p.Apellidos,
                    rol = p.rol

                }
                ).FirstOrDefaultAsync();


            personCredential.nombreUsuario = credential.nombreUsuario;
            personCredential.password = credential.password;
            personCredential.nombres = credential.nombres;
            personCredential.apellidos = credential.apellidos;
            personCredential.rol = credential.rol;


            return personCredential;
                     
        }
     

    }
}

using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Interfaces
{
    public interface IPersonaRepository
    {
        public Task<Persona> crearPersona(Persona persona);

        public Task<List<Persona>> obtenerPersonasPorRol(string rol);

        public Task<Persona> validarCredenciales(string password, string nombreUsuario);

        public  Task AddAsync(Persona persona);

        public  Task UpdateAsync(Persona persona);

        public  Task DeleteAsync(int id);

        public  Task<Persona> getByIdAsync(int id);

        public Task<List<Persona>> getAllByPendingSyncAsync();

    }
}

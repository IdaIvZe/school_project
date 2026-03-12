
using School.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;




namespace School.Domain.Interfaces
{
    public interface IPersonaRepository : IRepository<Persona>
    {
       
        public Task<bool> ValidateCredential(string userName, string password);

        public Task<PersonaCredenciales> GetCredential(string userName);

        public Task<Persona> AddAsync(Persona persona);

        public Task<Persona> UpdateAsync(int id, Persona persona);

        public Task DeleteAsync(int id);

        public Task<Persona> GetByIdAsync(int id);

        public Task<List<Persona>> GetAllByPendingSyncAsync();

        public Task<List<Persona>> GetAllByRol(string rol);

    }
}

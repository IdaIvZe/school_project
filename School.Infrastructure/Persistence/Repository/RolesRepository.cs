using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using School.Domain.InterfacesRepository;
using School.Infrastructure.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Persistence.Repository
{
    public class RolesRepository : IRolesRepository
    {
        private readonly LocalDbContext _context;

        public RolesRepository(LocalDbContext context)
        {
            _context = context;
        }

        public async Task<List<Roles>> GetAllRolesAsync()
        {

           return await _context.Roles.ToListAsync();

        }
    }
}

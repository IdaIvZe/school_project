using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.InterfacesRepository
{
    public  interface IRolesRepository
    {
        Task<List<Roles>> GetAllRolesAsync();

    }
}

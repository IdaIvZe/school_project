using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Application.DTOs;

namespace School.Application.InterfacesService
{
    public interface IRolesService
    {

        Task<List<RolesDto>> GetRolesAsync();
    }
}

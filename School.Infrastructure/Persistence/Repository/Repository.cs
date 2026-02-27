using School.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Persistence.Repository
{
    public class Repository<T>: IRepository<T>  where T : class , ISyncable
    {

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Interfaces
{
    public interface IRepository<T> where T : class , ISyncable
    {
       
    }
}

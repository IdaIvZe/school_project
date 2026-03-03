using School.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.InterfacesRepository
{
    public interface ISyncRepository<T> where T : class, ISyncable
    {
       Task<T?> GetByIdAsync(Guid id);
       Task<IEnumerable<T>> GetPendingLocalAsync();
       Task UpertAsync(T entity);
       Task<DateTime> GetLastSyncDateAsync(string tableName);
       Task UpdateSyncLogAsync(string tableName, DateTime date);

    }
}

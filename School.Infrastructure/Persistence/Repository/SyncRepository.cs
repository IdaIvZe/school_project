using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using School.Domain.Enums;
using School.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using School.Infrastructure.Persistence.Data;

namespace School.Infrastructure.Persistence.Repository;

public  class SyncRepository<T> where T : class, ISyncable
{

    private readonly LocalDbContext _localContext;
    private readonly RemoteDbContext _remoteContext;

    public SyncRepository(LocalDbContext localContext, RemoteDbContext remoteContext)
    {
        _localContext = localContext;
        _remoteContext = remoteContext;

    }

    public async Task<T?> GetByIdAsync(Guid id )
    {
        return await _localContext.Set<T>().FindAsync(id);
    }


    public async Task<IEnumerable<T>> GetPendingLocalAsync()
    {

        return await _localContext.Set<T>().Where(x => x.SyncStatus ==  SyncStatus.Pending).ToListAsync();
    }

    public Task UpsertAsync(T entity)
    { // Inserta o Actualiza
        return null;
    }
    public Task<DateTime> GetLastSyncDateAsync(string tableName)
    {

        return null;
    }
    public Task UpdateSyncLogAsync(string tableName, DateTime date)
    {
        return null;
    }


}

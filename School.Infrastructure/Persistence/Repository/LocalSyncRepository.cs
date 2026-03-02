using Microsoft.EntityFrameworkCore;
using School.Domain.InterfacesRepository;
using School.Domain.Interfaces;
using School.Infrastructure.Persistence.Data;
using School.Domain.Entities;
using School.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace School.Infrastructure.Persistence.Repository
{
    public class LocalSyncRepository<T> : ISyncRepository<T> where T : class, ISyncable
    {
        private readonly LocalDbContext _localContex;
        private readonly DbSet<T> _dbLocalSet;

        public LocalSyncRepository(LocalDbContext localContext)
        {
            _localContex = localContext;
            _dbLocalSet = _localContex.Set<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id) => await _dbLocalSet.FindAsync(id);

        public async Task<IEnumerable<T>> GetPendingLocalAsync() => await _dbLocalSet.Where(x => x.SyncStatus == SyncStatus.Pending).ToListAsync();

        public async Task UpertAsync(T entity)
        {
            var existing = await _dbLocalSet.AsNoTracking().FirstOrDefaultAsync(X => X.IdGlobal == entity.IdGlobal);
            if (existing == null)
                await _dbLocalSet.AddAsync(entity);
            else _localContex.Entry(entity).State = EntityState.Modified;

            await _localContex.SaveChangesAsync();
        }

        public async Task<DateTime> GetLastSyncDateAsync(string table)
        {
            var log = await _localContex.SyncLog.FirstOrDefaultAsync(x => x.TableName == table);

            return log?.LastSyncDate ?? DateTime.MinValue;
        }

        public async Task UpdateSyncLogAsync(string tableName, DateTime date)
        {
            var log = await _localContex.SyncLog.FirstOrDefaultAsync(x => x.TableName == tableName);
            if (log == null) {

                SyncLog objSyncLog = new SyncLog { TableName = tableName, LastSyncDate = date }; 
               _localContex.SyncLog.Add(objSyncLog);

            }
            else
            {
                log.LastSyncDate = date;
            }

            await _localContex.SaveChangesAsync();
        }

    }
}



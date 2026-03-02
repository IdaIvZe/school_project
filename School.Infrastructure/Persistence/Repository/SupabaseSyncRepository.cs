using School.Domain.Interfaces;
using School.Domain.InterfacesRepository;
using School.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Supabase;
using Postgrest.Models; 
using Postgrest.Attributes;
//using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Persistence.Repository
{
    public class SupabaseSyncRepository<T> : ISyncRepository<T> where T : class, ISyncable
    {

        private readonly RemoteDbContext _supabaseContext;
        private readonly DbSet<T> _dbRemotoContext;

        public SupabaseSyncRepository(RemoteDbContext supabaseContext)
        {
            _supabaseContext = supabaseContext;
            _dbRemotoContext = _supabaseContext.Set<T>();

        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbRemotoContext.AsNoTracking().FirstOrDefaultAsync(x => x.IdGlobal == id);
        }

        public async Task<IEnumerable<T>> GetPendingLocalAsync()
        {
            return await _dbRemotoContext.AsNoTracking().ToListAsync();
        }

       public async Task UpertAsync(T entity)
        {
            var existing = _dbRemotoContext.AsNoTracking().FirstOrDefaultAsync(x => x.IdGlobal == entity.IdGlobal);

            if (existing == null)
            {
                await _dbRemotoContext.AddAsync(entity);
            }
            else
            {
                _supabaseContext.Entry(entity).State = EntityState.Modified;
            }

            await _supabaseContext.SaveChangesAsync();

        }



        public async Task<DateTime> GetLastSyncDateAsync(string tableName) => await Task.FromResult(DateTime.MinValue);



        public async Task UpdateSyncLogAsync(string tableName, DateTime date) => await Task.CompletedTask;
        


    }
}

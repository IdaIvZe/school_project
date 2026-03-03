using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Domain.Enums;
using School.Domain.Interfaces;
using School.Domain.InterfacesRepository;

namespace School.Application.Services
{
    public class SyncService<T> where T : class, ISyncable
    {
        
        private readonly ISyncRepository<T> _localRepo;
        private readonly ISyncRepository<T> _cloudRepo;

        public SyncService(ISyncRepository<T> localRepo, ISyncRepository<T> cloudRepo)
        {
            _localRepo = localRepo;
            _cloudRepo = cloudRepo;
        }

        public async Task Synchronize(string tableName)
        {
            //1. PULL (SUPABASE -> LOCAL)
            var lastSyc = await _localRepo.GetLastSyncDateAsync(tableName);
            var cloudChanges = await _cloudRepo.GetPendingLocalAsync();

            foreach (var item in cloudChanges)
            {
                await _localRepo.UpertAsync(item);
            }



            //2. PUSH (Local -> Supabase)
            var pendingLocal = await _localRepo.GetPendingLocalAsync();
            foreach ( var item in pendingLocal) 
            {
                item.SyncStatus = SyncStatus.Pending;

                await _cloudRepo.UpertAsync(item);
                await _localRepo.UpertAsync(item);
            }

            await _localRepo.UpdateSyncLogAsync(tableName, DateTime.UtcNow);

        }

    }
}

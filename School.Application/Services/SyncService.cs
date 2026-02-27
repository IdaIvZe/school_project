using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Domain.Enums;
using School.Domain.Interfaces;

namespace School.Application.Services
{
    public  class SyncService<T> where T : class, ISyncable
    {
        //private readonly IRepository<T> _localRepo;
        //private readonly ISupabaseCliente _supabase;

        //public async Task Syncronize()
        //{
        //    var lastSync = GetLastSyncDate();
        //    var cloudChanges = await _supabase.From<T>().Where(x => x.UpdateAt > lastSync).Get();

        //    //Pull: obtenr los cambios en la nube
        //    foreach (var item in cloudChanges)
        //    {
        //        var local = await _localRepo.GetById(item.Id);
        //        if (local == null || item.UpdatedAt > local.UpdateAt)
        //        {
        //            await _localRepo.UpdatedAt(item); // crea o actualiza en local
        //        }   
        //    }

        //    //Push: Evitar cambios locales en la nube
        //    var pendingLocal = await _localRepo.Where(x => x.Status == SyncStatus.Pending);
        //    foreach (var item in pendingLocal)
        //    {
        //        item.Status = SyncStatus.Synced;
        //        await _supabase.From<T>().Upsert(item);
        //        await _localRepo.Update(item);
        //    }
        //}

    }
}

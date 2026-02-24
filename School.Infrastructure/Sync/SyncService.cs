using School.Application.DTOs;
using School.Application.Services;
using School.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Domain.Enums;
using System.IO;

namespace School.Infrastructure.Sync
{
    public class SyncService: ISyncService
    {

        private readonly IPersonaRepository _personaRepository;

        public SyncService(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

       public async Task SyncPendingAsync()
        {
            var pendigPersonas = await _personaRepository.getAllByPendingSyncAsync();


            foreach(var persona in pendigPersonas)
            {
                try
                {

                    //logica para actualizacoines con supabase

                    persona.SyncStatus = SyncStatus.Synced;
                   
                    await _personaRepository.UpdateAsync(persona);

                }
                catch(Exception ex)
                {
                    throw new Exception($"Error en sincronizacion de bases de datos remota y local {persona.Id}: {ex.Message}");
                    //Console.WriteLine($"Error sync persona {persona.Id}: {ex.Message}");
                }
            }
        }


    }
}

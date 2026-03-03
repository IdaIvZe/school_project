using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Infrastructure.Persistence.Data;
using School.Domain.Interfaces;

namespace School.Infrastructure.Service
{
    public class DataBaseConnectionTester: IDataBaseConnectionTester
    {

        private readonly LocalDbContext _context;
        private readonly RemoteDbContext _remoteContext;

        public DataBaseConnectionTester(LocalDbContext context, RemoteDbContext remoteContext)
        {
            _context = context;
            _remoteContext = remoteContext;
        }

        public  async Task<bool> TestConnectionAsync()
        {
            try
            {
                return await _remoteContext.Database.CanConnectAsync();
            }
            catch (Exception ex) 
            {

                    throw new Exception($"Error en la concion de la base de daos detectadso en Infrestrucutre.Service, el error es : {ex.Message}");
        
            }
        }


    }
}

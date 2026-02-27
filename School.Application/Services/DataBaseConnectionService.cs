using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Domain.Interfaces;
namespace School.Application.Services
{
    public class DataBaseConnectionService
    {
        private readonly IDataBaseConnectionTester _dbConnectionTester;
        
        public DataBaseConnectionService(IDataBaseConnectionTester dbConnectionTester)
        {
            _dbConnectionTester = dbConnectionTester;
        }

        public async Task CheckConnectionAsync()
        {
           
            try
            {
                var test = await _dbConnectionTester.TestConnectionAsync();

                if (test)
                {
                    Console.WriteLine("Coneccion a la base de datos exitosa");
                }
                else
                { 
                    throw new Exception("La conexión devolvió 'false' (Fallo lógico).");
                }
               
            }
            catch(Exception ex)
            {
                throw new Exception($"Error en la coneccion a base de datos, eror tipo : {ex.Message}");
            }
        }
    }
}

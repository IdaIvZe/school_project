using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class SyncLog
    {

        [Key]
        public string TableName { get; set; }  // Ejemplo: "Persona"
            public DateTime LastSyncDate { get; set; }
        

    }
}

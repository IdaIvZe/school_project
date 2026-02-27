using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Domain.Enums;

namespace School.Domain.Interfaces
{
    public interface ISyncable
    {
        Guid IdGlobal {get; set; }
        DateTime UpdatedAt {get; set; }
        bool IsDeleted {get; set; }
        SyncStatus SyncStatus {get; set; }

    }
}

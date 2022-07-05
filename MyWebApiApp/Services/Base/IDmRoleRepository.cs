using AMGAPI.Data;
using AMGAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services.Base
{
    public interface IDmRoleRepository
    {
        List<DmRole> GetAll();
        DmRole GetById(string id);
        DmRole Add(DmRoleVM nhomquyen);
        bool Update(DmRole nhomquyen);
        bool Delete(string id);
    }
}

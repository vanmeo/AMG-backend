using AMGAPI.Data;
using AMGAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services.Base
{
    public interface IDmAppRepository
    {
        List<DmApp> GetAll();
        DmApp GetById(string id);
        DmApp Add(DmAppVM App);
        bool Update(DmApp App);
        bool Delete(string id);
    }
}

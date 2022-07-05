using AMGAPI.Data;
using AMGAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services.Base
{
    public interface IDmDonviRepository
    {
        List<DmDonvi> GetAll();
        DmDonvi GetById(string id);
        DmDonvi Add(DmDonviVM donvi);
        bool Update(DmDonvi donvi);
        bool Delete(string id);
    }
}

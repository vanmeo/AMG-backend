using AMGAPI.Data;
using AMGAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services.Base
{
   public interface IDmChucvuRepository
    {

        List<DmChucvu> GetAll();
        DmChucvu GetById(string id);
        DmChucvu Add(DmChucvuVM capbac);
        bool Update(DmChucvu capbac);
        bool Delete(string id);
        List<DmChucvu> getallbyProcedure();
    }
}


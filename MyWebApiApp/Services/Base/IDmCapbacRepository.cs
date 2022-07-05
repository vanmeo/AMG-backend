using AMGAPI.Data;
using AMGAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services.Base
{
    public interface IDmCapbacRepository
    {

        List<DmCapbac> GetAll();
        DmCapbac GetById(string id);
        DmCapbac Add(DmCapbacVM capbac);
        bool Update(DmCapbac capbac);
        bool Delete(string id);
    }
}

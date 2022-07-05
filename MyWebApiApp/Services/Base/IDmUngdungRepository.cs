using AMGAPI.Data;
using AMGAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services.Base
{
    public interface IDmUngdungRepository
    {
        List<DmUngdung> GetAll();
        DmUngdung GetById(string id);
        DmUngdung Add(DmUngdungVM App);
        bool Update(DmUngdung App);
        bool Delete(string id);
    }
}

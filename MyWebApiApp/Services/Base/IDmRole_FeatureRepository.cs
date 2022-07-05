using AMGAPI.Data;
using AMGAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services.Base
{
    public interface IDmRole_FeatureRepository
    {
        List<DmRole_Feature> GetAll();
        DmRole_Feature GetById(string id);
        DmRole_Feature Add(DmRole_FeatureVM feature);
        bool Update(DmRole_Feature feature);
        bool Delete(string id);
    }
}

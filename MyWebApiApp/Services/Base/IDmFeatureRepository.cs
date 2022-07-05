using AMGAPI.Data;
using AMGAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services.Base
{
    public interface IDmFeatureRepository
    {
        List<DmFeature> GetAll();
        DmFeature GetById(string id);
        DmFeature Add(DmFeatureVM feature);
        bool Update(DmFeature feature);
        bool Delete(string id);
    }
}

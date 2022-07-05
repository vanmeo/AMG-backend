using AMGAPI.Data;
using AMGAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services.Base
{
    public interface ICanboRepository
    {
        List<Canbo> GetAll();
        Canbo GetById(string id);
        Canbo Add(CanboVM nguoidung);
        bool Update(Canbo nguoidung);
        bool Delete(string id);
        Canbo GetByLoginModel(LoginModel model);
        List<App_RoleFeature> GetAppRoleFeaturebyCanboId(string idCanbo);
    }
}

using AMGAPI.Data;
using AMGAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services.Base
{
    public interface ISoquanlykenhRepository
    { 
        List<Soquanlykenh> GetAll();
        Soquanlykenh GetById(string id);
        Soquanlykenh Add(SoquanlykenhVM Sokenh);
        bool Update(Soquanlykenh Sokenh);
        bool Delete(string id);
        Soquanlykenh ThaydoiTrangthai(string idkenh, int trangthai);
    }
}

using AMGAPI.Data;
using AMGAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services.Base
{
    public interface IDmThongbaoRepository
    {

        List<DmThongbao> GetAll();
        //  DmThongbao GetById(string id);
        DmThongbao Add(DmThongbaoVM Thongbao);
        bool CheckQuyen(DmThongbaoVM Thongbao);
        //bool Delete(string id);
    }
}

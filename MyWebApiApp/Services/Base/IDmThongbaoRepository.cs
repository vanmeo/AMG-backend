using AMGAPI.Data;
using AMGAPI.Models;
using Microsoft.AspNetCore.Http;
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
        bool sendsms(string IdKenh, string sms, string sdtnhan);
        bool sendsmsfile(string IdKenh, string sms, string sdtnhan, List<IFormFile> Files);
        bool CheckQuyen(DmThongbaoVM Thongbao);
        //bool Delete(string id);
    }
}

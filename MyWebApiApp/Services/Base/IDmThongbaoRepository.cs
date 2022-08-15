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
        bool sendsms(string Sodienthoaigui, string IdKenh, string tieude, string sms, string DsSdtnhan);
        bool sendsmsfile(string Sodienthoaigui, string tieude, string IdKenh, string sms, string DSsdtnhan, List<IFormFile> Files);
        bool CheckQuyen(DmThongbaoVM Thongbao);
        //bool Delete(string id);
    }
}

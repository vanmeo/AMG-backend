using AMGAPI.Data;
using AMGAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services.Base
{
    public interface IDangkykenhRepository
    {

        List<Dangkykenh> GetAll();
        Dangkykenh GetById(string id);
        Dangkykenh Add(DangkykenhVM Dangkykenh);
        bool Update(Dangkykenh Dangkykenh, string tennguoisua);
        bool Delete(string id, string Tennguoixoa);
        Dangkykenh ThaydoiTrangthai(string idkenh, int trangthai, string tencanbothaydoi);
        Dangkykenh_Duyet DuyetKenh(string idkenh, Dangkykenh_DuyetVM Dangkykenh);
    }
}

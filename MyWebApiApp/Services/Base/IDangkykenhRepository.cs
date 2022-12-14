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
        PagedList<Dangkykenh> getAll(PaginParameters paginParameters);
        List<Dangkykenh> FindAll(string searchString, string IdDonvi, DateTime from, DateTime to, int Trangthaidkkenh);
        PagedList<Dangkykenh> findAll(PaginParameters paginParameters, string searchString, string IdDonvi, DateTime from, DateTime to,int Trangthaidkkenh);
        Dangkykenh GetById(string id);
        Dangkykenh Add(DangkykenhVM Dangkykenh);
        bool Update(Dangkykenh Dangkykenh, string tennguoisua);
        bool Delete(string id, string Tennguoixoa);
        Dangkykenh ThaydoiTrangthai(string idkenh, int trangthai, string tencanbothaydoi);
        Dangkykenh_Duyet DuyetKenh(string idkenh, Dangkykenh_DuyetVM Dangkykenh);
    }
}

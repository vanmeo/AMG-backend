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
        PagedList<Soquanlykenh> getAll(PaginParameters paginParameters);
        List<Soquanlykenh> FindAll(string searchString,string IdDonvi, DateTime from, DateTime to, int Trangthaikenh);
        PagedList<Soquanlykenh> findAll(PaginParameters paginParameters, string searchString,string IdDonvi, DateTime from, DateTime to, int Trangthaikenh);
        Soquanlykenh GetById(string id);
        Soquanlykenh Add(SoquanlykenhVM Sokenh, string tencanbotao);
        bool Update(Soquanlykenh Sokenh, string tencanbosua);
        bool Delete(string id, string tencanbo);
        Soquanlykenh ThaydoiTrangthai(string idkenh, int trangthai,string tencanbo);
        bool Themdanhsachnguoidung(string idkenh, string idcanbotao, string filename);
        bool AddArray(string idkenh, List<NguoidungMobile> DS, string idcanbotao);
    }
}

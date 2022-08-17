using AMGAPI.Data;
using AMGAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services.Base
{
    public interface IDangkykenh_DuyetRepository
    {

        List<Dangkykenh_Duyet> GetAll();
        PagedList<Dangkykenh_Duyet> getAll(PaginParameters paginParameters);
        List<Dangkykenh_Duyet> FindAll(string searchString, string IdDonvi, DateTime from, DateTime to, int Trangthaikenh);
        PagedList<Dangkykenh_Duyet> findAll(PaginParameters paginParameters, string searchString, string IdDonvi, DateTime from, DateTime to, int Trangthaikenh);
        Dangkykenh_Duyet GetById(string id);
        Dangkykenh_Duyet Add(Dangkykenh_DuyetVM Dangkykenh);
        bool Update(Dangkykenh_Duyet Dangkykenh, string tencanbosua);
        bool Delete(string id,string tennguoixoa);
        Soquanlykenh Vaosoquanlykenh(string idkenh, SoquanlykenhVM Soquanlykenh, string tencanbovaoso);

    }
}

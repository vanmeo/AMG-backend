﻿using AMGAPI.Data;
using AMGAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services.Base
{
    public interface IDanhsachnguoidungRepository
    {
        List<Danhsachnguoidung> GetAll();
        PagedList<Danhsachnguoidung> getAll(PaginParameters paginParameters);
        List<Danhsachnguoidung> FindAll(string searchString);
        PagedList<Danhsachnguoidung> findAll(PaginParameters paginParameters, string searchString);
        Danhsachnguoidung GetById(string id);
        Danhsachnguoidung Add(DanhsachnguoidungVM danhsachnguoidungvm);
        bool Update(Danhsachnguoidung nguoidung);
        bool Delete(string id);
    }
}

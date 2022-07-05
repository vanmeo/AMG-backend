﻿using AMGAPI.Data;
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
        Dangkykenh_Duyet GetById(string id);
        Dangkykenh_Duyet Add(Dangkykenh_DuyetVM Dangkykenh);
        bool Update(Dangkykenh_Duyet Dangkykenh);
        bool Delete(string id);
        Soquanlykenh Vaosoquanlykenh(string idkenh, SoquanlykenhVM Soquanlykenh);

    }
}

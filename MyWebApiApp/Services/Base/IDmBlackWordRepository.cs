using AMGAPI.Data;
using AMGAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services.Base
{
    public interface IDmBlackWordRepository
    {
        List<DmBlackWord> GetAll();
        DmBlackWord GetById(string id);
        DmBlackWord Add(DmBlackWordVM BlackWork);
        bool Update(DmBlackWord BlackWord);
        bool Delete(string id);
    }
}

using AMGAPI.Data;
using AMGAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services.Base
{
    public interface IThongsohethongRepository
    {
     
        ThongsoHethong GetThongsohethong();
       
        bool Update(ThongsoHethong Thongsohethong);
  
    }
}

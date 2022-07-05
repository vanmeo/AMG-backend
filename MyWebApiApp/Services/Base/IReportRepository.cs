using AMGAPI.Data;
using AMGAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services.Base
{
    public interface IReportRepository
    {
        byte[] BaocaoTongHopSoKenh( string reportType);
        byte[] BaocaoChitiet1Kenh(string reportType, string IdKenh);
    }
}

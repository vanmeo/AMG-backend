using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services
{
    public class ThongsohethongRepository : IThongsohethongRepository
    {
        private readonly MyDbContext _context;

        public ThongsohethongRepository(MyDbContext context)
        {
            _context = context;
        }
        
        public ThongsoHethong GetThongsohethong()
        {
            var Thongsohethong = _context.ThongsoHethongs.SingleOrDefault();
            return Thongsohethong;
        }
        public bool Update(ThongsoHethong Thongsohethong)
        {
            var _hethong = _context.ThongsoHethongs.SingleOrDefault(cb => cb.Id == Thongsohethong.Id);
            if (_hethong != null)
            {
                _hethong.TansuatQuet_Phut = Thongsohethong.TansuatQuet_Phut;
                _hethong.TanSuatXoanhatky_ngay = Thongsohethong.TanSuatXoanhatky_ngay;
                _hethong.KichthuocFilesMax = Thongsohethong.KichthuocFilesMax;
                _hethong.Datadiode_Token = Thongsohethong.Datadiode_Token;
                _hethong.Datadiode_Port = Thongsohethong.Datadiode_Port;
                _hethong.Datadiode_IP = Thongsohethong.Datadiode_IP;
                _hethong.ModifiedDate = DateTime.UtcNow;
                _context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}

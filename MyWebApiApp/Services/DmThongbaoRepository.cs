using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services
{
    public class DmThongbaoRepository : IDmThongbaoRepository
    {
        private readonly MyDbContext _context;

        public DmThongbaoRepository(MyDbContext context)
        {
            _context = context;
        }
        // Thêm mới danh mục với ViewModel cho trước
        public DmThongbao Add(DmThongbaoVM dmthongbaovm)
        {
            if (CheckQuyen(dmthongbaovm))
            {
                var _Thongbao = new DmThongbao
                {
                    SoquanlykenhId = Guid.Parse(dmthongbaovm.SoquanlykenhId),
                    Noidungtinnhan = dmthongbaovm.Noidungtinnhan,
                    Sodienthoainhan = dmthongbaovm.Sodienthoainhan,
                    Ngaytao = DateTime.UtcNow
                };
                _context.Add(_Thongbao);
                _context.SaveChanges();
                return _Thongbao;
            }
            else
                return null;
           
        }
        public List<DmThongbao> GetAll()
        {
            var Thongbaos = _context.DmThongbaos.Select(tb => tb);
            return Thongbaos.ToList();
        }
        public bool CheckQuyen(DmThongbaoVM Thongbao)
        {
            var soquanly = _context.Soquanlykenhs.SingleOrDefault(sokenh => sokenh.Id.ToString() == Thongbao.SoquanlykenhId);
            if (soquanly != null)
            {
                if (soquanly.Trangthai == 1)
                    return true;
                else
                    return false;
            }

            else
                return false;
        }
    
    }
}

using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services
{
    public class DmDonviRepository : IDmDonviRepository
    {
        private readonly MyDbContext _context;

        public DmDonviRepository(MyDbContext context)
        {
            _context = context;
        }
        public DmDonvi Add(DmDonviVM dmdonvivm)
        {
            var _Donvi = new DmDonvi
            {
                ParentId = dmdonvivm.ParentId,
                Ma = dmdonvivm.Ma,
                Ten = dmdonvivm.Ten,
                Viettat = dmdonvivm.Viettat,
                Status = dmdonvivm.Status,
                Ghichu = dmdonvivm.Ghichu
            };
            _context.Add(_Donvi);
            _context.SaveChanges();
            return _Donvi;
        }
        // Thiết lập is_Delete=true hoặc Status=false chứ không xóa vật lý 
        public bool Delete(string id)
        {
            var Donvi = _context.DmDonvis.SingleOrDefault(cb => cb.Id.ToString() == id);
            if (Donvi != null)
            {
                Donvi.Status = false;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public List<DmDonvi> GetAll()
        {
            var Donvis = _context.DmDonvis.Select(Donvi => Donvi).Where(x => x.Status == true);
            return Donvis.ToList();
        }
        // Lấy theo Id đối tượng không tự động lấy quan hệ nếu cần thì lấy thêm đối tượng quan hệ
        public DmDonvi GetById(string id)
        {
            var Donvi = _context.DmDonvis.SingleOrDefault(cb => cb.Id.ToString() == id && cb.Status == true);
            if (Donvi != null)
                _context.Entry(Donvi).Collection(p => p.Canbos).Load();
            return Donvi;
        }

        public bool Update(DmDonvi Donvi)
        {
            var _Donvi = _context.DmDonvis.SingleOrDefault(cb => cb.Id == Donvi.Id);

            if (_Donvi != null)
            {
                _Donvi.ParentId = Donvi.ParentId;
                _Donvi.Ma = Donvi.Ma;
                _Donvi.Ten = Donvi.Ten;
                _Donvi.Viettat = Donvi.Viettat;
                _Donvi.Status = Donvi.Status;
                _Donvi.Ghichu = Donvi.Ghichu;
                _context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}

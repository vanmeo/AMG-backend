using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services
{
    public class DmCapbacRepository : IDmCapbacRepository
    {
        private readonly MyDbContext _context;

        public DmCapbacRepository(MyDbContext context)
        {
            _context = context;
        }
        // Thêm mới danh mục với ViewModel cho trước
        public DmCapbac Add(DmCapbacVM dmcapbacvm)
        {
            var _capbac = new DmCapbac
            {
                Ten = dmcapbacvm.Ten,
                Viettat = dmcapbacvm.Viettat,
                Status = dmcapbacvm.Status,
                Ghichu = dmcapbacvm.Ghichu
            };
            _context.Add(_capbac);
            _context.SaveChanges();
            return _capbac;
        }
        // Thiết lập is_Delete=true hoặc Status=false chứ không xóa vật lý 
        public bool Delete(string id)
        {
            var capbac = _context.DmCapbacs.SingleOrDefault(cb => cb.Id.ToString() == id);
            if (capbac != null)
            {
                capbac.Status = false;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<DmCapbac> GetAll()
        {
            var capbacs = _context.DmCapbacs.Select(capbac => new DmCapbac
            {
                Id = capbac.Id,
                Ten = capbac.Ten,
                Viettat = capbac.Viettat,
                Status = capbac.Status,
                Ghichu = capbac.Ghichu

            }).Where(x => x.Status == true);
            return capbacs.ToList();
        }
        // Lấy theo Id đối tượng không tự động lấy quan hệ nếu cần thì lấy thêm đối tượng quan hệ
        public DmCapbac GetById(string id)
        {
            var capbac = _context.DmCapbacs.SingleOrDefault(cb => cb.Id.ToString() == id && cb.Status == true);
            if (capbac != null)
                _context.Entry(capbac).Collection(p => p.Canbos).Load();
            return capbac;
        }

        public bool Update(DmCapbac capbac)
        {
            var _capbac = _context.DmCapbacs.SingleOrDefault(cb => cb.Id == capbac.Id);

            if (_capbac != null)
            {
                _capbac.Ten = capbac.Ten;
                _capbac.Viettat = capbac.Viettat;
                _capbac.Status = capbac.Status;
                _capbac.Ghichu = capbac.Ghichu;
                _context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}

using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services
{
    public class DmUngdungRepository : IDmUngdungRepository
    {
        private readonly MyDbContext _context;

        public DmUngdungRepository(MyDbContext context)
        {
            _context = context;
        }
        // Thêm mới danh mục với ViewModel cho trước
        public DmUngdung Add(DmUngdungVM dmungdungvm)
        {
            var _app = new DmUngdung
            {
                Ten = dmungdungvm.Ten,
                Viettat = dmungdungvm.Viettat,
                is_Delete = dmungdungvm.is_Delete,
                Ghichu= dmungdungvm.Ghichu
            };
            _context.Add(_app);
            _context.SaveChanges();
            return _app;
        }
        // Thiết lập is_Delete=true hoặc Status=false chứ không xóa vật lý 
        public bool Delete(string id)
        {
            var UD = _context.DmUngdungs.SingleOrDefault(ud => ud.Id.ToString() == id);
            if (UD != null)
            {
                UD.is_Delete = true;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<DmUngdung> GetAll()
        {
            var capbacs = _context.DmUngdungs.Select(ud => ud).Where(x => x.is_Delete == false);
            return capbacs.ToList();
        }
        // Lấy theo Id đối tượng không tự động lấy quan hệ nếu cần thì lấy thêm đối tượng quan hệ
        public DmUngdung GetById(string id)
        {
            var ud = _context.DmUngdungs.SingleOrDefault(ud => ud.Id.ToString() == id && ud.is_Delete == false);
            return ud;
        }

        public bool Update(DmUngdung ud)
        {
            var _ud = _context.DmUngdungs.SingleOrDefault(d => d.Id == ud.Id);

            if (_ud != null)
            {
                _ud.Ten = ud.Ten;
                _ud.Viettat = ud.Viettat;
                _ud.is_Delete = ud.is_Delete;
                _ud.Ghichu = ud.Ghichu;
                _context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}

using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services
{
    public class DmAppRepository : IDmAppRepository
    {
        private readonly MyDbContext _context;

        public DmAppRepository(MyDbContext context)
        {
            _context = context;
        }
        // Thêm mới danh mục với ViewModel cho trước
        public DmApp Add(DmAppVM dmappvm)
        {
            var _app = new DmApp
            {
                Ten = dmappvm.Ten,
                Viettat = dmappvm.Viettat,
                is_Delete = dmappvm.is_Delete,
                Ghichu = dmappvm.Ghichu
            };
            _context.Add(_app);
            _context.SaveChanges();
            return _app;
        }
        // Thiết lập is_Delete=true hoặc Status=false chứ không xóa vật lý 
        public bool Delete(string id)
        {
            var _App = _context.DmApps.SingleOrDefault(app => app.Id.ToString() == id);
            if (_App != null)
            {
                _App.is_Delete = true;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<DmApp> GetAll()
        {
            var Apps = _context.DmApps.Select(app => app).Where(x => x.is_Delete == false);
            return Apps.ToList();
        }
        // Lấy theo Id đối tượng không tự động lấy quan hệ nếu cần thì lấy thêm đối tượng quan hệ
        public DmApp GetById(string id)
        {
            var _app = _context.DmApps.SingleOrDefault(cb => cb.Id.ToString() == id && cb.is_Delete == false);
            if (_app != null)
                _context.Entry(_app).Collection(p => p.Features).Load();
            return _app;
        }

        public bool Update(DmApp app)
        {
            var _app = _context.DmApps.SingleOrDefault(_app => _app.Id == app.Id);

            if (_app != null)
            {
                _app.Ten = app.Ten;
                _app.Viettat = app.Viettat;
                _app.is_Delete = app.is_Delete;
                _app.Ghichu = app.Ghichu;
                _context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}

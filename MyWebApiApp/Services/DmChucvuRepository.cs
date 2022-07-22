using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services
{
    public class DmChucvuRepository : IDmChucvuRepository
    {
        private readonly MyDbContext _context;

        public DmChucvuRepository(MyDbContext context)
        {
            _context = context;
        }
        // Thêm mới danh mục với ViewModel cho trước
        public DmChucvu Add(DmChucvuVM dmchucvuvm)
        {
            var _Chucvu = new DmChucvu
            {
                Ten = dmchucvuvm.Ten,
                Viettat = dmchucvuvm.Viettat,
                Status = dmchucvuvm.Status,
                Ghichu= dmchucvuvm.Ghichu
            };
            _context.Add(_Chucvu);
            _context.SaveChanges();

            return _Chucvu;
        }
        // Thiết lập is_Delete=true hoặc Status=false chứ không xóa vật lý 
        public bool Delete(string id)
        {
            var Chucvu = _context.DmChucvus.SingleOrDefault(cb => cb.Id.ToString() == id);
            if (Chucvu != null)
            {
                Chucvu.Status = false;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public List<DmChucvu> GetAll()
        {
            var Chucvus = _context.DmChucvus.Select(Chucvu => Chucvu).Where(x => x.Status == true);
            return Chucvus.ToList();
        }

        public List<DmChucvu> getallbyProcedure()
        {
            var _Dmchucvus = _context.DmChucvus.FromSqlRaw("Chucvu_getall").ToList();
            return _Dmchucvus;
        }

        // Lấy theo Id đối tượng không tự động lấy quan hệ nếu cần thì lấy thêm đối tượng quan hệ
        public DmChucvu GetById(string id)
        {
            var Chucvu = _context.DmChucvus.SingleOrDefault(cb => cb.Id.ToString() == id && cb.Status == true);
            if (Chucvu != null)
                _context.Entry(Chucvu).Collection(p => p.Canbos).Load();
            return Chucvu;
        }
        public bool Update(DmChucvu Chucvu)
        {
            var _Chucvu = _context.DmChucvus.SingleOrDefault(cb => cb.Id == Chucvu.Id);
            if (_Chucvu != null)
            {
                _Chucvu.Ten = Chucvu.Ten;
                _Chucvu.Viettat = Chucvu.Viettat;
                _Chucvu.Status = Chucvu.Status;
                _Chucvu.Ghichu = Chucvu.Ghichu;
                _context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}

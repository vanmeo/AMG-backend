using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services
{
    public class DanhsachnguoidungRepository : IDanhsachnguoidungRepository
    {
        private readonly MyDbContext _context;

        public DanhsachnguoidungRepository(MyDbContext context)
        {
            _context = context;
        }
        // Thêm mới danh mục với ViewModel cho trước
        public Danhsachnguoidung Add(DanhsachnguoidungVM danhsachnguoidungvm)
        {
            var _danhsachnguoidung = new Danhsachnguoidung
            {
                Ten = danhsachnguoidungvm.Ten,
                Sodienthoai = danhsachnguoidungvm.Sodienthoai,
                SokenhId = danhsachnguoidungvm.SokenhId,
                CanboId = danhsachnguoidungvm.CanboId,
                Ngaytao = DateTime.UtcNow,
                Ngaysua=DateTime.UtcNow,
                NhanSMS=danhsachnguoidungvm.NhanSMS
            };
            _context.Add(_danhsachnguoidung);
            _context.SaveChanges();
            return _danhsachnguoidung;
        }
        // Thiết lập is_Delete=true hoặc Status=false chứ không xóa vật lý 
        public bool Delete(string id)
        {
            var ND = _context.Danhsachnguoidungs.SingleOrDefault(p => p.Id.ToString() == id);
            if (ND != null)
            {
                _context.Danhsachnguoidungs.Remove(ND);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Danhsachnguoidung> GetAll()
        {
            var danhsachnguoidungs = _context.Danhsachnguoidungs.Select(ud => ud);
            return danhsachnguoidungs.ToList();
        }
        // Lấy theo Id đối tượng không tự động lấy quan hệ nếu cần thì lấy thêm đối tượng quan hệ
        public Danhsachnguoidung GetById(string id)
        {
            var _danhsachnguoidung = _context.Danhsachnguoidungs.SingleOrDefault(p => p.Id.ToString() == id);
            return _danhsachnguoidung;
        }

        public bool Update(Danhsachnguoidung danhsachnguoidung)
        {
            var _ud = _context.Danhsachnguoidungs.SingleOrDefault(p => p.Id == danhsachnguoidung.Id);
            if (_ud != null)
            {
                _ud.Ten = danhsachnguoidung.Ten;
                _ud.SokenhId = danhsachnguoidung.SokenhId;
                _ud.NhanSMS = danhsachnguoidung.NhanSMS;
                _ud.Ngaysua = DateTime.Now;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

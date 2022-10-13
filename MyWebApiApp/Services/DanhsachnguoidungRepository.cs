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
            var soQuanlykenh = _context.Soquanlykenhs.FirstOrDefault(x => x.Id == danhsachnguoidungvm.SokenhId&&x.Trangthai==1);

            if (soQuanlykenh != null)
            {
                var _danhsachnguoidung = new Danhsachnguoidung
                {
                    Ten = danhsachnguoidungvm.Ten,
                    Sodienthoai = danhsachnguoidungvm.Sodienthoai,
                    IdDonvi = soQuanlykenh.IdDonvi,
                    SokenhId = danhsachnguoidungvm.SokenhId,
                    CanboId = danhsachnguoidungvm.CanboId,
                    Ngaytao = DateTime.UtcNow,
                    Ngaysua = DateTime.UtcNow,
                    NhanSMS = danhsachnguoidungvm.NhanSMS,
                    Trangthai = false
                };
                _context.Add(_danhsachnguoidung);
                _context.SaveChanges();
                return _danhsachnguoidung;
            }
            else
                return null;
            
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
            var Danhsachnguoidungs = _context.Danhsachnguoidungs.Select(DsND => DsND);
            return Danhsachnguoidungs.ToList();
        }
        public PagedList<Danhsachnguoidung> getAll(PaginParameters paginParameters)
        {
            return PagedList<Danhsachnguoidung>.ToPagedList(GetAll(),
        paginParameters.PageNumber,
        paginParameters.PageSize);
        }
        public static string _strIdDonvi;
        public void ProcessParentID(string idDonvi)
        {
            var donvi = _context.DmDonvis.FirstOrDefault(x => x.Id.ToString() == idDonvi);
            _strIdDonvi += "," + donvi.Id;

            List<DmDonvi> donvis = _context.DmDonvis.Select(dv => dv).Where(x => x.ParentId.ToString() == idDonvi).ToList();

            foreach (var item in donvis)
            {
                // _strIdDonvi += "," + item.Id;
                ProcessParentID(item.Id.ToString());
            }
        }
        public List<Danhsachnguoidung> FindAll(string searchString, string IdDonvi)
        {
            _strIdDonvi = "";
            if (searchString == null)
                searchString = "";
            var Danhsachnguoidungs = _context.Danhsachnguoidungs.Select(nd => nd).Where(x => (x.Ten.Contains(searchString) || x.Sodienthoai.Contains(searchString))).ToList();
            if (IdDonvi != null)
            {
                ProcessParentID(IdDonvi);
                var nds = Danhsachnguoidungs.Select(x => x).Where(x => _strIdDonvi.Contains(x.IdDonvi.ToString())).ToList();
                return nds.ToList();
            }
            else
                return Danhsachnguoidungs.ToList();
        }
        public PagedList<Danhsachnguoidung> findAll(PaginParameters paginParameters, string searchString, string IdDonvi)
        {
            return PagedList<Danhsachnguoidung>.ToPagedList(FindAll(searchString, IdDonvi),
        paginParameters.PageNumber,
        paginParameters.PageSize);
        }

        // Lấy theo Id đối tượng không tự động lấy quan hệ nếu cần thì lấy thêm đối tượng quan hệ
        public Danhsachnguoidung GetById(string id)
        {
            var _danhsachnguoidung = _context.Danhsachnguoidungs.SingleOrDefault(p => p.Id.ToString() == id);
            return _danhsachnguoidung;
        }

        public bool Update(Danhsachnguoidung danhsachnguoidung)
        {
            var _nd = _context.Danhsachnguoidungs.SingleOrDefault(p => p.Id == danhsachnguoidung.Id);
            if (_nd != null)
            {
                _nd.Ten = danhsachnguoidung.Ten;
                _nd.IdDonvi = danhsachnguoidung.IdDonvi;
                _nd.SokenhId = danhsachnguoidung.SokenhId;
                _nd.NhanSMS = danhsachnguoidung.NhanSMS;
                _nd.Ngaysua = DateTime.Now;
                _nd.Trangthai = danhsachnguoidung.Trangthai;
                _nd.Sodienthoai = danhsachnguoidung.Sodienthoai;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool KichHoatTK(string id)
        {
            var _nd = _context.Danhsachnguoidungs.SingleOrDefault(p => p.Id.ToString() == id);
            if (_nd != null)
            {
   
                _nd.Ngaysua = DateTime.Now;
                _nd.Trangthai = true;
      
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

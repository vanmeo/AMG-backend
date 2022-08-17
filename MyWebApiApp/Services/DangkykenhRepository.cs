using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services
{
    public class DangkykenhRepository : IDangkykenhRepository
    {
        private readonly MyDbContext _context;
        public DangkykenhRepository(MyDbContext context)
        {
            _context = context;
        }
        // Thêm mới danh mục với ViewModel cho trước
        public Dangkykenh Add(DangkykenhVM dangkykenhvm)
        {
            Canbo canbodangky = _context.Canbos.SingleOrDefault(p => p.Id == dangkykenhvm.ID_Canbodangky);
            var _Dangkykenh = new Dangkykenh
            {
                TenNguoidangky = dangkykenhvm.TenNguoidangky,
                IdDonvi = dangkykenhvm.IdDonvi,
                UngdungId = dangkykenhvm.UngdungId,
                TenUngdung = dangkykenhvm.TenUngdung,
                IP_Ungdung = dangkykenhvm.IP_Ungdung,
                Port_Ungdung = dangkykenhvm.Port_Ungdung,
                Ngaytao = dangkykenhvm.Ngaytao,
                Ngaysua = DateTime.UtcNow,
                ID_Canbodangky = dangkykenhvm.ID_Canbodangky,
                Ngayduyet = dangkykenhvm.Ngayduyet,
                is_Delete = dangkykenhvm.is_Delete,
                Trangthai = dangkykenhvm.Trangthai,
                Log_process = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " tạo bởi: " + canbodangky.Tendaydu
            };
            _context.Add(_Dangkykenh);
            _context.SaveChanges();
            return _Dangkykenh;
        }
        // Thiết lập is_Delete=true hoặc Status=false chứ không xóa vật lý 
        public bool Delete(string id, string Tennguoixoa)
        {
            var Dangkykenh = _context.Dangkykenhs.SingleOrDefault(dk => dk.Id.ToString() == id);
            if (Dangkykenh != null)
            {
                Dangkykenh.is_Delete = true;
                Dangkykenh.Ngaysua = DateTime.UtcNow;
                Dangkykenh.Log_process = Dangkykenh.Log_process + "\r\n" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " xóa bởi: " + Tennguoixoa;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Dangkykenh> GetAll()
        {
            var Dangkykenhs = _context.Dangkykenhs.Select(Dangkykenh => Dangkykenh).Where(x => x.is_Delete == false);
            return Dangkykenhs.ToList();
        }
        public PagedList<Dangkykenh> getAll(PaginParameters paginParameters)
        {
            return PagedList<Dangkykenh>.ToPagedList(GetAll(),
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

        public List<Dangkykenh> FindAll(string searchString, string IdDonvi, DateTime from, DateTime to,int Trangthaidkkenh)
        {
            _strIdDonvi = "";
            if (searchString == null)
                searchString = "";
          
            List<Dangkykenh> Dangkykenhs = new List<Dangkykenh>();
            switch (Trangthaidkkenh)
            {
                //Chua duyet
                case 0:
                    Dangkykenhs = _context.Dangkykenhs.Select(so => so).Where(x => (x.is_Delete == false) && (x.Ngaytao >= from.AddHours(-12) && x.Ngaytao <= to.AddHours(12)) && x.Trangthai==0 && (x.TenUngdung.Contains(searchString) || x.TenNguoidangky.Contains(searchString))).ToList();
                    break;
                //Duyet
                case 1:
                    Dangkykenhs = _context.Dangkykenhs.Select(so => so).Where(x => (x.is_Delete == false) && (x.Ngaytao >= from.AddHours(-12) && x.Ngaytao <= to.AddHours(12)) && x.Trangthai == 1 && (x.TenUngdung.Contains(searchString) || x.TenNguoidangky.Contains(searchString))).ToList();
                    break;
                //Huy
                case 2:
                    Dangkykenhs = _context.Dangkykenhs.Select(so => so).Where(x => (x.is_Delete == false) && (x.Ngaytao >= from.AddHours(-12) && x.Ngaytao <= to.AddHours(12)) && x.Trangthai == 2 && (x.TenUngdung.Contains(searchString) || x.TenNguoidangky.Contains(searchString))).ToList();
                    break;
                //tat ca
                default:
                    Dangkykenhs = _context.Dangkykenhs.Select(so => so).Where(x => (x.is_Delete == false) && (x.Ngaytao >= from.AddHours(-12) && x.Ngaytao <= to.AddHours(12)) && (x.TenUngdung.Contains(searchString) || x.TenNguoidangky.Contains(searchString))).ToList();
                    break;
            }
            if (IdDonvi != null)
            {
                ProcessParentID(IdDonvi);
                var dks = Dangkykenhs.Select(x => x).Where(x => _strIdDonvi.Contains(x.IdDonvi.ToString())).ToList();
                return dks.ToList();
            }
            else
            {
                return Dangkykenhs.ToList();
            }    
                
        }
        public PagedList<Dangkykenh> findAll(PaginParameters paginParameters, string searchString, string IdDonvi,DateTime from, DateTime to, int trangthaidkkenh)
        {
            return PagedList<Dangkykenh>.ToPagedList(FindAll(searchString, IdDonvi,from, to, trangthaidkkenh),
        paginParameters.PageNumber,
        paginParameters.PageSize);
        }

        // Lấy theo Id đối tượng không tự động lấy quan hệ nếu cần thì lấy thêm đối tượng quan hệ
        public Dangkykenh GetById(string id)
        {
            var Dangkykenh = _context.Dangkykenhs.SingleOrDefault(dk => dk.Id.ToString() == id && dk.is_Delete == false);
            if (Dangkykenh != null)
            {
                _context.Entry(Dangkykenh).Reference(p => p.CanboDangky).Load();
                _context.Entry(Dangkykenh).Reference(p => p.Ungdung).Load();
            }
            return Dangkykenh;
        }
        public Dangkykenh_Duyet DuyetKenh(string idkenh, Dangkykenh_DuyetVM dangkykenhduyetvm)
        {
            var _Dangkykenh = _context.Dangkykenhs.SingleOrDefault(kenh => kenh.Id.ToString() == idkenh);

            if (_Dangkykenh != null)
            {
                Canbo canboduyet = _context.Canbos.SingleOrDefault(p => p.Id == dangkykenhduyetvm.ID_Canboduyet);
                _Dangkykenh.Trangthai = 1;
                _Dangkykenh.Ngayduyet = DateTime.UtcNow;
                _Dangkykenh.Ngaysua = DateTime.UtcNow;
                _Dangkykenh.Log_process = _Dangkykenh.Log_process + "\r\n" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " duyệt bởi: " + canboduyet.Tendaydu;
                _context.SaveChanges();
                Dangkykenh_Duyet _Dangkykenh_duyet = new Dangkykenh_Duyet();
                _Dangkykenh_duyet.Canbothamdinh = dangkykenhduyetvm.Canbothamdinh;
                _Dangkykenh_duyet.DangkykenhId = Guid.Parse(idkenh);
                _Dangkykenh_duyet.IdDonvi = _Dangkykenh.IdDonvi;
                _Dangkykenh_duyet.TenUngdung = dangkykenhduyetvm.TenUngdung;
                _Dangkykenh_duyet.IP_Internalgate = dangkykenhduyetvm.IP_Internalgate;
                _Dangkykenh_duyet.Port_Internalgate = dangkykenhduyetvm.Port_Internalgate;
                _Dangkykenh_duyet.NgayTao = DateTime.UtcNow;
                _Dangkykenh_duyet.Ngaysua = DateTime.UtcNow;
                _Dangkykenh_duyet.ID_Canboduyet = dangkykenhduyetvm.ID_Canboduyet;
                _Dangkykenh_duyet.UngdungId = dangkykenhduyetvm.UngdungId;
                _Dangkykenh_duyet.Log_process = "\r\n" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " tạo mới và duyệt bởi: " + canboduyet.Tendaydu;
                _context.Add(_Dangkykenh_duyet);
                _context.SaveChanges();
                return _Dangkykenh_duyet;
            }
            return null;
        }
        public Dangkykenh ThaydoiTrangthai(string idkenh, int trangthai, string tencanbothaydoi)
        {
            var tt = "duyệt";
            if (trangthai == 0)
                tt = "chưa duyệt";
            if (trangthai == 2)
                tt = "không duyệt";
            var _Dangkykenh = _context.Dangkykenhs.SingleOrDefault(kenh => kenh.Id.ToString() == idkenh);

            if (_Dangkykenh != null)
            {
                _Dangkykenh.Trangthai = trangthai;
                if (trangthai == 1)
                {

                    _Dangkykenh.Ngayduyet = DateTime.UtcNow;
                }
                _Dangkykenh.Ngaysua = DateTime.UtcNow;
                _Dangkykenh.Log_process = _Dangkykenh.Log_process + "\r\n" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " chuyển sang trạng thái " + tt + " bởi: " + tencanbothaydoi;
                _context.SaveChanges();
                return _Dangkykenh;
            }
            return null;
        }
        public bool Update(Dangkykenh Dangkykenh, string tennguoisua)
        {
            var _Dangkykenh = _context.Dangkykenhs.SingleOrDefault(cb => cb.Id == Dangkykenh.Id);

            if (_Dangkykenh != null)
            {
                _Dangkykenh.TenNguoidangky = Dangkykenh.TenNguoidangky;
                _Dangkykenh.IdDonvi = Dangkykenh.IdDonvi;
                _Dangkykenh.TenUngdung = Dangkykenh.TenUngdung;
                _Dangkykenh.UngdungId = Dangkykenh.UngdungId;
                _Dangkykenh.IP_Ungdung = Dangkykenh.IP_Ungdung;
                _Dangkykenh.Port_Ungdung = Dangkykenh.Port_Ungdung;
                _Dangkykenh.Ngaytao = Dangkykenh.Ngaytao;
                _Dangkykenh.Ngaysua = DateTime.UtcNow;
                _Dangkykenh.ID_Canbodangky = Dangkykenh.ID_Canbodangky;
                _Dangkykenh.is_Delete = Dangkykenh.is_Delete;
                _Dangkykenh.Ngayduyet = Dangkykenh.Ngayduyet;
                _Dangkykenh.Trangthai = Dangkykenh.Trangthai;
                _Dangkykenh.Log_process = _Dangkykenh.Log_process + "\r\n" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " chỉnh sửa bởi: " + tennguoisua;
                _context.SaveChanges();
                return true;
            }
            return false;

        }


    }
}

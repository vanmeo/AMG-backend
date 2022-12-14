using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services.Base;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services
{
    public class SoquanlykenhRepository : ISoquanlykenhRepository
    {
        private readonly MyDbContext _context;
        public SoquanlykenhRepository(MyDbContext context)
        {
            _context = context;
        }

        // Thêm mới danh mục với ViewModel cho trước
        public Soquanlykenh Add(SoquanlykenhVM soquanlykenhvm, string tencanbotaomoi)
        {
            var _Sokenh = new Soquanlykenh
            {
                Dangkykenh_DuyetId = soquanlykenhvm.Dangkykenh_DuyetId,
                IP_Internalgate = soquanlykenhvm.IP_Internalgate,
                Ten_Kihieukenh=soquanlykenhvm.Ten_Kihieukenh,
                TenUngdung = soquanlykenhvm.TenUngdung,
                IP_Ungdung = soquanlykenhvm.IP_Ungdung,
                Port_Internalgate = soquanlykenhvm.Port_Internalgate,
                Ngaytao = soquanlykenhvm.Ngaytao,
                Ngaysua = soquanlykenhvm.Ngaysua,
                UngdungId = soquanlykenhvm.UngdungId,
                Ngayvaoso = soquanlykenhvm.Ngayvaoso,
                Trangthai = soquanlykenhvm.Trangthai,
                Log_process = "\r\n" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " tạo mới bởi: " + tencanbotaomoi
            };
            _context.Add(_Sokenh);
            _context.SaveChanges();
            return _Sokenh;
        }
        // Thiết lập is_Delete=true hoặc Status=false chứ không xóa vật lý 
        public bool Delete(string id, string tencanboxoa)
        {
            var _sokenh = _context.Soquanlykenhs.SingleOrDefault(sk => sk.Id.ToString() == id);
            if (_sokenh != null)
            {
                _sokenh.is_Delete = true;
                _sokenh.Log_process = _sokenh.Log_process + "\r\n" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " xóa bởi: " + tencanboxoa;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Soquanlykenh> GetAll()
        {
            var Soquanlykenhs = _context.Soquanlykenhs.Select(DsND => DsND).Where(x => x.is_Delete == false);
            return Soquanlykenhs.ToList();
        }
        public PagedList<Soquanlykenh> getAll(PaginParameters paginParameters)
        {
            return PagedList<Soquanlykenh>.ToPagedList(GetAll(),
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
                ProcessParentID(item.Id.ToString());
            }
        }

        public List<Soquanlykenh> FindAll(string searchString, string IdDonvi, DateTime from, DateTime to, int Trangthaikenh)
        {
            _strIdDonvi = "";
            if (searchString == null)
                searchString = "";
            List<Soquanlykenh> Soquankykenhs = new List<Soquanlykenh>();
            switch (Trangthaikenh)
            {
                //Chua kich hoat
                case 0:
                    Soquankykenhs = _context.Soquanlykenhs.Select(so => so).Where(x => (x.is_Delete == false) && x.Ngaytao >= from.AddHours(-12) && x.Ngaytao <= to.AddHours(12) && (x.TenUngdung.Contains(searchString)) && x.Trangthai == 0).ToList();
                    break;
                //Da kich hoat
                case 1:
                    Soquankykenhs = _context.Soquanlykenhs.Select(so => so).Where(x => (x.is_Delete == false) && x.Ngaytao >= from.AddHours(-12) && x.Ngaytao <= to.AddHours(12) && (x.TenUngdung.Contains(searchString)) && x.Trangthai == 1).ToList();
                    break;
                //Huy kich hoat
                case 2:
                    Soquankykenhs = _context.Soquanlykenhs.Select(so => so).Where(x => (x.is_Delete == false) && x.Ngaytao >= from.AddHours(-12) && x.Ngaytao <= to.AddHours(12) && (x.TenUngdung.Contains(searchString)) && x.Trangthai == 2).ToList();
                    break;
                //tat ca
                default:
                    Soquankykenhs = _context.Soquanlykenhs.Select(so => so).Where(x => (x.is_Delete == false) && x.Ngaytao >= from.AddHours(-12) && x.Ngaytao <= to.AddHours(12) && (x.TenUngdung.Contains(searchString))).ToList();
                    break;
            }

            if (IdDonvi != null)
            {
                ProcessParentID(IdDonvi);
                var SoQLkenhs = Soquankykenhs.Select(x => x).Where(x => _strIdDonvi.Contains(x.IdDonvi.ToString())).ToList();
                return SoQLkenhs.ToList();
            }
            else
                return Soquankykenhs.ToList();
        }


        public PagedList<Soquanlykenh> findAll(PaginParameters paginParameters, string searchString, string IdDonvi, DateTime from, DateTime to, int Trangthaikenh)
        {
            return PagedList<Soquanlykenh>.ToPagedList(FindAll(searchString, IdDonvi, from, to, Trangthaikenh),
        paginParameters.PageNumber,
        paginParameters.PageSize);
        }

        // Lấy theo Id đối tượng không tự động lấy quan hệ nếu cần thì lấy thêm đối tượng quan hệ
        public Soquanlykenh GetById(string id)
        {
            var _sokenh = _context.Soquanlykenhs.SingleOrDefault(sk => sk.Id.ToString() == id && sk.is_Delete == false);
            if (_sokenh != null)
            {
                _context.Entry(_sokenh).Reference(p => p.Ungdung).Load();
                _context.Entry(_sokenh).Reference(p => p.Dangkykenh_Duyet).Load();
                //_context.Entry(_sokenh).Collection(p => p.Danhsachnguoidungs).Load();
            }
            return _sokenh;
        }
        public Soquanlykenh ThaydoiTrangthai(string idkenh, int trangthai, string tencanbo)
        {
            var _Soquanlykenh = _context.Soquanlykenhs.SingleOrDefault(kenh => kenh.Id.ToString() == idkenh);
            var tt = "chưa kích hoạt";
            if (trangthai == 1)
            {
                tt = "kích hoạt";
                _Soquanlykenh.NgayKichHoat = DateTime.UtcNow;
            }
            if (trangthai == 2)
            {
                tt = "hủy kích hoạt";
                _Soquanlykenh.NgayHuyKichHoat = DateTime.UtcNow;
            }

            if (_Soquanlykenh != null)
            {
                _Soquanlykenh.Log_process = _Soquanlykenh.Log_process + "\r\n" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " chuyển trạng thái " + tt + " bởi: " + tencanbo;
                _Soquanlykenh.Trangthai = trangthai;

                _context.SaveChanges();
                return _Soquanlykenh;
            }
            return null;
        }

        public bool Themdanhsachnguoidung(string idkenh, string idcanbotao, string filename)
        {
            var soQuanlykenh = _context.Soquanlykenhs.FirstOrDefault(x => x.Id.ToString() == idkenh&& x.Trangthai==1);
            if(soQuanlykenh!=null)
            {
                List<Danhsachnguoidung> userList = new List<Danhsachnguoidung>();
                var package = new ExcelPackage(new FileInfo(filename));
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
                for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                {
                    try
                    {
                        int j = 1;
                        string name = workSheet.Cells[i, j++].Value.ToString();
                        string sodienthoai = workSheet.Cells[i, j++].Value.ToString();
                        string SMS = workSheet.Cells[i, j++].Value.ToString();
                        bool nhansms = false;
                        if (SMS == "Có")
                            nhansms = true;
                        var nd = _context.Danhsachnguoidungs.SingleOrDefault(nd => nd.SokenhId.ToString() == idkenh && nd.Sodienthoai == sodienthoai);
                        if (nd == null)
                        {
                            Danhsachnguoidung user = new Danhsachnguoidung()
                            {
                                Ten = name,
                                Sodienthoai = sodienthoai,
                                IdDonvi = soQuanlykenh.IdDonvi,
                                SokenhId = Guid.Parse(idkenh),
                                CanboId = Guid.Parse(idcanbotao),
                                Ngaytao = DateTime.UtcNow,
                                Ngaysua = DateTime.UtcNow,
                                //Sau nho sua lai
                                Trangthai = false,
                                NhanSMS = nhansms
                            };
                            _context.Add(user);
                            _context.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
           
        }

        public bool Update(Soquanlykenh Sokenh, string tencanbosua)
        {
            var _Sokenh = _context.Soquanlykenhs.SingleOrDefault(cb => cb.Id == Sokenh.Id);
            if (_Sokenh != null)
            {
                _Sokenh.Dangkykenh_DuyetId = Sokenh.Dangkykenh_DuyetId;
                _Sokenh.IP_Internalgate = Sokenh.IP_Internalgate;
                _Sokenh.Ten_Kihieukenh = Sokenh.Ten_Kihieukenh;
                _Sokenh.TenUngdung = Sokenh.TenUngdung;
                _Sokenh.IP_Ungdung = Sokenh.IP_Ungdung;
                _Sokenh.Port_Internalgate = Sokenh.Port_Internalgate;
                _Sokenh.Ngaytao = Sokenh.Ngaytao;
                _Sokenh.Ngaysua = Sokenh.Ngaysua;
                _Sokenh.UngdungId = Sokenh.UngdungId;
                _Sokenh.Ngayvaoso = Sokenh.Ngayvaoso;
                _Sokenh.Trangthai = Sokenh.Trangthai;
                _Sokenh.Log_process += "\r\n" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " chỉnh sửa bởi: " + tencanbosua;
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public bool AddArray(string idkenh, List<NguoidungMobile> DS, string idcanbotao)
        {
            var soQuanlykenh = _context.Soquanlykenhs.FirstOrDefault(x => x.Id.ToString() == idkenh&& x.Trangthai==1);
            if (soQuanlykenh != null)
            {
                List<Danhsachnguoidung> userList = new List<Danhsachnguoidung>();
                try
                {
                    foreach (var item in DS)
                    {
                        var nd = _context.Danhsachnguoidungs.SingleOrDefault(nd => nd.SokenhId.ToString() == idkenh && nd.Sodienthoai == item.SDT);
                        if (nd == null)
                        {
                            Danhsachnguoidung user = new Danhsachnguoidung()
                            {
                                Ten = item.Ten,
                                Sodienthoai = item.SDT,
                                IdDonvi = soQuanlykenh.IdDonvi,
                                SokenhId = Guid.Parse(idkenh),
                                CanboId = Guid.Parse(idcanbotao),
                                Ngaytao = DateTime.UtcNow,
                                Ngaysua = DateTime.UtcNow,
                                //Sau nho sua lai thanh false dang de luon kich hoat
                                Trangthai = false,
                                NhanSMS = item.SendSMS
                            };
                            _context.Add(user);
                            _context.SaveChanges();
                        }
                    }
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
            else
                return false;
           
        }

        public bool checkTenKenh(string tenKenh)
        {
            var _Sokenh = _context.Soquanlykenhs.SingleOrDefault(cb => cb.Ten_Kihieukenh == tenKenh);
            if (_Sokenh != null)
                return true;
            else
                return false;
        }
    }
}

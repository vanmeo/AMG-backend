﻿using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services
{
    public class Dangkykenh_DuyetRepository : IDangkykenh_DuyetRepository
    {
        private readonly MyDbContext _context;
        public Dangkykenh_DuyetRepository(MyDbContext context)
        {
            _context = context;
        }
        // Thêm mới danh mục với ViewModel cho trước
        public Dangkykenh_Duyet Add(Dangkykenh_DuyetVM dangkykenhduyetvm)
        {
            var _Dangkykenh_duyet = new Dangkykenh_Duyet
            {
                Canbothamdinh = dangkykenhduyetvm.Canbothamdinh,
                DangkykenhId = dangkykenhduyetvm.DangkykenhId,
                TenUngdung = dangkykenhduyetvm.TenUngdung,
                IP_Internalgate = dangkykenhduyetvm.IP_Internalgate,
                Port_Internalgate = dangkykenhduyetvm.Port_Internalgate,
                NgayTao = DateTime.UtcNow,
                Ngaysua = DateTime.UtcNow,
                ID_Canboduyet = dangkykenhduyetvm.ID_Canboduyet,
                UngdungId = dangkykenhduyetvm.UngdungId
            };
            _context.Add(_Dangkykenh_duyet);
            _context.SaveChanges();
            return _Dangkykenh_duyet;
        }
        // Thiết lập is_Delete=true hoặc Status=false chứ không xóa vật lý 
        public bool Delete(string id, string tennguoixoa)
        {
            var Dangkykenh = _context.Dangkykenhs.SingleOrDefault(dk => dk.Id.ToString() == id);
            if (Dangkykenh != null)
            {
                Dangkykenh.is_Delete = true;
                Dangkykenh.Ngaysua = DateTime.UtcNow;
                Dangkykenh.Log_process=Dangkykenh.Log_process+  "\r\n" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " xóa bởi: " + tennguoixoa;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Dangkykenh_Duyet> GetAll()
        {
            var Dangkykenh_duyets = _context.Dangkykenh_Duyets.Select(Dangkykenh => Dangkykenh).Where(x => x.is_Delete == false);
            return Dangkykenh_duyets.ToList();
        }
        // Lấy theo Id đối tượng không tự động lấy quan hệ nếu cần thì lấy thêm đối tượng quan hệ
        public Dangkykenh_Duyet GetById(string id)
        {
            var Dangkykenh_duyet = _context.Dangkykenh_Duyets.SingleOrDefault(dk => dk.Id.ToString() == id && dk.is_Delete == false);
            if (Dangkykenh_duyet != null)
            {
                _context.Entry(Dangkykenh_duyet).Reference(p => p.CanboDuyet).Load();
                _context.Entry(Dangkykenh_duyet).Reference(p => p.Ungdung).Load();
                _context.Entry(Dangkykenh_duyet).Reference(p => p.Dangkykenh).Load();
            }
            return Dangkykenh_duyet;
        }
        public bool Update(Dangkykenh_Duyet Dangkykenh_duyet, string tencanbosua)
        {
            var _Dangkykenh_duyet = _context.Dangkykenh_Duyets.SingleOrDefault(cb => cb.Id == Dangkykenh_duyet.Id);
            if (_Dangkykenh_duyet != null)
            {
                _Dangkykenh_duyet.Canbothamdinh = Dangkykenh_duyet.Canbothamdinh;
                _Dangkykenh_duyet.DangkykenhId = Dangkykenh_duyet.DangkykenhId;
                _Dangkykenh_duyet.TenUngdung = Dangkykenh_duyet.TenUngdung;
                _Dangkykenh_duyet.IP_Internalgate = Dangkykenh_duyet.IP_Internalgate;
                _Dangkykenh_duyet.Port_Internalgate = Dangkykenh_duyet.Port_Internalgate;
                _Dangkykenh_duyet.NgayTao = Dangkykenh_duyet.NgayTao;
                _Dangkykenh_duyet.Ngaysua = DateTime.UtcNow;
                _Dangkykenh_duyet.ID_Canboduyet = Dangkykenh_duyet.ID_Canboduyet;
                _Dangkykenh_duyet.UngdungId = Dangkykenh_duyet.UngdungId;
                _Dangkykenh_duyet.Log_process =_Dangkykenh_duyet.Log_process+ "\r\n" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " chỉnh sửa bởi: " + tencanbosua;
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public Soquanlykenh Vaosoquanlykenh(string idkenhduyet, SoquanlykenhVM soquanlykenh,string tencanbovaoso)
        {
            var _Dangkykenh_duyet = _context.Dangkykenh_Duyets.SingleOrDefault(kenh => kenh.Id.ToString() == idkenhduyet);
           
            if (_Dangkykenh_duyet != null)
            {
                _Dangkykenh_duyet.Trangthai = true;
                _Dangkykenh_duyet.Ngaysua = DateTime.UtcNow;
                _Dangkykenh_duyet.Log_process= _Dangkykenh_duyet.Log_process+ "\r\n" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " Vào sổ quản lý bởi: " + tencanbovaoso;
                _context.SaveChanges();
                Soquanlykenh _so = new Soquanlykenh();
                _so.TenUngdung = soquanlykenh.TenUngdung;
                _so.Trangthai = 0;
                _so.TenDonVi = _Dangkykenh_duyet.TenDonVi;
                _so.UngdungId = soquanlykenh.UngdungId;
                _so.IP_Internalgate = soquanlykenh.IP_Internalgate;
                _so.IP_Ungdung = soquanlykenh.IP_Ungdung;
                _so.Port_Ungdung = soquanlykenh.Port_Ungdung;
                _so.Port_Internalgate = soquanlykenh.Port_Internalgate;
                _so.Ngaytao = DateTime.UtcNow;
                _so.Ngayvaoso = DateTime.UtcNow;
                _so.Ngaysua = DateTime.UtcNow;
                _so.is_Delete = false;
                _so.Dangkykenh_DuyetId = _Dangkykenh_duyet.Id;
                _so.Log_process = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " tạo mới vào sổ bởi: " + tencanbovaoso;
                _context.Add(_so);
                _context.SaveChanges();
                return _so;
            }
            return null;
        }

    }
}

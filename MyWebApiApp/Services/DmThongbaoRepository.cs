﻿using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services.Base;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AMGAPI.Services
{
    public class DmThongbaoRepository : IDmThongbaoRepository
    {
        private readonly MyDbContext _context;
        private readonly SMSService _smsservice;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly Datadiodeconfig _Datadiodeconfig;

        public DmThongbaoRepository(MyDbContext context, IOptionsMonitor<Datadiodeconfig> optionsMonitorDatadiode, IOptionsMonitor<SMSService> optionsMonitor, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _smsservice = optionsMonitor.CurrentValue;
            _Datadiodeconfig = optionsMonitorDatadiode.CurrentValue;
            _webHostEnvironment = webHostEnvironment;
        }
        // Thêm mới danh mục với ViewModel cho trước
        public DmThongbao Add(DmThongbaoVM dmthongbaovm)
        {
            if (CheckQuyen(dmthongbaovm))
            {
                var _Thongbao = new DmThongbao
                {
                    SoquanlykenhId = Guid.Parse(dmthongbaovm.SoquanlykenhId),
                    Noidungtinnhan = dmthongbaovm.Noidungtinnhan,
                    Sodienthoainhan = dmthongbaovm.Sodienthoainhan,
                    Ngaytao = DateTime.UtcNow
                };
                _context.Add(_Thongbao);
                _context.SaveChanges();
                return _Thongbao;
            }
            else
                return null;

        }
        public List<DmThongbao> GetAll()
        {
            var Thongbaos = _context.DmThongbaos.Select(tb => tb);
            return Thongbaos.ToList();
        }
        public bool CheckQuyen(DmThongbaoVM Thongbao)
        {
            var soquanly = _context.Soquanlykenhs.SingleOrDefault(sokenh => sokenh.Id.ToString() == Thongbao.SoquanlykenhId);
            if (soquanly != null)
            {
                if (soquanly.Trangthai == 1)
                    return true;
                else
                    return false;
            }

            else
                return false;
        }
        public bool sendsms(string Sodienthoaigui, string IdKenh, string tieude, string sms, string DsSdtnhan)
        {
           
            try
            {
                var soquanly = _context.Soquanlykenhs.SingleOrDefault(sokenh => sokenh.Id.ToString() == IdKenh && sokenh.Trangthai == 1);
                string _DSNhan = "";
                foreach (var item in DsSdtnhan.Split(','))
                {
                    var nguoidung = _context.Danhsachnguoidungs.SingleOrDefault(ND => ND.SokenhId.ToString() == IdKenh && ND.Sodienthoai == item);
                    if (soquanly != null && nguoidung != null)
                    {
                        if (nguoidung.NhanSMS)
                        {
                            string strURL = _smsservice + "u=tckt&pw=tckt-sms&c=" + sms + "&no=" + item;          //BTL86                                                    
                            WebClient wc = new WebClient();
                            Stream stream = wc.OpenRead(strURL);

                        }
                        else
                        {

                            var _Thongbao = new DmThongbao
                            {
                                SoquanlykenhId = Guid.Parse(IdKenh),
                                Sodienthoaigui = Sodienthoaigui,
                                Noidungtinnhan = sms,
                                Tieudetinnhan = tieude,
                                Sodienthoainhan = item,
                                Ngaytao = DateTime.UtcNow,
                                Trangthai = nguoidung.Trangthai
                            };
                            if (nguoidung.Trangthai)
                                _DSNhan += "," + item;
                            _context.Add(_Thongbao);
                            _context.SaveChanges();
                           
                        }
                    }
                }
                if (_DSNhan != "")
                    _DSNhan.Substring(1, _DSNhan.Length);
                return true;
            }
            catch 
            {

                return false;
            }
            
        }

        public bool sendsmsfile(string Sodienthoaigui, string tieude, string IdKenh, string sms, string DSsdtnhan, List<IFormFile> Files)
        {
            try
            {
                var soquanly = _context.Soquanlykenhs.SingleOrDefault(sokenh => sokenh.Id.ToString() == IdKenh && sokenh.Trangthai == 1);
                // var nguoidung = _context.Danhsachnguoidungs.SingleOrDefault(ND => ND.SokenhId.ToString() == IdKenh && ND.Sodienthoai == DSsdtnhan);
                string _DSNhan = "";
                foreach (var item in DSsdtnhan.Split(','))
                {
                    var nguoidung = _context.Danhsachnguoidungs.SingleOrDefault(ND => ND.SokenhId.ToString() == IdKenh && ND.Sodienthoai == item);
                    if (soquanly != null && nguoidung != null)
                    {
                        if (nguoidung.NhanSMS)
                        {
                            string strURL = _smsservice + "u=tckt&pw=tckt-sms&c=" + sms + "&no=" + item;          //BTL86                                                    
                            WebClient wc = new WebClient();
                            Stream stream = wc.OpenRead(strURL);
                        }
                        else
                        {
                            var _Thongbao = new DmThongbao
                            {
                                SoquanlykenhId = Guid.Parse(IdKenh),
                                Sodienthoaigui = Sodienthoaigui,
                                Noidungtinnhan = sms,
                                Tieudetinnhan = tieude,
                                Sodienthoainhan = item,
                                Ngaytao = DateTime.UtcNow,
                                Trangthai = nguoidung.Trangthai
                            };
                            if (nguoidung.Trangthai)
                                _DSNhan += "," + item;
                            _context.Add(_Thongbao);
                            _context.SaveChanges();
                            foreach (var file in Files)
                            {
                                string filepath = Path.Combine(_webHostEnvironment.ContentRootPath, "FileThongBao", file.FileName);
                                using (var stream = new FileStream(filepath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                }
                                if (nguoidung.Trangthai)
                                {
                                    string filepathdiode = Path.Combine(_Datadiodeconfig.FileSms, file.FileName);
                                    using (var stream = new FileStream(filepathdiode, FileMode.Create))
                                    {
                                        file.CopyTo(stream);
                                    }
                                }
                                var _Thongbao_file = new DmThongbao_File
                                {
                                    IdThongbao = _Thongbao.Id,
                                    File_Url = filepath,
                                    TenFile = file.FileName
                                };
                                _context.Add(_Thongbao_file);
                                _context.SaveChanges();
                            }
                        }
                    }

                }
                return true;
            }
            catch
            {

                return false;
            }
           
        }
    }
}


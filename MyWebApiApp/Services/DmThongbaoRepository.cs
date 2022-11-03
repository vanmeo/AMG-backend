using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services.Base;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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
        private double filesizeMax;
        private bool TrangthaiSMSservices;

        // private readonly Datadiodeconfig _Datadiodeconfig;

        //public DmThongbaoRepository(MyDbContext context, IOptionsMonitor<Datadiodeconfig> optionsMonitorDatadiode, IOptionsMonitor<SMSService> optionsMonitor, IWebHostEnvironment webHostEnvironment)
        public DmThongbaoRepository(MyDbContext context, IOptionsMonitor<SMSService> optionsMonitor, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _smsservice = optionsMonitor.CurrentValue;
            // _Datadiodeconfig = optionsMonitorDatadiode.CurrentValue;
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
        public bool sendsms(string Sodienthoaigui, string tenKenh, string tieude, string sms, string DsSdtnhan)
        {
            try
            {
                var soquanly = _context.Soquanlykenhs.SingleOrDefault(sokenh => sokenh.Ten_Kihieukenh == tenKenh && sokenh.Trangthai == 1);
                if (soquanly == null)
                    return false;
                else
                {
                    string _DSNhan = "";
                    tieude = xulynoidungtinnhan(tieude);
                    sms = xulynoidungtinnhan(sms);
                    foreach (var item in DsSdtnhan.Split(','))
                    {
                        string IdKenh = soquanly.Id.ToString();
                        var nguoidung = _context.Danhsachnguoidungs.SingleOrDefault(ND => ND.SokenhId.ToString() == IdKenh && ND.Sodienthoai == item);
                        if (soquanly != null && nguoidung != null)
                        {
                            if (nguoidung.NhanSMS&&TrangthaiSMSservices)
                            {
                                string strURL = _smsservice.services + "u=tckt&pw=tckt&c=" + sms + "&no=" + item;          //BTL86                                                    
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

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string xulynoidungtinnhan(string sms)
        {
            var dmblackword = _context.dmBlackWords.Select(bw => bw);
            ThongsoHethong ht = _context.ThongsoHethongs.SingleOrDefault();
            TrangthaiSMSservices = ht.TrangThaiSMS;
            if (ht.KichthuocFilesMax != 0)
                filesizeMax = ht.KichthuocFilesMax;
            else
                filesizeMax = 0;

            foreach (var item in dmblackword)
            {
                sms = sms.Replace(item.Word, "");
            }
            return sms;
        }

        public bool sendsmsfile(string Sodienthoaigui, string tieude, string TenKenh, string sms, string DSsdtnhan, List<IFormFile> Files)
        {
            tieude = xulynoidungtinnhan(tieude);
            sms = xulynoidungtinnhan(sms);
            if (Files.Count <= 0)
            {
                sendsms(Sodienthoaigui, TenKenh, tieude, sms, DSsdtnhan);
                return true;
            }
            else
            {
                if (filesizeMax > 0)
                {
                    foreach (var file in Files)
                    {

                        if (file.Length > filesizeMax)
                        {
                            return false;
                        }
                    }
                }
                else
                    return false;
                try
                {
                    var soquanly = _context.Soquanlykenhs.SingleOrDefault(sokenh => sokenh.Ten_Kihieukenh == TenKenh && sokenh.Trangthai == 1);
                    // var nguoidung = _context.Danhsachnguoidungs.SingleOrDefault(ND => ND.SokenhId.ToString() == IdKenh && ND.Sodienthoai == DSsdtnhan);
                    //string _DSNhan = "";
                    //string _PubKeyNhan = "";
                   
                    foreach (var item in DSsdtnhan.Split(','))
                    {
                        if (soquanly != null)
                        {
                            string IdKenh = soquanly.Id.ToString();
                            var nguoidung = _context.Danhsachnguoidungs.SingleOrDefault(ND => ND.SokenhId.ToString() == IdKenh && ND.Sodienthoai == item);

                            if (nguoidung != null)
                            {

                                if (nguoidung.NhanSMS&&TrangthaiSMSservices)
                                {
                                    string strURL = _smsservice.services + "u=tckt&pw=tckt-sms&c=" + sms + "&no=" + item;          //BTL86                                                    
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
                                    //if (nguoidung.Trangthai)
                                    //{
                                    //    _DSNhan += "," + item;
                                    //    if (nguoidung.Public_Key != null)
                                    //        _PubKeyNhan += "," + nguoidung.Public_Key;
                                    //}
                                    _context.Add(_Thongbao);
                                    _context.SaveChanges();
                                    foreach (var file in Files)
                                    {
                                        //Hàm mã hóa file thực hiện ở đây với Pubkey key nguoi dung
                                        // Lưu file trong thư mục web
                                        string fileName = Path.GetFileNameWithoutExtension(file.FileName) + DateTime.Now.ToString().Replace(" ", "").Replace("/", "").Replace(":", "") + Path.GetExtension(file.FileName);
                                        string filepath = Path.Combine(_webHostEnvironment.ContentRootPath, "FileThongBao", fileName);
                                        using (var stream = new FileStream(filepath, FileMode.Create))
                                        {
                                            file.CopyTo(stream);
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
                    }
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }

            }

        }

    }

}
using AspNetCore.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services.Base;
using AspNetCore.Reporting.ReportExecutionService;

namespace AMGAPI.Services
{
    public class ReportRepository : IReportRepository
    {
        private readonly MyDbContext _context;

        public ReportRepository(MyDbContext context)
        {
            _context = context;
        }

        public byte[] BaocaoChitiet1Kenh(string reportType, string IdKenh)
        {
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("AMGAPI.dll", string.Empty);
            string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, "Ga_bc_chitiet1kenh");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");
            LocalReport report = new LocalReport(rdlcFilePath);
            Soquanlykenh so=_context.Soquanlykenhs.SingleOrDefault(so => so.Id.ToString() == IdKenh);
            Dangkykenh_Duyet dkkenh_duyet = _context.Dangkykenh_Duyets.SingleOrDefault(dk_d => dk_d.Id == so.Dangkykenh_DuyetId);
            Dangkykenh dkkenh = _context.Dangkykenhs.SingleOrDefault(dk => dk.Id ==dkkenh_duyet.DangkykenhId);
            Canbo Canbodk = _context.Canbos.SingleOrDefault(cb => cb.Id == dkkenh.ID_Canbodangky);
            Canbo Canboduyet = _context.Canbos.SingleOrDefault(cb => cb.Id == dkkenh_duyet.ID_Canboduyet);
            DmDonvi donviduyet = _context.DmDonvis.SingleOrDefault(dv => dv.Id == Canboduyet.DonviId);
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("TenUngdung", dkkenh.TenUngdung);
            var Thongtindangky = "Tên ứng dụng:" + so.TenUngdung + "\nĐịa chỉ IP, Port:" + so.IP_Ungdung + "," + so.Port_Ungdung +
                "\nNgày đăng ký: " + dkkenh.Ngaytao.ToString("dd/M/yyyy") + "; Người đăng ký: " + Canbodk.Tendaydu + "\nĐơn vị đăng ký: " + dkkenh.TenDonvi;
            parameters.Add("Thongtindangky", Thongtindangky);
            var trangthai = "";
            switch (so.Trangthai)
            {
                default:
                case 0:
                    trangthai = "Chưa Kích hoạt";
                    break;
                case 1:
                    trangthai = "Đang hoạt động";
                    break;
                case 2:
                    trangthai = "Hủy Kích hoạt";
                    break;
            }
            var Thongtinduyet = "Ngày duyệt:"+dkkenh_duyet.NgayTao.ToString("dd/M/yyyy") + "\nNgười duyệt: "+Canboduyet.Tendaydu+"\nĐơn vị duyệt: "+donviduyet.Ten+"\nĐịa chỉ cổng tiếp nhận, IP và port: "+so.IP_Internalgate+", "+so.Port_Internalgate;
            parameters.Add("Thongtinduyet", Thongtinduyet);
         
            var Thongtinhoatdong = "Ngày vào sổ: "+so.Ngayvaoso.ToString("dd/M/yyyy") + "\nNgày kích hoạt: "+ so.Ngaytao.ToString("dd/M/yyyy")+" Ngày hủy kích hoạt: "+ so.Ngaysua.ToString("dd/M/yyyy") + "\nTrạng thái hoạt động: "+ trangthai+"\nTần suấ(số tin nhắn gửi/ngày) trong 10 ngày gần đây:";
            parameters.Add("Thongtinhoatdong", Thongtinhoatdong);
            var result = report.Execute(GetRenderType(reportType), 1, parameters);
            return result.MainStream;
        }

        public byte[] BaocaoTongHopSoKenh(string reportType)
        {
            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("AMGAPI.dll", string.Empty);
            string rdlcFilePath = string.Format("{0}ReportFiles\\{1}.rdlc", fileDirPath, "Ga_bc_tonghop");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("utf-8");
            LocalReport report = new LocalReport(rdlcFilePath);
            // prepare data for report
            List<Ga_bc_tonghop> Bctonghop = new List<Ga_bc_tonghop>();
            int STT = 0;
            var Ga_bc_tonghops = from so in _context.Soquanlykenhs
                                 join kenh_duyet in _context.Dangkykenh_Duyets on so.Dangkykenh_DuyetId equals kenh_duyet.Id
                                 select new
                                 {
                                     DangkykenhId = kenh_duyet.DangkykenhId,
                                     TenUngdung = so.TenUngdung,
                                     Ngayvaoso = so.Ngayvaoso,
                                     Ngayduyet = kenh_duyet.NgayTao,
                                     Ip_Ungdung = so.IP_Ungdung,
                                     Port_Ungdung = so.Port_Ungdung,
                                     Trangthai = so.Trangthai
                                 } into DSkenhduyet
                                 join Dkkenh in _context.Dangkykenhs on DSkenhduyet.DangkykenhId equals Dkkenh.Id
                                 // where p.ProductId == 2
                                 select new
                                 {
                                     Donvi = Dkkenh.TenDonvi,
                                     TenUngdung = DSkenhduyet.TenUngdung,
                                     Ngayvaoso = DSkenhduyet.Ngayvaoso,
                                     Ngayduyet = DSkenhduyet.Ngayduyet,
                                     Ip_Ungdung = DSkenhduyet.Ip_Ungdung,
                                     Port_Ungdung = DSkenhduyet.Port_Ungdung,
                                     Trangthai = DSkenhduyet.Trangthai,
                                     Ngaydangky = Dkkenh.Ngaytao
                                 };
            foreach (var item in Ga_bc_tonghops)
            {
                STT = STT + 1;
                Ga_bc_tonghop th = new Ga_bc_tonghop();
                th.STT = STT.ToString();
                th.Thongtinkenh = "Tên ứng dụng: " + item.TenUngdung + "; Địa chỉ IP: " + item.Ip_Ungdung + "; Port: " + item.Port_Ungdung + "; Ngày đăng ký: " + item.Ngaydangky + "; Ngày duyệt: " + item.Ngayduyet + "; Ngày vào sổ:" + item.Ngayvaoso;
                th.Donvi = item.Donvi;
                switch (item.Trangthai)
                {
                    default:
                    case 0:
                        th.Trangthai = "Chưa Kích hoạt";
                        break;
                    case 1:
                        th.Trangthai = "Đang hoạt động";
                        break;
                    case 2:
                        th.Trangthai = "Hủy Kích hoạt";
                        break;
                }
                Bctonghop.Add(th);
            }
            report.AddDataSource("DataSet1", Bctonghop);
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            var result = report.Execute(GetRenderType(reportType), 1, parameters);
            return result.MainStream;
        }

        private RenderType GetRenderType(string reportType)
        {
            var renderType = RenderType.Pdf;

            switch (reportType.ToUpper())
            {
                default:
                case "PDF":
                    renderType = RenderType.Pdf;
                    break;
                case "XLS":
                    renderType = RenderType.Excel;
                    break;
                case "WORD":
                    renderType = RenderType.Word;
                    break;
            }

            return renderType;
        }

    }
}

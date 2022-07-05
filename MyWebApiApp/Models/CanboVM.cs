using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Models
{
    public class CanboVM
    {
        public string Tendaydu { get; set; }
        public string Tendangnhap { get; set; }
        public string Matkhau { get; set; }
        public string? Email { get; set; }
        public string? Dienthoai_mobile { get; set; }
        public string? Dienthoai_cd1 { get; set; }
        public string? Dienthoai_cd2 { get; set; }
        public string? Dienthoai_cd3 { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string? Anhdaidien_ten { get; set; }
        public string? Anhdaidien_url { get; set; }
        public Guid DonviId { get; set; }
        public Guid ChucvuId { get; set; }
        public Guid CapbacId { get; set; }
        public Guid RoleId { get; set; }
        //public Guid DmCDDHId { get; set; }
        [Required]
        [DefaultValue(true)]
        public bool Status { get; set; }
        public string Publickey_value { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Publickey_status { get; set; }
    }
}

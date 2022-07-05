using AMGAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data
{
    [Table("Canbo")]
    public class Canbo
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Tendaydu { get; set; }
        [Required]
        [StringLength(100)]
        public string Tendangnhap { get; set; }
        [StringLength(100)]
        [Required]
        public string Matkhau { get; set; }
        [StringLength(100)]
        public string? Email { get; set; }
        [Required]
        [StringLength(10)]
        public string? Dienthoai_mobile { get; set; }
        [StringLength(10)]
        public string? Dienthoai_cd1 { get; set; }
        [StringLength(10)]
        public string? Dienthoai_cd2 { get; set; }
        [StringLength(10)]
        public string? Dienthoai_cd3 { get; set; }
        public DateTime? Ngaysinh { get; set; }
        [StringLength(100)]
        public string? Anhdaidien_ten { get; set; }
        public string? Anhdaidien_url { get; set; }
        public Guid DonviId { get; set; }
        public Guid ChucvuId { get; set; }
        public Guid CapbacId { get; set; }
        public Guid RoleId { get; set; }
        //public Guid DmCDDHId { get; set; }
        public bool Status { get; set; }
        public string Publickey_value { get; set; }
        public bool Publickey_status { get; set; }
        //relationship
        public virtual DmDonvi Donvi { get; set; }
        public virtual DmCapbac Capbac { get; set; }
        public virtual DmChucvu Chucvu { get; set; }
        public virtual DmRole Role { get; set; }
      

    }
}

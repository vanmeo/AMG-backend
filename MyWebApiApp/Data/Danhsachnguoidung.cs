using AMGAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data
{
    [Table("Danhsachnguoidung")]
    public class Danhsachnguoidung
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Ten { get; set; }

        [Required]
        [StringLength(10)]
        public string Sodienthoai { get; set; }
        //Lấy đơn vị theo sổ kênh
        public Guid IdDonvi { get; set; }
        public Guid SokenhId { get; set; }
        //public Guid ChucvuId { get; set; }
        //public Guid CapbacId { get; set; }
        //Id can bo tao
        public Guid CanboId { get; set; }
        [Required]
        [DefaultValue("false")]
        public bool NhanSMS { get; set; }
        public DateTime? Ngaytao { get; set; }
        public DateTime? Ngaysua { get; set; }
       
        public string? Public_Key  { get; set; }
        public bool Trangthai { get; set; }
        //relationship
        public virtual Soquanlykenh Sokenh { get; set; }
       
        public virtual Canbo Canbo { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data
{
    [Table("Soquanlykenh")]
    public class Soquanlykenh
    {
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid Dangkykenh_DuyetId { get; set; }
        [Required]
        [StringLength(100)]
        public string TenUngdung { get; set; }
        [Required]
        public Guid UngdungId { get; set; }
        [Required]
        public Guid CanboId { get; set; }
        [Required]
        [StringLength(20)]
        public string IP_Internalgate { get; set; }
        public string TenDonVi { get; set; }
        public int Port_Internalgate { get; set; }
        public string IP_Ungdung { get; set; }
        public int Port_Ungdung { get; set; }
        public DateTime Ngayvaoso { get; set; }
        [Description("Luu trang thai: 0_chuakichhoat; 1_da kichhoat;2: huy_kichhoat")]
        [Required]
        [DefaultValue("0")]
        public int Trangthai { get; set; }
        public DateTime Ngaytao{ get; set; }
        public DateTime Ngaysua { get; set; }
        public DateTime NgayKichHoat { get; set; }
        public DateTime NgayHuyKichHoat { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool is_Delete { get; set; }
        public string? Log_process { get; set; }
        //relationship
        public virtual DmUngdung Ungdung { get; set; }
        [ForeignKey("Dangkykenh_DuyetId")]
        public virtual Dangkykenh_Duyet Dangkykenh_Duyet { get; set; }
        public virtual List<DmThongbao> Thongbaos { get; set; }
        //public virtual List<Danhsachnguoidung> Danhsachnguoidungs { get; set; }
    }
}

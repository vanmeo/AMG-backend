using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data
{
    [Table("DmThongbao")]
    public class DmThongbao
    {
        [Key]
        public Guid Id { get; set; }
        public Guid SoquanlykenhId { get; set; }
        public string Tieudetinnhan { get; set; }
        [Required]
        public string Noidungtinnhan { get; set; }
        [StringLength(11)]
        public string Sodienthoaigui { get; set; }
        [Required]
        [StringLength(11)]
        public string Sodienthoainhan { get; set; }
       [DefaultValue(false)]
        // 1: Cho gui
        // 0: so dien thoai nhan chua kich hoat
        public bool Trangthai { get; set; }
        public DateTime Ngaytao { get; set; }
        //relationship
        public virtual Soquanlykenh Soquanlykenh { get; set; }
    }
}

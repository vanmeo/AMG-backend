using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Models
{
    public class DangkykenhVM
    {
        public string TenNguoidangky { get; set; }
        
        public string TenDonvi { get; set; }
        [Required]
        [StringLength(100)]
        public string TenUngdung { get; set; }
        [Required]
        public Guid UngdungId { get; set; }
        [Required]
        [StringLength(20)]
        public string IP_Ungdung { get; set; }
        public int Port_Ungdung { get; set; }
        public Guid ID_Canbodangky { get; set; }
        public DateTime Ngaytao { get; set; }
        public DateTime Ngaysua { get; set; }
        [Description("Luu trang thai: 0_chua duyet; 1_da duyet;2: huy_dki")]
        [Required]
        public int Trangthai { get; set; }
        public DateTime? Ngayduyet { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool is_Delete { get; set; }
    }
}

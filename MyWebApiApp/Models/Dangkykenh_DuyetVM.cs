using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Models
{
    public class Dangkykenh_DuyetVM
    {
        public Guid DangkykenhId { get; set; }
        [Required]
        [StringLength(100)]
        public string TenUngdung { get; set; }
        [Required]
        public Guid IdDonvi { get; set; }
        //public string TenDonvi { get; set; }
        [Required]
        public Guid UngdungId { get; set; }
        [Required]
        [StringLength(20)]
        public string IP_Internalgate { get; set; }
        public int Port_Internalgate { get; set; }
        public string? Canbothamdinh { get; set; }
        public Guid? ID_Canboduyet { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime Ngaysua { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool is_Delete { get; set; }
        [Required]
        [DefaultValue(false)]
        //0: chua tao so; 1 da tao so
        public bool Trangthai { get; set; }

    }
}

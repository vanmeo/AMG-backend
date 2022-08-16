using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Models
{
    public class SoquanlykenhVM
    {
        public Guid Dangkykenh_DuyetId { get; set; }
        [Required]
        public Guid IdDonvi { get; set; }
        //public string TenDonvi { get; set; }
        public string TenUngdung { get; set; }
        public Guid UngdungId { get; set; }
        public string IP_Internalgate { get; set; }
        public int Port_Internalgate { get; set; }
        public string IP_Ungdung { get; set; }
        public int Port_Ungdung { get; set; }
        public DateTime Ngayvaoso { get; set; }
        public int Trangthai { get; set; }
        public DateTime Ngaytao { get; set; }
        public DateTime Ngaysua { get; set; }
    }
}

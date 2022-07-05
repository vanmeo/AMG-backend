using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Models
{
    public class DanhsachnguoidungVM
    {
        public string Ten { get; set; }
        public string Sodienthoai { get; set; }
        public Guid SokenhId { get; set; }
        public Guid CanboId { get; set; }
        public DateTime? Ngaytao { get; set;}
        public DateTime? Ngaysua { get; set;}
    }
}

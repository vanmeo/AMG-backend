using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Models
{
    public class DmChucvuVM
    {
        public string Ten { get; set; }
        public string Viettat { get; set; }
        public string? Ghichu { get; set; }
        [Required]
        [DefaultValue(true)]
        public bool Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Models
{
    public class DmDonviVM
    {
        public Guid? ParentId { get; set; }
        public string? Ma { get; set; }
        public string Ten { get; set; }
        public string Viettat { get; set; }
        public string? Ghichu { get; set; }
        [Required]
        [DefaultValue(true)]
        public bool Status { get; set; }
    }
}

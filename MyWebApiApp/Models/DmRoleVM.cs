using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Models
{
    public class DmRoleVM
    {
        public string Ten { get; set; }
        public string? Ghichu { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool is_Delete { get; set; }
    }
}

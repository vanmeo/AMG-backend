using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Models
{
    public class DmFeatureVM
    {
        public string Ten { get; set; }
        public string Viettat { get; set; }
        public string Ghichu { get; set; }
        public Guid AppId { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool is_Delete { get; set; }
    }
}

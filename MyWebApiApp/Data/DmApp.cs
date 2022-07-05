using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data
{
    [Table("DmApp")]
    public class DmApp
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Ten { get; set; }
        public string? Viettat { get; set; }
        [StringLength(100)]
        public string? Ghichu { get; set; }
        [Required]
        [DefaultValue("false")]
        public bool is_Delete { get; set; }
        //relationship
        public virtual ICollection<DmFeature> Features { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data
{
    [Table("DmChucvu")]
    public class DmChucvu
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Ten { get; set; }
        [StringLength(100)]
        public string Viettat { get; set; }

        public string? Ghichu { get; set; }
        [Required]
        [DefaultValue("true")]
        public bool Status { get; set; }
        public virtual ICollection<Canbo> Canbos { get; set; }
        public DmChucvu()
        {
            Canbos = new HashSet<Canbo>();
        }

    }
}

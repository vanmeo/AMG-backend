using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data
{
    [Table("DmCapbac")]
    public class DmCapbac
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Ten { get; set; }
        [Required]
        [StringLength(100)]
        public string Viettat { get; set; }
        public string? Ghichu { get; set; }
        [Required]
        [DefaultValue("true")]
        public bool Status { get; set; }
        //relationship
        public virtual ICollection<Canbo> Canbos { get; set; }
       
    }
}

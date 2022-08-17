using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data
{
    [Table("DmDonvi")]
    public class DmDonvi
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        [StringLength(100)]
        public string? Ma { get; set; }
        [Required]
        [StringLength(100)]
        public string Ten { get; set; }
        [StringLength(100)]
        public string Viettat { get; set; }
        public string Ghichu { get; set; }
        [Required]
        [DefaultValue("true")]
        public bool Status { get; set; }
        public virtual ICollection<Canbo> Canbos { get; set; }
        public virtual Dangkykenh Dangkykenh { get; set; }
        public virtual Dangkykenh_Duyet Dangkykenh_duyet { get; set; }
        public virtual Soquanlykenh Soquanlykenh { get; set; }
        public DmDonvi()
        {
            Canbos = new HashSet<Canbo>();
        }

    }
}

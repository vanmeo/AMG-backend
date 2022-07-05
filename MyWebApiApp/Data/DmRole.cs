using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data
{
    [Table("DmRole")]
    public class DmRole
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Ten { get; set; }

        public string? Ghichu { get; set; }
        [Required]
        [DefaultValue("false")]
        public bool is_Delete { get; set; }
        public virtual ICollection<DmRole_Feature> Role_Features { get; set; }
        public virtual ICollection<Canbo> Canbos { get; set; }
        public DmRole()
        {
            Role_Features = new HashSet<DmRole_Feature>();
            Canbos = new HashSet<Canbo>();
        }

    }
}

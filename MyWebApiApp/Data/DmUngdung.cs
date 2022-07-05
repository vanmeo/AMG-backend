using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data
{
    [Table("DmUngdung")]
    public class DmUngdung
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
        public virtual List<Dangkykenh> Dangkykenhs { get; set; }
        public virtual List<Dangkykenh_Duyet> Dangkykenh_Duyets { get; set; }
        public virtual List<Soquanlykenh> Soquanlykenhs {get; set;}

    }
}

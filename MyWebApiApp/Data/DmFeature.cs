using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data
{
    [Table("DmFeature")]
    public class DmFeature
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Ten { get; set; }
        [StringLength(100)]
        public string? Viettat { get; set; }
        public string? Ghichu { get; set; }
        public Guid AppId { get; set; }
        [DefaultValue("false")]
        public bool is_Delete { get; set; }
        //relationship
        public virtual DmApp App { get; set; }
    }
}

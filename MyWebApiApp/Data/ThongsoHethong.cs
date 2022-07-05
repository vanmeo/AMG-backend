using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data
{
    [Table("ThongsoHethong")]
    public class ThongsoHethong
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int TansuatQuet_Phut { get; set; }
        [Required]
        [StringLength(50)]
        public string Datadiode_IP { get; set; }
        [Required]
        public int Datadiode_Port{ get; set; }
        [StringLength(500)]
        public string? Datadiode_Token { get; set; }
        public byte TanSuatXoanhatky_ngay { get; set; }
        public byte KichthuocFilesMax { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data
{
    [Table("DmThongbao_File")]
    public class DmThongbao_File
    {
        [Key]
        public Guid Id { get; set; }
        public Guid IdThongbao { get; set; }
        [Required]
        [StringLength(500)]
        public string File_Url { get; set; }
        [Required]
        [StringLength(100)]
        public string TenFile { get; set; }
        //relationship
        public virtual DmThongbao Thongbao { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data
{
    [Table("Dangkykenh_Duyet")]
    public class Dangkykenh_Duyet
    {
        [Key]
        public Guid Id { get; set; }
        public Guid DangkykenhId { get; set; }
        [Required]
        [StringLength(100)]
        public string TenUngdung { get; set; }
        [Required]
        public Guid UngdungId { get; set; }
        [Required]
        [StringLength(20)]
        public string IP_Internalgate { get; set; }
        public string TenDonVi { get; set; }
        public int Port_Internalgate { get; set; }
        public string? Canbothamdinh { get; set; }
        public Guid? ID_Canboduyet { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime Ngaysua { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool is_Delete { get; set; }
        [Required]
        [DefaultValue(false)]
        //0: chua vao so; 1:vao so
        public bool Trangthai { get; set; }
        public string? Log_process { get; set; }
        //relationship
        public virtual DmUngdung Ungdung { get; set; }
        [ForeignKey("ID_Canboduyet")]
        public virtual Canbo CanboDuyet { get; set; }
        [ForeignKey("DangkykenhId")]
        public virtual Dangkykenh Dangkykenh { get; set; }
    }
}

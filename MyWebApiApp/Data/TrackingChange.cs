using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace AMGAPI.Data
{
    [Table("TrackingChange")]
    public class TrackingChange
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int IDBang { get; set; }
        [Required]
        [StringLength(60)]
        public string ID_ROW { get; set; }

        [Required]
        //0 update, 1 insert
        public int Status { get; set; }

    }
}

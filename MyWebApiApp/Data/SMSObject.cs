using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data
{
    [Table("SMSObject")]
    public class SMSObject
    {
        public int idBang { get; set; }
        public string TenKenh { get; set; }
        public string tieude { get; set; }
        public string noidung { get; set; }
        public string sdtnhan { get; set; }
        public string sdtgui { get; set; }
        public List<string> DSTenfile { get; set; }
        public DateTime CreateDate { get; set; }
    }
}

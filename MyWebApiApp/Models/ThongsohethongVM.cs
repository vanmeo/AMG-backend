using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Models
{
    public class ThongsohethongVM
    {
        public int TansuatQuet_Phut { get; set; }
        public string Datadiode_IP { get; set; }
        public int Datadiode_Port { get; set; }
        public string Datadiode_Token { get; set; }
        public byte TanSuatXoanhatky_ngay { get; set; }
        public byte KichthuocFilesMax { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Models
{
    public class Role_Feature
    {
        public string Ten { get; set; }
        public string AppId { get; set; }
        public bool AllowView { get; set; }
        public bool AllowEdit { get; set; }
        public bool AllowDelete { get; set; }
        public bool AllowAdd { get; set; }
        public bool AllowDuyet { get; set; }
    }
}

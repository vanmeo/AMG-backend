using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Models
{
    public class DmRole_FeatureVM
    {
     
        public Guid FeatureId { get; set; }
        public Guid RoleId { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool AllowView { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool AllowEdit { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool AllowDelete { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool AllowAdd { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool AllowDuyet { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool is_Delete { get; set; }
    }
}

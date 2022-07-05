using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data
{
    [Table("DmRole_Feature")]
    public class DmRole_Feature
    {
        [Key]
        public Guid Id { get; set; }
        public Guid FeatureId { get; set; }
        public Guid RoleId { get; set; }
        [DefaultValue("false")]
        public bool AllowView { get; set; }
        [DefaultValue("false")]
        public bool AllowEdit { get; set; }
        [DefaultValue("false")]
        public bool AllowDelete { get; set; }
        [DefaultValue("false")]
        public bool AllowAdd { get; set; }
        [DefaultValue("false")]
        public bool AllowDuyet { get; set; }
        [DefaultValue("false")]
        public bool is_Delete { get; set; }
        //relationship
        public virtual DmRole Role { get; set; }
        public virtual DmFeature Feature { get; set; }
    }
}

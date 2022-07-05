using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Models
{
    public class App_RoleFeature
    {
        public string tenApp { get; set; }
        public List<Role_Feature> role_features { get; set; }
        public App_RoleFeature()
        {
            role_features = new List<Role_Feature>();
        }
    }
}

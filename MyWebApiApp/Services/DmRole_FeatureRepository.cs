using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services
{
    public class DmRole_FeatureRepository : IDmRole_FeatureRepository
    {
        private readonly MyDbContext _context;

        public DmRole_FeatureRepository(MyDbContext context)
        {
            _context = context;
        }
        public DmRole_Feature Add(DmRole_FeatureVM dmrole_featurevm)
        {
            var _DmRole_Feature = new DmRole_Feature
            {
                RoleId = dmrole_featurevm.RoleId,
                FeatureId = dmrole_featurevm.FeatureId,
                AllowAdd = dmrole_featurevm.AllowAdd,
                AllowDelete = dmrole_featurevm.AllowDelete,
                AllowEdit = dmrole_featurevm.AllowEdit,
                AllowView = dmrole_featurevm.AllowView,
                AllowDuyet = dmrole_featurevm.AllowDuyet,
            };
            _context.Add(_DmRole_Feature);
            _context.SaveChanges();
            return _DmRole_Feature;
        }
        // Thiết lập is_Delete=true hoặc Status=false chứ không xóa vật lý 
        public bool Delete(string id)
        {
            var role_feature = _context.DmRole_Features.SingleOrDefault(cb => cb.Id.ToString() == id);
            if (role_feature != null)
            {
                role_feature.is_Delete = true;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<DmRole_Feature> GetAll()
        {
            var role_features = _context.DmRole_Features.Select(Dmrole_feature => Dmrole_feature).Where(x => x.is_Delete == false);
            return role_features.ToList();
        }
        // Lấy theo Id đối tượng không tự động lấy quan hệ nếu cần thì lấy thêm đối tượng quan hệ
        public DmRole_Feature GetById(string id)
        {
            var role_Feature = _context.DmRole_Features.SingleOrDefault(cb => cb.Id.ToString() == id && cb.is_Delete == false);
            if (role_Feature != null)
            {
                _context.Entry(role_Feature).Reference(p => p.Role).Load();
                _context.Entry(role_Feature).Reference(p => p.Feature).Load();
            }
            return role_Feature;
        }

        public bool Update(DmRole_Feature Role_Feature)
        {
            var _Role_Feature = _context.DmRole_Features.SingleOrDefault(cb => cb.Id == Role_Feature.Id);

            if (_Role_Feature != null)
            {
                _Role_Feature.RoleId = Role_Feature.RoleId;
                _Role_Feature.FeatureId = Role_Feature.FeatureId;
                _Role_Feature.AllowAdd = Role_Feature.AllowAdd;
                _Role_Feature.AllowEdit = Role_Feature.AllowEdit;
                _Role_Feature.AllowDelete = Role_Feature.AllowDelete;
                _Role_Feature.AllowView = Role_Feature.AllowView;
                _Role_Feature.is_Delete = Role_Feature.is_Delete;
                _Role_Feature.AllowDuyet = Role_Feature.AllowDuyet;
                _context.SaveChanges();
                return true;
            }
            return false;

        }


    }
}

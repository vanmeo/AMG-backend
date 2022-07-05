using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services
{
    public class DmFeatureRepository : IDmFeatureRepository
    {
        private readonly MyDbContext _context;

        public DmFeatureRepository(MyDbContext context)
        {
            _context = context;
        }
        public DmFeature Add(DmFeatureVM dmfeaturevm)
        {
            var _DmFeature = new DmFeature
            {
                Ten = dmfeaturevm.Ten,
                Viettat = dmfeaturevm.Viettat,
                Ghichu = dmfeaturevm.Ghichu,
                AppId = dmfeaturevm.AppId,
                is_Delete = dmfeaturevm.is_Delete
            };
            _context.Add(_DmFeature);
            _context.SaveChanges();
            return _DmFeature;
        }
        // Thiết lập is_Delete=true hoặc Status=false chứ không xóa vật lý 
        public bool Delete(string id)
        {
            var feature = _context.DmFeatures.SingleOrDefault(cb => cb.Id.ToString() == id);
            if (feature != null)
            {
                feature.is_Delete = true;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public List<DmFeature> GetAll()
        {
            var features = _context.DmFeatures.Select(FT => FT).Where(x => x.is_Delete == false);
            return features.ToList();
        }
        // Lấy theo Id đối tượng không tự động lấy quan hệ nếu cần thì lấy thêm đối tượng quan hệ
        public DmFeature GetById(string id)
        {
            var feature = _context.DmFeatures.SingleOrDefault(cb => cb.Id.ToString() == id && cb.is_Delete == false);
            if (feature != null)
                _context.Entry(feature).Reference(p => p.App).Load();
            return feature;
        }
        public bool Update(DmFeature Feature)
        {
            var _Feature = _context.DmFeatures.SingleOrDefault(cb => cb.Id == Feature.Id);
            if (_Feature != null)
            {
                _Feature.Ten = Feature.Ten;
                _Feature.AppId = Feature.AppId;
                _Feature.Ghichu = Feature.Ghichu;
                _Feature.Viettat = Feature.Viettat;
                _Feature.is_Delete = Feature.is_Delete;
                _context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}

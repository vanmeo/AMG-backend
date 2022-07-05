using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services.Base;

namespace AMGAPI.Services
{
    public class CanboRepository : ICanboRepository
    {
        private readonly MyDbContext _context;

        public CanboRepository(MyDbContext context)
        {
            _context = context;
        }
        // Thêm mới danh mục với ViewModel cho trước
        public Canbo Add(CanboVM canbovm)
        {
            var _Canbo = new Canbo
            {
                Tendangnhap = canbovm.Tendangnhap,
                Matkhau = canbovm.Matkhau,
                Tendaydu = canbovm.Tendaydu,
                Email = canbovm.Email,
                Status = canbovm.Status,
                Dienthoai_mobile = canbovm.Dienthoai_mobile,
                Dienthoai_cd1 = canbovm.Dienthoai_cd1,
                Dienthoai_cd2 = canbovm.Dienthoai_cd2,
                Dienthoai_cd3 = canbovm.Dienthoai_cd3,
                Anhdaidien_ten = canbovm.Anhdaidien_ten,
                Anhdaidien_url = canbovm.Anhdaidien_url,
                CapbacId = canbovm.CapbacId,
                ChucvuId = canbovm.ChucvuId,
                DonviId = canbovm.DonviId,
                RoleId = canbovm.RoleId
            };
            _context.Add(_Canbo);
            _context.SaveChanges();
            return _Canbo;
        }
        public bool Delete(string id)
        {
            var Canbo = _context.Canbos.SingleOrDefault(cb => cb.Id.ToString() == id);
            if (Canbo != null)
            {
                Canbo.Status = false;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Canbo> GetAll()
        {
            var Canbos = _context.Canbos.Select(Canbo => Canbo).Where(x => x.Status == true);
            return Canbos.ToList();
        }
        // Thiết lập is_Delete=true hoặc Status=false chứ không xóa vật lý 
        public Canbo GetById(string id)
        {
            var Canbo = _context.Canbos.SingleOrDefault(nd => nd.Id.ToString() == id);
            if (Canbo != null)
            {
                _context.Entry(Canbo).Reference(p => p.Donvi).Load();
                _context.Entry(Canbo).Reference(p => p.Capbac).Load();
                _context.Entry(Canbo).Reference(p => p.Chucvu).Load();
            }
            return Canbo;
        }
        // Sử dụng khi thực hiện Login
        public Canbo GetByLoginModel(LoginModel model)
        {
            var _Canbo = _context.Canbos.SingleOrDefault(p => p.Tendangnhap == model.UserName && model.Password == p.Matkhau);
            _Canbo.Role = _context.DmRoles.SingleOrDefault(p => p.Id == _Canbo.Id);
            // Lay thong tin de hien thi menu frontend
            //_Canbo.App_Rolefeatues = GetRolebyCanboId(_Canbo);
            return _Canbo;
        }
        // Sử dụng để lấy các quyền tương ứng với từng feature của app ứng với nhóm quyền user thuộc về
        public List<App_RoleFeature> GetAppRoleFeaturebyCanboId(string idCanbo)
        {
            Canbo cb = _context.Canbos.SingleOrDefault(nd => nd.Id.ToString() == idCanbo);
            if (cb != null)
            {
                List<App_RoleFeature> DSApp_roleFeatures = new List<App_RoleFeature>();
                foreach (var item in _context.DmApps.Select(app => app).Where(x => x.is_Delete == false).ToList())
                {
                    App_RoleFeature role_app = new App_RoleFeature();
                    role_app.tenApp = item.Ten;
                    var role_features = (from RF in _context.DmRole_Features
                                         where RF.RoleId == cb.RoleId
                                         join F in _context.DmFeatures on RF.FeatureId equals F.Id
                                         select new Role_Feature
                                         {
                                             Ten = F.Ten,
                                             AppId = F.AppId.ToString(),
                                             AllowAdd = RF.AllowAdd,
                                             AllowEdit = RF.AllowEdit,
                                             AllowDelete = RF.AllowDelete,
                                             AllowDuyet = RF.AllowDuyet,
                                             AllowView = RF.AllowView
                                         }).Where(x => x.AppId == item.Id.ToString()).ToList();
                    role_app.role_features = role_features;
                    DSApp_roleFeatures.Add(role_app);
                }
                return DSApp_roleFeatures;
            }
            else
                return null;


        }
        public bool Update(Canbo Canbo)
        {
            var _Canbo = _context.Canbos.SingleOrDefault(nd => nd.Id == Canbo.Id);

            if (_Canbo != null)
            {
                _Canbo.Tendangnhap = Canbo.Tendangnhap;
                _Canbo.Matkhau = Canbo.Matkhau;
                _Canbo.Tendaydu = Canbo.Tendaydu;
                _Canbo.Email = Canbo.Email;
                _Canbo.Status = Canbo.Status;
                _Canbo.Dienthoai_mobile = Canbo.Dienthoai_mobile;
                _Canbo.Dienthoai_cd1 = Canbo.Dienthoai_cd1;
                _Canbo.Dienthoai_cd2 = Canbo.Dienthoai_cd2;
                _Canbo.Dienthoai_cd3 = Canbo.Dienthoai_cd3;
                _Canbo.Anhdaidien_ten = Canbo.Anhdaidien_ten;
                _Canbo.Anhdaidien_url = Canbo.Anhdaidien_url;
                _Canbo.CapbacId = Canbo.CapbacId;
                _Canbo.ChucvuId = Canbo.ChucvuId;
                _Canbo.DonviId = Canbo.DonviId;
                _Canbo.RoleId = Canbo.RoleId;
                _context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}


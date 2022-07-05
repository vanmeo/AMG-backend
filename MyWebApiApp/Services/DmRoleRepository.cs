using AMGAPI.Data;
using AMGAPI.Models;
using AMGAPI.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Services
{
    public class DmRoleRepository : IDmRoleRepository
    {
        private readonly MyDbContext _context;

        public DmRoleRepository(MyDbContext context)
        {
            _context = context;
        }
        public DmRole Add(DmRoleVM rolevm)
        {
            var _Role = new DmRole
            {
                Ten = rolevm.Ten,
                Ghichu = rolevm.Ghichu,
                is_Delete = rolevm.is_Delete
            };
            _context.Add(_Role);
            _context.SaveChanges();

            return _Role;
        }
        // Thiết lập is_Delete=true hoặc Status=false chứ không xóa vật lý 
        public bool Delete(string id)
        {
            var role = _context.DmRoles.SingleOrDefault(cb => cb.Id.ToString() == id);
            if (role != null)
            {
                role.is_Delete = true;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<DmRole> GetAll()
        {
            var DmRole = _context.DmRoles.Select(role => role).Where(x => x.is_Delete == false);
            return DmRole.ToList();
        }
        // Lấy theo Id đối tượng không tự động lấy quan hệ nếu cần thì lấy thêm đối tượng quan hệ
        public DmRole GetById(string id)
        {
            var DmRole = _context.DmRoles.SingleOrDefault(cb => cb.Id.ToString() == id && cb.is_Delete == false);
            if (DmRole != null)
                _context.Entry(DmRole).Collection(p => p.Role_Features).Load();
            return DmRole;
        }

        public bool Update(DmRole Role)
        {
            var _role = _context.DmRoles.SingleOrDefault(role => role.Id == Role.Id);

            if (_role != null)
            {
                _role.Ten = Role.Ten;
                _role.Ghichu = Role.Ghichu;
                _role.is_Delete = Role.is_Delete;
                _context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}

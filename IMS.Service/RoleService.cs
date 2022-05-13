using IMS.DataAccess;
using IMS.DataAccess.Database;
using IMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service
{
    public class  RoleService
    {
        public readonly RoleProvider _roleProvider;
        public RoleService()
        {
            _roleProvider = new RoleProvider();
        }

        public List<RoleModel> GetAllRoles()
        {
            var roles = _roleProvider.GetAllRoles();
            return roles;
        }

        public RoleModel GetRolesById()
        {
            var data = _roleProvider.GetRolesById();
            RoleModel role = new RoleModel()
            {
                Id = data.RoleId,
                Name = data.RoleName,
                RoleCode = data.RoleCode,
                IsActive = data.IsActive
            };
            return role;
        }
        public webpages_Roles GetRolesByName(string roleName)
        {
            return _roleProvider.GetRolesByName(roleName);
        }
    }
}

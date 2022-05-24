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
    public class  RolesService
    {
        public readonly RolesProvider _roleProvider;
        public RolesService()
        {
            _roleProvider = new RolesProvider();
        }

        public List<RolesModel> GetAllRoles()
        {
            var roles = _roleProvider.GetAllRoles();
            return roles;
        }
        public webpages_Roles GetRolesById(int id)
        {

            return _roleProvider.GetRolesById(id);
        }

        public RolesModel GetRolesById()
        {
            var data = _roleProvider.GetRolesById();
            RolesModel role = new RolesModel()
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

        public webpages_Roles CreateRole(webpages_Roles role)
        {
            return _roleProvider.CreateRole(role);
        }
    }
}

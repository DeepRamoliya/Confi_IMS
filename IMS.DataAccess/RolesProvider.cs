using IMS.DataAccess.Database;
using IMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess
{
    public class RolesProvider:BaseProvider
    {
        public RolesProvider()
        {

        }
        public webpages_Roles GetRolesById(int id)
        {
            return _db.webpages_Roles.Find(id);
        }
        public webpages_Roles GetRolesById()
        {
            var userId = (from user in _db.User
                          where user.EmailId == SessionHelper.EmailId
                          select user.Id).FirstOrDefault();
            return _db.webpages_Roles.Find(userId);
        }
        public List<RolesModel> GetAllRoles()
        {
            var data = (from a in _db.webpages_Roles
                        select new RolesModel
                        {
                            Id = a.RoleId,
                            Name = a.RoleName,
                            RoleCode = a.RoleCode,
                            IsActive = a.IsActive
                        }).ToList();

            return data;
        }
        public webpages_Roles GetRolesByName(string roleName)
        {
            return _db.webpages_Roles.Where(x => x.RoleName == roleName).FirstOrDefault();
        }

        public webpages_Roles CreateRole(webpages_Roles role)
        {
            webpages_Roles _webpages_Roles = new webpages_Roles()
            {
               RoleId = role.RoleId,
               RoleName = role.RoleName,
               RoleCode = role.RoleCode,
               IsActive = role.IsActive,
               UpdatedOn=DateTime.Now,
               UpdatedBy = SessionHelper.RoleId,
            };

            _db.webpages_Roles.Add(_webpages_Roles);
            _db.SaveChanges();

            return role;
        }
    }

}


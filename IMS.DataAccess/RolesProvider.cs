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
    }

}


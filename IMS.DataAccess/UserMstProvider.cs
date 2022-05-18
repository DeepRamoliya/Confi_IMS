using IMS.DataAccess.Database;
using IMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess
{
    public class UserMstProvider : BaseProvider
    {
        public List<User> GetAllUser()
        {
            var User = _db.User.ToList();
            return User;
        }

        public User GetUserById(int id)
        {
            return _db.User.Find(id);
        }
        public User UpdateUsersRole(User pur)
        {
            UserRoleMapping _userRoleMapping= new UserRoleMapping();
            {
                _userRoleMapping.RoleId = pur.Role;
                _userRoleMapping.UserId = pur.Id;
            }
            _db.UserRoleMapping.Add(_userRoleMapping);
            _db.SaveChanges();

            return pur;
        }

        public List<DropDownList> BindRole()
        {
            return _db.webpages_Roles.Where(s => s.IsActive == true).Select(x => new DropDownList { Key = x.RoleName, Value = x.RoleId }).ToList();
        }

        public User DeleteUser(int id)
        {
            var s =_db.User.Find(id);
            _db.User.Remove(s);
            _db.SaveChanges();
            return s;
        }
    }
}

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
            webpages_UsersInRoles _webpages_UsersInRoles = new webpages_UsersInRoles();
            {
                _webpages_UsersInRoles.RoleId = pur.Role;
                _webpages_UsersInRoles.UserId = pur.Id;
            }
            _db.webpages_UsersInRoles.Add(_webpages_UsersInRoles);
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

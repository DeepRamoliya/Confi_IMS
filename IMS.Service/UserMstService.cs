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
    public class UserMstService
    {
        private readonly UserMstProvider userMstProvider;
        public UserMstService()
        {
            userMstProvider = new UserMstProvider();
        }
        public List<User> GetAllUser()
        {
            return userMstProvider.GetAllUser();   
        }

        public User GetUserById(int id)
        {
            return userMstProvider.GetUserById(id);
        }

        public User UpdateUsersRole(User pur)
        {
            return userMstProvider.UpdateUsersRole(pur);
        }

        public List<DropDownList> BindRole()
        {
            return userMstProvider.BindRole();
        }

        public User DeleteUser(int id)
        {
            return userMstProvider.DeleteUser(id);
        }
    }
}

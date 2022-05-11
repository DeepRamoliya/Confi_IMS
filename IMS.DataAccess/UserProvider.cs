using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.DataAccess.Database;

namespace IMS.DataAccess
{
    class UserProvider : BaseProvider
    {
        public UserProvider()
        {

        }

        public User GetUserById(int Id)
        {
            return _db.User.Where(a => a.Id == Id).FirstOrDefault();
        }
        public User GetUserByEmailId(string emailId)
        {
            return _db.User.Where(a => a.EmailId == emailId && a.IsActive && !a.IsDeleted).FirstOrDefault();
        }
    }
}
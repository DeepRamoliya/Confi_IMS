using IMS.DataAccess.Database;
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
            /* var objpur = GetRoleById(pur.id);
             objpur.Purchase_Product = pur.Purchase_Product;
             objpur.Purchase_Quntity = pur.Purchase_Quntity; 

             _db.SaveChanges();
             return pur;*/
            webpages_UsersInRoles _webpages_UsersInRoles = new webpages_UsersInRoles()
            {
                UserId = pur.Id,
                RoleId = pur.Role,
                };

                _db.Purchase.Add(_Purchase);
                _db.SaveChanges();

                return objPurchase;
            }
        }
    }
}

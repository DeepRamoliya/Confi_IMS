using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Database
{
    public class UserRoleMapping
    {
        public int id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }
}

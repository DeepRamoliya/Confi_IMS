using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Database
{
    public class webpages_UsersInRoles
    {
        [Key]
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}

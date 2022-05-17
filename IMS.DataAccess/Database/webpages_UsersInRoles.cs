using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Database
{
    public class webpages_UsersInRoles
    {
        [Key]
        [Display(Name ="User Id")]
        public int UserId { get; set; }
        [Display(Name = "Role Id")]
        public int RoleId { get; set; }
    }
}

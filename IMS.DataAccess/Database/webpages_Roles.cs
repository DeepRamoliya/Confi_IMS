using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Database
{
    public class webpages_Roles
    {
        [Key]
        public int RoleId { get; set; }
        [Display(Name = "Role Name")]
        [Required]
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Role Code")]
        [Required]
        public string RoleCode { get; set; }
        [Display(Name = "Update By")]
        public int UpdatedBy { get; set; }
        [Display(Name = "Update On")]
        public DateTime UpdatedOn { get; set; }

    }
}

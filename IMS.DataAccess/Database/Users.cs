using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Database
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; } 
        public string Designation { get; set; }
        public int? UpdatedBy { get; set; }
        //public DateTime UpdatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsEmailVerified { get; set; }
        public Guid? ActivationCode { get; set; }
        public string ResetPasswordCode { get; set; }
    }
}

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
        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Email Id")]
        [Required]
        public string EmailId { get; set; }
        [Display(Name = "Mobile No")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid Number")]
        public string MobileNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public string Designation { get; set; }
        [Display(Name = "Updated By")]
        public int? UpdatedBy { get; set; }
        //public DateTime UpdatedOn { get; set; }
        [Display(Name = "Created By")]
        public int? CreatedBy { get; set; }
        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password" , ErrorMessage ="Password and confirm Password are not same ")]
        public string ConfirmPassword { get; set; }
        public bool IsEmailVerified { get; set; }
        public Guid? ActivationCode { get; set; }
        public string ResetPasswordCode { get; set; }

        public int Role { get; set; }
    }
}

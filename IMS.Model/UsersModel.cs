using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IMS.Model
{
    class UsersModel
    {
        public UsersModel()
        {
            _RoleList = new List<SelectListItem>();
            _DefaultFormList = new List<SelectListItem>();

        }
        public int Id { get; set; }

        [Required]
        [Display(Name = "User Name")]
        // [Remote("CheckDuplicateUserName", "Users", HttpMethod = "Post", AdditionalFields = "UserId")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Only Letters and Spaces are allowed")]
        public string Name { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "EmailId Required.")]
        [DataType(DataType.EmailAddress)]
        //[Remote("CheckDuplicateUserEmail", "Users", HttpMethod = "Post", AdditionalFields = "UserId")]
        public string EmailId { get; set; }

        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string MobileNo { get; set; }

        public string Role { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Designation { get; set; }
        public int UpdatedBy { get; set; }
        //public DateTime UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Confirm password and password do not match")]
        public string ConfirmPassword { get; set; }
        public bool IsEmailVerified { get; set; }
        public Guid? ActivationCode { get; set; }
        public string ResetPasswordCode { get; set; }

        public List<SelectListItem> _RoleList { get; set; }
        public List<SelectListItem> _DefaultFormList { get; set; }


    }
}

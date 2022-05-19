using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Database
{
    public class FormMst
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Navigate URL")]
        public string NavigateURL { get; set; }
        [Display(Name = "Parent FormId")]
        public int? ParentFormId { get; set; }
        [Display(Name = "Form Access Code")]
        [Required]
        public string FormAccessCode { get; set; }
        [Display(Name = "Display Order")]
        public int? DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public bool IsDisplayMenu { get; set; }
        [Display(Name = "Created By")]
        public int? CreatedBy { get; set; }
        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }
        [Display(Name = "Updated By")]
        public int? UpdatedBy { get; set; }
        [Display(Name = "Update On")]
        public DateTime? UpdatedOn { get; set; }
    }
}

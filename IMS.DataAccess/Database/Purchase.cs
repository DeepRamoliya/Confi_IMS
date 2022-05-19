using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Database
{
    public class Purchase
    {

        public int id { get; set; }
        [Required]
        [Display(Name = "Purchase Product")]
        public string Purchase_Product { get; set; }
        [Required]
        [Display(Name = "Product Quntity")]
        public string Purchase_Quntity { get; set; }
        [Required]
        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime Purchase_date { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Database
{
    public class Sale
    {
        public int id { get; set; }
        [Display(Name = "Sale Product")]
        [Required]
        public string Sale_Product { get; set; }
        [Display(Name = "Sale Quntity")]
        [Required]
        public string Sale_Quntity { get; set; }
        [Display(Name = "Sale Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime Sale_date { get; set; }

    }
}

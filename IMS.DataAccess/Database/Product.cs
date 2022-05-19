using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Database
{
    public class Product
    {
        public int id { get; set; }

        [Display(Name = "Product Name ")]
        [Required]
        public string Product_Name { get; set; }
        [Display(Name = "Product Quntity")]
        [Required]
        public string Product_Quntity { get; set; }
    }
}

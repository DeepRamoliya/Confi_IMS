﻿using System;
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
        [Display(Name = "Purchase Product")]
        public string Purchase_Product { get; set; }

        [Display(Name = "Product Quntity")]
        public string Purchase_Quntity { get; set; }

        [Display(Name = "Date")]
        public System.DateTime Purchase_date { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Model
{
    public class AuthorizeFormAccess
    {
        public enum FormAccessCode
        {
            PRODUCT = 1,
            PURCHASE_PRODUCT = 2,
            SALE_PRODUCT = 3,
            ROLE_MASTER = 4,
            FORM_MASTER = 5,
            USER_MASTER = 6,
            
        }
    }
}

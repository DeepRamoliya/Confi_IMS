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

            CATEGORY = 1,
            EMPLOYEE = 2,
            INWARD = 3,
            PRODUCT = 4,
            DASHBOARD = 5,
            COMMONLOOKUP = 6,
            SUPPLIER = 7,
            DEPARTMENT = 8,
            STATUS = 9,
            PRODUCTEMPLOYEEMAPPING = 10,
            FORMMASTER = 11,
            ROLE = 12,
            USER = 13,
        }
    }
}

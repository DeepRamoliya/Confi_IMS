using IMS.Model;
using IMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Confi_IMS.Controllers
{

    [Authorize]
    public class BaseController : Controller
    {
        private readonly FormRoleMappingService _formService;
        public BaseController()
        {
            _formService = new FormRoleMappingService();
        }
        [AllowAnonymous]
        public ActionResult AccessDenied()
        {
            return View();
        }

        public bool CheckPermission(string formCode, string formAction)
        {
            var checkPermission = _formService.CheckFormAccess(formCode);
            if (checkPermission != null)
            {
                if (formAction == AccessPermission.IsAdd)
                {
                    return checkPermission.AllowInsert;
                }
                else if (formAction == AccessPermission.IsEdit)
                {
                    return checkPermission.AllowUpdate;
                }
                else if (formAction == AccessPermission.IsDelete)
                {
                    return checkPermission.AllowDelete;
                }
                else if (formAction == AccessPermission.IsMenu)
                {
                    return checkPermission.AllowMenu;
                }
                else if (formAction == AccessPermission.IsView)
                {
                    return checkPermission.AllowView;
                }
                else if (string.IsNullOrWhiteSpace(formAction))
                {
                    if (checkPermission.AllowInsert || checkPermission.AllowUpdate)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}

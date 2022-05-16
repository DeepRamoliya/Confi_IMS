using IMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMS.Model;

namespace Confi_IMS.Controllers
{
    public class RolesController : BaseController
    {
        private readonly RolesService _rolesService;
        public RolesController()
        {
            _rolesService = new RolesService();
        }
        public ActionResult Index(int? page)
        {
            /*if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.ROLE.ToString(), AccessPermission.IsView))
            {
                return RedirectToAction("AccessDenied", "Base");
            }*/
            List<RolesModel> RoleList = _rolesService.GetAllRoles();
            return View(RoleList);
        }
    }
}
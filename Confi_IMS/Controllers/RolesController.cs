using IMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMS.Model;
using IMS.DataAccess.Database;

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
           /* if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.ROLE_MASTER.ToString(), AccessPermission.IsView))
            {
                return RedirectToAction("AccessDenied", "Base");
            }*/
            List<RolesModel> RoleList = _rolesService.GetAllRoles();
            return View(RoleList);
        }

        public ActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRole(webpages_Roles role)
        {
            _rolesService.CreateRole(role);
            return RedirectToAction("Index");
        }
    }
}
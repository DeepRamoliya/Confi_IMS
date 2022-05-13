using IMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace Confi_IMS.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        private readonly IMS.Service.RoleService _rolesService;
        public RoleController()
        {
            _rolesService = new IMS.Service.RoleService();
        }
        public ActionResult Index(int page)
        {
            List<RoleModel> RoleList = _rolesService.GetAllRoles();
            return View(RoleList);
        }

       
    }
}
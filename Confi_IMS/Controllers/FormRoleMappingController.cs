using IMS.Model;
using IMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace Confi_IMS.Controllers
{
    public class FormRoleMappingController : BaseController
    {

        private readonly FormRoleMappingService _formRoleMapping;
        private readonly RolesService _roleService;
        public FormRoleMappingController()
        {
            _roleService = new RolesService();
            _formRoleMapping = new FormRoleMappingService();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewPermission(int Id = 0)
        {

            string role = _roleService.GetRolesById().Name;
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.USER_MASTER.ToString(), AccessPermission.IsEdit))
            {
                return RedirectToAction("AccessDenied", "Base");
            }

            FormRoleMappingModel model = new FormRoleMappingModel();
            if (Id > 0)
            {
                model.RoleId = Id;
                model.RoleName = _roleService.GetRolesById().Name;
            }
            
            List<FormRoleMappingModel> Formrolemapping = FormRoleMapping_Read(model.RoleId);
            var roleName = _roleService.GetRolesById(model.RoleId);
            ViewBag.Role = roleName.RoleCode;
            return View(Formrolemapping);
        }
        public JsonResult UpdatePermission(IEnumerable<FormRoleMappingModel> rolerights)
        {
            int CreatedBy = SessionHelper.UserId;
            int UpdatedBy = SessionHelper.UserId;
            var result = _formRoleMapping.UpdateRoleRights(rolerights, CreatedBy, UpdatedBy);
            if (result)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public List<FormRoleMappingModel> FormRoleMapping_Read(int RoleID)
        {
            var getrolerights = _formRoleMapping.GetAllRoleRightsById(RoleID).ToList();
            return getrolerights;

        }
    }
}
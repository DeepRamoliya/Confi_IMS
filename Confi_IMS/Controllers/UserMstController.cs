using IMS.DataAccess;
using IMS.DataAccess.Database;
using IMS.Model;
using IMS.Service;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Confi_IMS.Controllers
{
    public class UserMstController : BaseController
    {
        // GET: UserMst
        private readonly UserMstService userMstService;
        public UserMstController()
        {
            userMstService = new UserMstService();
        }

        public ActionResult DisplayUserRoleMapping()
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.USER_MASTER.ToString(), AccessPermission.IsView))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            List<User> UserList = userMstService.GetAllUser();
            return View(UserList);
        }
        public ActionResult EditUserRoleMapping(int id)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.USER_MASTER.ToString(), AccessPermission.IsEdit))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            Confi_IMSEntities _db = new Confi_IMSEntities();
            ViewBag.RoleList = userMstService.BindRole();
            User user = userMstService.GetUserById(id);
            return View(user);
        }


        [HttpPost]
        public ActionResult EditUserRoleMapping(User pur)
        {
            User objPurchaseModel = userMstService.UpdateUsersRole(pur);
            return RedirectToAction("DisplayUserRoleMapping");
        }

        public ActionResult DeleteUser(int id)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.USER_MASTER.ToString(), AccessPermission.IsDelete))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            Confi_IMSEntities _db = new Confi_IMSEntities();
            User user = _db.User.Where(x => x.Id == id).SingleOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult DeleteUser(int id , User user)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.USER_MASTER.ToString(), AccessPermission.IsDelete))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            userMstService.DeleteUser(id);
            return RedirectToAction("DisplayUserRoleMapping");
        }
    }
}
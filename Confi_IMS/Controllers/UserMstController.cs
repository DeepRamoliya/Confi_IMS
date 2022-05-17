using IMS.DataAccess;
using IMS.DataAccess.Database;
using IMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
           List<User> UserList = userMstService.GetAllUser();
            return View(UserList);
        }
        public ActionResult EditUserRoleMapping(int id)
        {
            /*if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.PURCHASE_PRODUCT.ToString(), AccessPermission.IsEdit))
            {
                return RedirectToAction("AccessDenied", "Base");
            }*/
            Confi_IMSEntities _db = new Confi_IMSEntities();
            ViewBag.Roles = _db.webpages_Roles.Select(x => x.RoleCode).ToList();
            User user = userMstService.GetUserById(id);
            return View(user);
        }


        [HttpPost]
        public ActionResult EditUserRoleMapping(User pur)
        {
            User objPurchaseModel = userMstService.UpdateUsersRole(pur);
            return RedirectToAction("DisplayPurchase");

        }


    }
}
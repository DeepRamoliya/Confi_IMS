using IMS.DataAccess;
using IMS.DataAccess.Database;
using IMS.Model;
using IMS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Confi_IMS.Controllers
{
    
    public class PurchaseController : BaseController
    {
        
        private readonly PurchaseService purchaseService;
        public PurchaseController()
        {
            purchaseService = new PurchaseService();
        }
        public ActionResult DisplayPurchase()
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.PURCHASE_PRODUCT.ToString(), AccessPermission.IsView))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            List<Purchase> purchase = purchaseService.GetAllProducts();
            return View(purchase);
        }


        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.PURCHASE_PRODUCT.ToString(), AccessPermission.IsAdd))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            Confi_IMSEntities _db = new Confi_IMSEntities();
            ViewBag.Purchase_Product = _db.Products.Select(x => x.Product_Name).ToList(); 
            return View();
        }
        [HttpPost]
        public ActionResult PurchaseProduct(Purchase pur)
        {
            purchaseService.PurchaseProduct(pur);
            return RedirectToAction("DisplayPurchase");
        }


        public ActionResult UpdatePurchase(int id)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.PURCHASE_PRODUCT.ToString(), AccessPermission.IsEdit))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            Purchase purchase = purchaseService.GetPurchaseById(id);
            return View(purchase);
        }


        [HttpPost]
        public ActionResult UpdatePurchase(PurchaseModel pur)
        {
            PurchaseModel objPurchaseModel = purchaseService.UpdatePurchase(pur);
            return RedirectToAction("DisplayPurchase");

        }

        [HttpGet]

        public ActionResult PurchaseDetail(int id)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.PURCHASE_PRODUCT.ToString(), AccessPermission.IsView))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            Purchase purchase = purchaseService.GetPurchaseById(id);
            return View(purchase);
        }


        public ActionResult DeletePurchase(int id)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.PURCHASE_PRODUCT.ToString(), AccessPermission.IsDelete))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            Confi_IMSEntities _db = new Confi_IMSEntities();
            Purchase pro = _db.Purchase.Where(x => x.id == id).SingleOrDefault();
            return View(pro);
        }

        [HttpPost]
        public ActionResult DeletePurchase(int id, Purchase pro)
        {
            Confi_IMSEntities _db = new Confi_IMSEntities();
            Purchase p = _db.Purchase.Where(x => x.id == id).SingleOrDefault();
            _db.Purchase.Remove(p);
            _db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }

    }
}
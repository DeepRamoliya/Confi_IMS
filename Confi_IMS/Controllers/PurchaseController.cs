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
    
    public class PurchaseController : Controller
    {
        
        private readonly PurchaseService purchaseService;
        public PurchaseController()
        {
            purchaseService = new PurchaseService();
        }
        public ActionResult DisplayPurchase()
        {
            List<Purchase> purchase = purchaseService.GetAllProducts();
            return View(purchase);
        }


        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            Confi_IMSEntities _db = new Confi_IMSEntities();
            ViewBag.Purchase_Product = _db.Products.Select(x => x.Product_Name).ToList(); 
            return View();
        }
        public ActionResult PurchaseProduct(Purchase pur)
        {
            purchaseService.PurchaseProduct(pur);
            return RedirectToAction("DisplayPurchase");
        }


        public ActionResult UpdatePurchase(int id)
        {
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
            Purchase purchase = purchaseService.GetPurchaseById(id);
            return View(purchase);
        }


        public ActionResult DeleteProduct(int id)
        {
            Confi_IMSEntities _db = new Confi_IMSEntities();
            Product pro = _db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(pro);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id, Product pro)
        {
            Confi_IMSEntities _db = new Confi_IMSEntities();
            Product p = _db.Products.Where(x => x.id == id).SingleOrDefault();
            _db.Products.Remove(p);
            _db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }

    }
}
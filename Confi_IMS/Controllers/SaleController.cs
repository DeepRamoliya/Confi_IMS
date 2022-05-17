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
    public class SaleController : BaseController
    {
        private readonly SaleService saleService;
        public SaleController()
        {
            saleService = new SaleService();
        }
        public ActionResult DisplaySale()
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.SALE_PRODUCT.ToString(), AccessPermission.IsView))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            List<Sale> sale = saleService.GetAllProducts();
            return View(sale);
        }


        [HttpGet]
        public ActionResult SaleProduct()
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.SALE_PRODUCT.ToString(), AccessPermission.IsView))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            Confi_IMSEntities _db = new Confi_IMSEntities();
            ViewBag.Sale_Product = _db.Products.Select(x => x.Product_Name).ToList();
            return View();
        }
        public ActionResult SaleProduct(Sale pur)
        {
            saleService.SaleProduct(pur);
            return RedirectToAction("DisplaySale");
        }


        public ActionResult UpdateSale(int id)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.SALE_PRODUCT.ToString(), AccessPermission.IsView))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            Sale sale = saleService.GetSaleById(id);
            return View(sale);
        }


        [HttpPost]
        public ActionResult UpdateSale(SaleModel pur)
        {
            SaleModel objSaleModel = saleService.UpdateSale(pur);
            return RedirectToAction("DisplaySale");

        }

        [HttpGet]

        public ActionResult SaleDetail(int id)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.SALE_PRODUCT.ToString(), AccessPermission.IsView))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            Sale sale = saleService.GetSaleById(id);
            return View(sale);
        }


        public ActionResult DeleteProduct(int id)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.SALE_PRODUCT.ToString(), AccessPermission.IsView))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
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
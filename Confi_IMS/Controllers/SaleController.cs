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
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.SALE_PRODUCT.ToString(), AccessPermission.IsAdd))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            Confi_IMSEntities _db = new Confi_IMSEntities();
            ViewBag.Sale_Product = _db.Products.Select(x => x.Product_Name).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult SaleProduct(Sale pur)
        {
            saleService.SaleProduct(pur);
            return RedirectToAction("DisplaySale");
        }


        public ActionResult UpdateSale(int id)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.SALE_PRODUCT.ToString(), AccessPermission.IsEdit))
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


        public ActionResult DeleteSale(int id)
        {
            if (!CheckPermission(AuthorizeFormAccess.FormAccessCode.SALE_PRODUCT.ToString(), AccessPermission.IsDelete))
            {
                return RedirectToAction("AccessDenied", "Base");
            }
            Confi_IMSEntities _db = new Confi_IMSEntities();
            Sale pro = _db.Sale.Where(x => x.id == id).SingleOrDefault();
            return View(pro);
        }

        [HttpPost]
        public ActionResult DeleteSale(int id, Sale pro)
        {
            Confi_IMSEntities _db = new Confi_IMSEntities();
            Sale p = _db.Sale.Where(x => x.id == id).SingleOrDefault();
            _db.Sale.Remove(p);
            _db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

    }
}
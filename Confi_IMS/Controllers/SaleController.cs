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
    public class SaleController : Controller
    {
        private readonly SaleService saleService;
        public SaleController()
        {
            saleService = new SaleService();
        }
        public ActionResult DisplaySale()
        {
            List<Sale> sale = saleService.GetAllProducts();
            return View(sale);
        }


        [HttpGet]
        public ActionResult SaleProduct()
        {
            ViewBag.Sale_Product = saleService.BindSaleProduct();
            return View();
        }
        public ActionResult SaleProduct(Sale pur)
        {
            saleService.SaleProduct(pur);
            return RedirectToAction("DisplaySale");
        }


        public ActionResult UpdateSale(int id)
        {
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
            Sale sale = saleService.GetSaleById(id);
            return View(sale);
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
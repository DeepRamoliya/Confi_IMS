using IMS.DataAccess;
using IMS.DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Confi_IMS.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult DisplayProduct()
        {
           //List<Product> list = db.Products.OrderByDescending(x => x.id).ToList();
            return View();
        }


        //[HttpGet]
        //public ActionResult CreateProduct()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public ActionResult CreateProduct(Product pro)
        //{
        //    db.Product.Add(pro);
        //    db.SaveChanges();
        //    return RedirectToAction("DisplayProduct");
        //}

        //[HttpGet]
        //public ActionResult UpdateProduct(int id)
        //{
        //    Product pr = db.Products.Where(x => x.id == id).SingleOrDefault();
        //    return View(pr);
        //}

        //[HttpPost]
        //public ActionResult UpdateProduct(int id, Product pro)
        //{
        //    Product pr = db.Products.Where(x => x.id == id).SingleOrDefault();
        //    pr.Product_Name = pro.Product_Name;
        //    pr.Product_Quntity = pro.Product_Quntity;
        //    db.SaveChanges();
        //    return RedirectToAction("DisplayProduct");

        //}
        //[HttpGet]

        //public ActionResult ProductDetail(int id)
        //{
        //    Product pro = db.Products.Where(x => x.id == id).SingleOrDefault();
        //    return View(pro);
        //}


        //public ActionResult DeleteProduct(int id)
        //{
        //    Product pro = db.Products.Where(x => x.id == id).SingleOrDefault();
        //    return View(pro);
        //}

        //[HttpPost]
        //public ActionResult DeleteProduct(int id, Product pro)
        //{
        //    Product p = db.Products.Where(x => x.id == id).SingleOrDefault();
        //    db.Products.Remove(p);
        //    db.SaveChanges();
        //    return RedirectToAction("DisplayProduct");
        //}



    }
}
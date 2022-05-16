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
    public class ProductController : Controller
    {
        private readonly ProductService productService;
        public ProductController()
        {
            productService = new ProductService();
        }
        public ActionResult DisplayProduct()
        {
            List<Product> product = productService.GetAllProducts();
            return View(product);
        }


        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateProduct(Product pro)
        {
            productService.CreateProduct(pro);
            return RedirectToAction("DisplayProduct"); 
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            Product product = productService.GetProductById(id);
            return View(product);
        }

        
        [HttpPost]
        public ActionResult UpdateProduct(ProductModel pro)
            {
            ProductModel objProductModel = productService.UpdateProduct(pro);
                return RedirectToAction("DisplayProduct");

            }
       
            [HttpGet]

            public ActionResult ProductDetail(int id)
            {
            Product product =  productService.GetProductById(id);
              return View(product);
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
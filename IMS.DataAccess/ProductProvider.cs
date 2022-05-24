using IMS.DataAccess.Database;
using IMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess
{
     public class ProductProvider : BaseProvider
    {
        public ProductProvider()
        {

        }
        public List<Product> GetAllProduct()
        {
            var product = _db.Products.ToList();
            return product;
        }

        public Product GetProductById(int id)
        {
            return _db.Products.Find(id);
        }


        public Product CreateProduct(Product objProduct)
        {
            Product _Product = new Product()
            {
                id = objProduct.id,
                Product_Name = objProduct.Product_Name,
                Product_Quntity = objProduct.Product_Quntity
            };

            _db.Products.Add(_Product);
            _db.SaveChanges();

            return objProduct;
        }

        public ProductModel UpdateProduct(ProductModel pro)
        {
            var objpro = GetProductById(pro.id);
            objpro.Product_Name = pro.Product_Name;
            objpro.Product_Quntity = pro.Product_Quntity;
            _db.SaveChanges();
            return pro;
            
        }

    }
}

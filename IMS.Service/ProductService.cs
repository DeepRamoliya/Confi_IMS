using IMS.DataAccess;
using IMS.DataAccess.Database;
using IMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IMS.Service
{
    public class ProductService
    {
        public readonly ProductProvider productProvider;
        public ProductService()
        {
            productProvider = new ProductProvider();
        }
        public List<Product> GetAllProducts()
        {
            List<Product> Products = productProvider.GetAllProduct();
            return Products;
        }
        public Product CreateProduct(Product objProduct)
        {
            return productProvider.CreateProduct(objProduct);
        }

        public Product GetProductById(int id)
        {
            var data = productProvider.GetProductById(id);
            Product product = new Product
            {
                id= data.id,
                Product_Name = data.Product_Name,
                Product_Quntity = data.Product_Quntity
            };
            return product;
        }

        public ProductModel UpdateProduct(ProductModel pro)
        {
            return productProvider.UpdateProduct(pro);
           
        }

    }
}

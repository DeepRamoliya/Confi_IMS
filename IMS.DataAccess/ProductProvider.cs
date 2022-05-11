using IMS.DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess
{
    class ProductProvider : BaseProvider
    {
        public ProductProvider()
        {

        }

        /*public ProductProvider GetProductById(int Id)
        {
            return _db.Products.Find(Id);
        }*/

        public List<Product> GetAllProduct()
        {
            var product = _db.Products.ToList();
            return product;
        }
        
    }
}

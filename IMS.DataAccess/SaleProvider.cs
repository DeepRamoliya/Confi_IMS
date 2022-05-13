using IMS.DataAccess.Database;
using IMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess
{
    public class SaleProvider : BaseProvider
    {
        public SaleProvider()
        {

        }
        public List<Sale> GetAllProduct()
        {
            var sale = _db.Sale.ToList();
            return sale;
        }

        public Sale GetSaleById(int id)
        {
            return _db.Sale.Find(id);
        }

        public Sale SaleProduct(Sale objSale)
        {
            Sale _Sale = new Sale()
            {
                id = objSale.id,
                Sale_Product = objSale.Sale_Product,
                Sale_Quntity = objSale.Sale_Quntity,
                Sale_date = DateTime.Now
            };

            _db.Sale.Add(_Sale);
            _db.SaveChanges();

            return objSale;
        }



        public List<System.Web.UI.WebControls.DropDownList> BindSaleProduct()
        {
            return _db.Products.Select(x => new System.Web.UI.WebControls.DropDownList { Text = x.Product_Name.ToString(), ID = x.id.ToString() }).ToList();
        }

        public SaleModel UpdateSale(SaleModel pur)
        {
            var objpur = GetSaleById(pur.id);
            objpur.Sale_Product = pur.Sale_Product;
            objpur.Sale_Quntity = pur.Sale_Quntity;
            _db.SaveChanges();
            return pur;

        }

    }
}

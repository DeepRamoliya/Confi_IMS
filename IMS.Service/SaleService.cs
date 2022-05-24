using IMS.DataAccess;
using IMS.DataAccess.Database;
using IMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service
{
    public class SaleService
    {
        public readonly SaleProvider saleProvider;
        public SaleService()
        {
            saleProvider = new SaleProvider();
        }
        public List<Sale> GetAllProducts()
        {
            List<Sale> Purcahse = saleProvider.GetAllProduct();
            return Purcahse;
        }

        public Sale SaleProduct(Sale objProduct)
        {
            return saleProvider.SaleProduct(objProduct);
        }

        public Sale GetSaleById(int id)
        {
            var data = saleProvider.GetSaleById(id);
            Sale sale = new Sale
            {
                id = data.id,
                Sale_Product = data.Sale_Product,
                Sale_Quntity = data.Sale_Quntity
            };
            return sale;
        }

        public SaleModel UpdateSale(SaleModel pur)
        {
            return saleProvider.UpdateSale(pur);
        }

    }

    
}

using IMS.DataAccess;
using IMS.DataAccess.Database;
using IMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace IMS.Service
{
    public class PurchaseService
    {
        public readonly PurchaseProvider purchaseProvider;
        public PurchaseService()
        {
            purchaseProvider = new PurchaseProvider();
        }
        public List<Purchase> GetAllProducts()
        {
            List<Purchase> Purcahse = purchaseProvider.GetAllProduct();
            return Purcahse;
        }

        public Purchase PurchaseProduct(Purchase objProduct)
        {
            return purchaseProvider.PurchaseProduct(objProduct);
        }

        public List<System.Web.UI.WebControls.DropDownList> BindPurchaseProduct()
        {
            return purchaseProvider.BindPurchaseProduct();
        }

        

        public Purchase GetPurchaseById(int id)
        {
            var data = purchaseProvider.GetPurchaseById(id);
            Purchase purchase = new Purchase
            {
                id = data.id,
                Purchase_Product = data.Purchase_Product,
                Purchase_Quntity = data.Purchase_Quntity
            };
            return purchase;
        }

        public PurchaseModel UpdatePurchase(PurchaseModel pur)
        {
            return purchaseProvider.UpdatePurchase(pur);
        }

       
    }
}

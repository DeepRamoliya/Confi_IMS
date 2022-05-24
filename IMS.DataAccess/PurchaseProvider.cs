using IMS.DataAccess.Database;
using IMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace IMS.DataAccess
{
    public class PurchaseProvider : BaseProvider
    {
        public PurchaseProvider()
        {

        }
        public List<Purchase> GetAllProduct()
        {
            var purchase = _db.Purchase.ToList();
            return purchase;
        }

        public Purchase GetPurchaseById(int id)
        {
            return _db.Purchase.Find(id);
        }

        public Purchase PurchaseProduct(Purchase objPurchase)
        {
            Purchase _Purchase = new Purchase()
            {
                id = objPurchase.id,
                Purchase_Product = objPurchase.Purchase_Product,
                Purchase_Quntity = objPurchase.Purchase_Quntity,
                Purchase_date = DateTime.Now
            };

            _db.Purchase.Add(_Purchase);
            _db.SaveChanges();

            return objPurchase;
        }

        public PurchaseModel UpdatePurchase(PurchaseModel pur)
        {
            var objpur = GetPurchaseById(pur.id);
            objpur.Purchase_Product = pur.Purchase_Product;
            objpur.Purchase_Quntity = pur.Purchase_Quntity;
            _db.SaveChanges();
            return pur;

        }
    }
}

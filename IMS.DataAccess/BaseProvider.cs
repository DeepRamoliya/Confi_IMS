using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess
{
    public class BaseProvider: IDisposable
    {
        public Confi_IMSEntities _db;
        public BaseProvider()
        {
            _db = new Confi_IMSEntities();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}

using IMS.DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess
{
    public class Confi_IMSEntities: DbContext
    {

        public Confi_IMSEntities() : base("Confi_IMSConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> User { get; set; }
    }
}

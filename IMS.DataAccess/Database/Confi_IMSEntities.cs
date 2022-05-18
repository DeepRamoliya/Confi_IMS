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

        public DbSet<User> User { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<FormMst> FormMst { get; set; }
        public DbSet<webpages_Roles> webpages_Roles { get; set; }
        public System.Data.Entity.DbSet<IMS.Model.ProductModel> ProductModels { get; set; }
        public DbSet<FormRoleMapping> FormRoleMapping { get; set; }
        public DbSet<webpages_UsersInRoles> webpages_UsersInRoles { get; set; }
        public DbSet<UserRoleMapping> UserRoleMapping { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;

namespace Confi_IMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            InitializeAuthenticationProcess();
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        private void InitializeAuthenticationProcess()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("Confi_IMSConnection", "User", "Id", "EmailId", true);

                //WebSecurity.CreateUserAndAccount("Irfan", "irfan123");    
                //Roles.CreateRole("Administrator");
                //Roles.CreateRole("Manager");
            }
        }
    }
}

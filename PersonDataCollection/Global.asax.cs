
using PersonDataCollection.App_Start;
using PersonDataCollection.DAL;
using PersonDataCollection.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PersonDataCollection
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            PersonContext databaseContext = new PersonContext();
            databaseContext.Database.Initialize(true);

            IocConfig.RegisterDependencies();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

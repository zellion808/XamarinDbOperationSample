using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using xamarinDbOperationSample.Models;

namespace xamarinDbOperationSample
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer(new CreateDatabaseIfNotExists<SampleDataAccess>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SampleDataAccess>());
        }
    }
}

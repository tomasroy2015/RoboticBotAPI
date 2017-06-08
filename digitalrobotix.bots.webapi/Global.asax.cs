using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace digitalrobotix.bots.webapi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            System.Diagnostics.Trace.TraceInformation("Web application started. Initializing the configuration");
            GlobalConfiguration.Configure(WebApiConfig.Register);
            System.Diagnostics.Trace.TraceInformation("The configuration initialized");
        }
    }
}

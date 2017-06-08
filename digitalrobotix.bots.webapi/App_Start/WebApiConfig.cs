using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace digitalrobotix.bots.webapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            System.Diagnostics.Trace.TraceInformation("Inititalizing the Web API routes");
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            System.Diagnostics.Trace.TraceInformation("Inititalizing the Telegram WebHooks");
            config.InitializeReceiveTelegramWebHooks();
            System.Diagnostics.Trace.TraceInformation("Inititalizing the Slack WebHooks");
            config.InitializeReceiveSlackWebHooks();
        }
    }
}

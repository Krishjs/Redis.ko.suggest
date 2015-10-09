using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Redis.KO.Suggest
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Dictionary<string,string> dict = RedisHelper.RedisConnectionAndUpload(connectionString: "127.0.0.1:6379");
            foreach (var d in dict)
            {
                Response.AddHeader(d.Key, d.Value);
            }
        }
    }
}

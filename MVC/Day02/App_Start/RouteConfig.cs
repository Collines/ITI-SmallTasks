using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Day02
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Car",
               url: "Car/{action}/{id}",
               defaults: new { controller = "Car", action = "All", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Default",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

            //routes.MapRoute(
            //   name: "ay7ag",
            //   url: "Car/",
            //   defaults: new { controller = "Car", action = "All", id = UrlParameter.Optional }
            //);


           

           

        }
    }
}

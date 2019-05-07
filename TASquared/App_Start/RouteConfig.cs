﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TASquared
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //.com/Area/id1/Category/id2/List/userid
            routes.MapRoute(
                name: "Posts",
                url: "Area/{area_id}/Category/{category_id}/{action}/{id}",
                defaults: new { controller = "Posts", action = "Index", id = UrlParameter.Optional }
            );

            //.com / inbox /{ action}/ userid
            routes.MapRoute(
                name: "Inbox",
                url: "inbox/{action}/{userid}/{id}",
                defaults: new { controller = "Inbox", action = "Index", id = UrlParameter.Optional }
            );

            //.com/{controller}/{action}/userid
            routes.MapRoute(
                name: "Admin_ALSSC",
                url: "{controller}/{action}/{userid}/{id}",
                defaults: new { controller = "Area", action = "Index", id = UrlParameter.Optional }
            );

            //.com/admin/{action}/userid/{id} [admin controller]
            routes.MapRoute(
               name: "Admin",
               url: "Admin/{action}/{userid}/{id}",
               defaults: new { controller = "Admin", action = "ListUsers", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

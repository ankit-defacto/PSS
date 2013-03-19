
namespace PSS.WebWithAuth.App_Start
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using PSS.WebWithAuth.Filters;

    /// <summary>
    /// Route config
    /// </summary>
    public class RoutingConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //Admin
            routes.MapRouteLowercase(
                "Admin Login", // Route name
                "admin", // URL with parameters
                new { controller = "Admin", action = "LogIn" } // Parameter defaults
            );

            routes.MapRouteLowercase(
                "Edit Password", // Route name
                "editpassword", // URL with parameters
                new { controller = "Admin", action = "EditPassword" } // Parameter defaults
            );

            routes.MapRouteLowercase(
                "Change Password", // Route name
                "admin/changepassword", // URL with parameters
                new { controller = "Admin", action = "EditPassword" } // Parameter defaults
            );

            routes.MapRouteLowercase(
                "Modify Listings", // Route name
                "listingtypes", // URL with parameters
                new { controller = "Admin", action = "Listingtypes" } // Parameter defaults
            );



            //
            routes.MapRouteLowercase(
                "Account index", // Route name
                "account", // URL with parameters
                new { controller = "Account", action = "See" } // Parameter defaults
            );

            routes.MapRouteLowercase(
                "Account view", // Route name
                "account/view", // URL with parameters
                new { controller = "Account", action = "See" } // Parameter defaults
            );

            routes.MapRouteLowercase(
                "Login", // Route name
                "account/logon", // URL with parameters
                new { controller = "Account", action = "LogIn" } // Parameter defaults
            );

            routes.MapRouteLowercase(
                "Account Edit", // Route name
                "account/{action}/{accountguid}", // URL with parameters
                new { controller = "Account", action = "See", accountguid = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRouteLowercase(
                "Search", // Route name
                "search/{action}/{*pathInfo}", // URL with parameters
                new { controller = "Search", action = "Search" } // Parameter defaults
            );

            routes.MapRouteLowercase(
                "Contact", // Route name
                "contact", // URL with parameters
                new { controller = "Home", action = "Contact" } // Parameter defaults
            );

            routes.MapRouteLowercase(
                "About", // Route name
                "about", // URL with parameters
                new { controller = "Home", action = "About" } // Parameter defaults
            );

            routes.MapRouteLowercase(
                "List index",
                "listings/index",
                new { controller = "Listings", action = "List" });

            routes.MapRouteLowercase(
                "List",
                "listings",
                new { controller = "Listings", action = "List" });

            routes.MapRouteLowercase(
                "Listing edit",
                "listings/{action}/{facilityGuid}",
                new { controller = "Listings", action = "Edit", facilityGuid = UrlParameter.Optional });

            routes.MapRouteLowercase(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRouteLowercase(
                "Admin", // Route name
                "admin", // URL with parameters
                new { controller = "Admin", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }
    }
}
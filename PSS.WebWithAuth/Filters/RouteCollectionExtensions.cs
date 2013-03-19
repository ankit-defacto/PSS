
namespace PSS.WebWithAuth.Filters
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Route extension methods
    /// </summary>
    public static class RouteCollectionExtensions
    {
        /// <summary>
        /// Maps route to lowercase
        /// </summary>
        /// <param name="routes">Routes</param>
        /// <param name="name">Route name</param>
        /// <param name="url">Url</param>
        /// <param name="defaults">Default route</param>
        public static void MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults)
        {
            routes.MapRouteLowercase(name, url, defaults, null);
        }

        /// <summary>
        /// Maps route to lowercase
        /// </summary>
        /// <param name="routes">Routes</param>
        /// <param name="name">Route name</param>
        /// <param name="url">Url</param>
        /// <param name="defaults">Default route</param>
        /// <param name="constraints">Route constraints</param>
        public static void MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults, object constraints)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }

            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            var route = new LowercaseRouteHelper(url, new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(defaults),
                Constraints = new RouteValueDictionary(constraints)
            };

            if (String.IsNullOrEmpty(name))
            {
                routes.Add(route);
            }
            else
            {
                routes.Add(name, route);
            }
        }
    }
}

namespace PSS.WebWithAuth.Filters
{
    using System.Web.Routing;

    /// <summary>
    /// Convert route url to lower case (SEO friendly)
    /// </summary>
    public class LowercaseRouteHelper : System.Web.Routing.Route
    {
        public LowercaseRouteHelper(string url, IRouteHandler routeHandler)
            : base(url, routeHandler) { }

        public LowercaseRouteHelper(string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
            : base(url, defaults, routeHandler) { }

        public LowercaseRouteHelper(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler)
            : base(url, defaults, constraints, routeHandler) { }

        public LowercaseRouteHelper(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler)
            : base(url, defaults, constraints, dataTokens, routeHandler) { }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            VirtualPathData path = base.GetVirtualPath(requestContext, values);
            if (path != null)
            {
                path.VirtualPath = path.VirtualPath.ToLowerInvariant();
            }

            return path;
        }
    }
}
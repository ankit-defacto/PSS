
namespace PSS.WebWithAuth.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.WebPages;
    using PSS.WebWithAuth.ViewModels;


    /// <summary>
    /// MVC helpers
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Gets the site url (application url in IIS)
        /// </summary>
        public static string ApplicationUrl
        {
            get
            {
                var httpRequest = HttpContext.Current.Request;
                return httpRequest.Url.GetLeftPart(UriPartial.Authority) + httpRequest.ApplicationPath.TrimEnd('/');
            }
        }

        /// <summary>
        /// Gets current requested url
        /// </summary>
        public static string CurrentRequestUrl
        {
            get
            {
                return HttpContext.Current.Request.Url.AbsoluteUri;
            }
        }

        /// <summary>
        /// Compares key from RouteData.Values collection
        /// </summary>
        /// <param name="htmlHelper">Html helper</param>
        /// <param name="keyName">Name of the key to compare</param>
        /// <param name="value">Value to compare with</param>
        /// <returns>True/False</returns>
        public static bool CurrentRouteDataKeyCompare(this HtmlHelper htmlHelper, string keyName, string value, bool takeParentData)
        {
            var currentValue = (string)(takeParentData ? htmlHelper.ViewContext.ParentActionViewContext.RouteData.Values[keyName] : htmlHelper.ViewContext.RouteData.Values[keyName]);
            if (string.Equals(currentValue, value, StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Compares if current action is equal to argument
        /// </summary>
        /// <param name="htmlHelper">Html helper</param>
        /// <param name="action">Action to check</param>
        /// <returns>True/False</returns>
        public static bool CurrentActionEquals(this HtmlHelper htmlHelper, string action)
        {
            return htmlHelper.CurrentRouteDataKeyCompare("action", action, false);
        }
        
        /// <summary>
        /// Compares if current controller is equal to argument
        /// </summary>
        /// <param name="htmlHelper">Html helper</param>
        /// <param name="controller">Controller to check</param>
        /// <returns>True/False</returns>
        public static bool CurrentControllerEquals(this HtmlHelper htmlHelper, string controller)
        {
            return htmlHelper.CurrentRouteDataKeyCompare("controller", controller, false);
        }

        /// <summary>
        /// Compares if current action is equal to argument
        /// </summary>
        /// <param name="htmlHelper">Html helper</param>
        /// <param name="action">Action to check</param>
        /// <returns>True/False</returns>
        public static bool ParentActionEquals(this HtmlHelper htmlHelper, string action)
        {
            return htmlHelper.CurrentRouteDataKeyCompare("action", action, true);
        }

        /// <summary>
        /// Compares if current controller is equal to argument
        /// </summary>
        /// <param name="htmlHelper">Html helper</param>
        /// <param name="controller">Controller to check</param>
        /// <returns>True/False</returns>
        public static bool ParentControllerEquals(this HtmlHelper htmlHelper, string controller)
        {
            return htmlHelper.CurrentRouteDataKeyCompare("controller", controller, true);
        }

        /// <summary>
        /// Menu item highlighter (to highlight current menu)
        /// </summary>
        /// <param name="htmlHelper">The html helper</param>
        /// <param name="controller">Current controller</param>
        /// <param name="actions">Mapped actions to this menu item</param>
        /// <param name="text">Menu item text</param>
        /// <param name="url">Link url</param>
        /// <param name="viewMode">View mode - authenticated, anonymous or all</param>
        /// <returns>Highlighted and styled menu item</returns>
        public static MvcHtmlString MenuItem(this HtmlHelper htmlHelper, string controller, string[] actions, string text, string url, Enums.MenuItemViewModes viewMode)
        {
            bool showItem = false;
            if (viewMode == Enums.MenuItemViewModes.Anonymous && !HttpContext.Current.Request.IsAuthenticated)
            {
                showItem = true;
            }
            
            if (viewMode == Enums.MenuItemViewModes.Authenticated && HttpContext.Current.Request.IsAuthenticated)
	        {
        		showItem = true;
	        }

            if (viewMode == Enums.MenuItemViewModes.All)
	        {
		        showItem = true;
	        }
            
            var sb = new StringBuilder();
            if (showItem)
            {
                bool activeFound = false;
                for (int i = 0; i < actions.Length; i++)
                {
                    if (htmlHelper.ParentControllerEquals(controller) && htmlHelper.ParentActionEquals(actions[i]))
                    {
                        activeFound = true;
                        break;
                    }
                }

                if (activeFound)
                {
                    sb.AppendLine("<li class=\"s\">");
                }
                else
                {
                    sb.AppendLine("<li>");
                }
                sb.AppendLine("<a href=\"" + url + "\">" + text + "</a>");
                sb.AppendLine("</li>");
            }
            
            return MvcHtmlString.Create(sb.ToString());
        }

        // contains styling
        public static MvcHtmlString RadioButtonForSelectList<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IEnumerable<SelectListItem> listOfValues)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var sb = new StringBuilder();
            if (listOfValues != null)
            {
                // Create a radio button for each item in the list 
                foreach (SelectListItem item in listOfValues)
                {
                    // Generate an id to be given to the radio button field 
                    var id = string.Format("{0}_{1}", metaData.PropertyName, item.Value);
                    // Create and populate a radio button using the existing html helpers 
                    //var label = htmlHelper.Label(id, HttpUtility.HtmlEncode(item.Text));
                    var radio = htmlHelper.RadioButtonFor(expression, item.Value, new { id = id }).ToHtmlString();
                    // Create the html string that will be returned to the client 
                    // e.g. <input data-val="true" data-val-required="You must select an option" id="TestRadio_1" name="TestRadio" type="radio" value="1" /><label for="TestRadio_1">Line1</label> 
                    //sb.AppendFormat("<div class=\"RadioButton\">{0}{1}</div>", radio, label);
                    sb.AppendFormat("<label class=\"label_radio\">{0}{1}</label>", radio, HttpUtility.HtmlEncode(item.Text));
                }
            }

            return MvcHtmlString.Create(sb.ToString());
        } 
        
        /// <summary>
        /// Outputs "search filter item" label with styling
        /// contains styling
        /// </summary>
        /// <param name="htmlHelper">Html helper</param>
        /// <param name="label">Item label</param>
        /// <param name="value">Item value</param>
        /// <param name="cssclass">Css class to use</param>
        /// <returns>Formatted and styled item label</returns>
        public static MvcHtmlString SearchFilterItem(this HtmlHelper htmlHelper, string label)
        {
            var sb = new StringBuilder();
            if (!string.IsNullOrEmpty(label))
            {
                sb.AppendLine("<li class=\"tag\"><span>");
                sb.AppendLine(string.Format("{0}", label));
                sb.AppendLine("</span></li>");
            }
            
            return MvcHtmlString.Create(sb.ToString());
        }

        /// <summary>
        /// Adds routes to existing route dictionary
        /// </summary>
        /// <param name="targetRoute">Current route</param>
        /// <param name="existingRouteData">Route data to add</param>
        /// <returns>Extended route dictionary</returns>
        public static RouteValueDictionary AddMoreRoutes(this RouteValueDictionary targetRoute, IDictionary<string, object> existingRouteData) 
        {
            foreach (var de in existingRouteData)
            {
                targetRoute.Add(de.Key, de.Value);
            }

            return targetRoute;
        }

        /// <summary>
        /// Create route for search filter
        /// </summary>
        /// <param name="filter">Search filter view model</param>
        /// <returns>Route dictionary</returns>
        public static RouteValueDictionary SeoSearchFilterRouteCreate(SearchFilterViewModel filter)
        {
            var seofilter = filter.ToSeoSearchFilterObject();
            var finalroute = new RouteValueDictionary(seofilter);
            return finalroute;
        }

        /// <summary>
        /// Decorates paged list pager with search filter route data
        /// </summary>
        /// <param name="helper">Html helper</param>
        /// <param name="action">Target action</param>
        /// <param name="controller">Target controller</param>
        /// <param name="filter">Search filter</param>
        /// <returns>Generated page url</returns>
        public static string SeoSearchFilterPagerAction(this UrlHelper helper, string action, string controller, SearchFilterViewModel filter)
        {
            return helper.Action(action, controller, SeoSearchFilterRouteCreate(filter));
        }

        /// <summary>
        /// Extends search filter route with facilityGuid
        /// </summary>
        /// <param name="filter">Search filter with facility view model</param>
        /// <returns>Route dictionary</returns>
        public static RouteValueDictionary SeoSearchFilterWithFacilityRouteCreate(SearchFilterWithFacilityViewModel filter)
        {
            var filterBase = filter.ToSeoSearchFilterObject();
            return new RouteValueDictionary(filterBase);
        }
        
        /// <summary>
        /// Creates resource template for javascripts or css rendering
        /// </summary>
        /// <param name="HtmlHelper">Html helper</param>
        /// <param name="Template">Template to add</param>
        /// <param name="Type">Template type (to perform selective rendering)</param>
        /// <returns>The resource</returns>
        public static IHtmlString Resource(this HtmlHelper HtmlHelper, Func<object, HelperResult> Template, string Type)
        {
            if (HtmlHelper.ViewContext.HttpContext.Items[Type] != null) ((List<Func<object, HelperResult>>)HtmlHelper.ViewContext.HttpContext.Items[Type]).Add(Template);
            else HtmlHelper.ViewContext.HttpContext.Items[Type] = new List<Func<object, HelperResult>>() { Template };

            return new HtmlString(String.Empty);
        }

        /// <summary>
        /// Renders resource templates
        /// </summary>
        /// <param name="HtmlHelper">Html helper</param>
        /// <param name="Type">Template type (defined in Resource)</param>
        /// <returns>Rendered resources</returns>
        public static IHtmlString RenderResources(this HtmlHelper HtmlHelper, string Type)
        {
            if (HtmlHelper.ViewContext.HttpContext.Items[Type] != null)
            {
                List<Func<object, HelperResult>> Resources = (List<Func<object, HelperResult>>)HtmlHelper.ViewContext.HttpContext.Items[Type];
                foreach (var Resource in Resources)
                {
                    if (Resource != null) HtmlHelper.ViewContext.Writer.Write(Resource(null));
                }
            }

            return new HtmlString(String.Empty);
        }
    }
}
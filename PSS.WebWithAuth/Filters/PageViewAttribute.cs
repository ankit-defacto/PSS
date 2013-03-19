﻿
namespace PSS.WebWithAuth.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Caching;
    using System.Diagnostics;

    /// <summary>
    /// Page view tracking (does not work when caching is used)
    /// </summary>
    public class PageViewAttribute : ActionFilterAttribute
    {
        private static readonly TimeSpan pageViewDumpToDatabaseTimeSpan = new TimeSpan(0, 0, 10);

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var calledMethod = string.Format("{0} -> {1}",
                                             filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                                             filterContext.ActionDescriptor.ActionName);

            var cacheKey = string.Format("PV-{0}", calledMethod);

            var cachedResult = HttpRuntime.Cache[cacheKey];

            if (cachedResult == null)
            {
                HttpRuntime.Cache.Insert(cacheKey, new PageViewValue(), null, DateTime.Now.Add(pageViewDumpToDatabaseTimeSpan), Cache.NoSlidingExpiration, CacheItemPriority.Default,
                                      onRemove);
            }
            else
            {
                var currentValue = (PageViewValue)cachedResult;

                currentValue.Value++;
            }
        }

        private static void onRemove(string key, object value, CacheItemRemovedReason reason)
        {
            if (!key.StartsWith("PV-"))
            {
                return;
            }

            // write out the value to the database
            Debug.Print("{0}-{1}", key, value);
        }

        // Used to get around weird cache behavior with value types
        public class PageViewValue
        {
            public PageViewValue()
            {
                Value = 1;
            }

            public int Value { get; set; }
        }
    }
}
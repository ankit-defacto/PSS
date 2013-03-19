using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using PSS.WebWithAuth.App_Start;
using PSS.WebWithAuth.Filters;
using PSS.WebWithAuth.Infrastructure;
using PSS.WebWithAuth.Models;

namespace PSS.WebWithAuth
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RoutingConfig.RegisterRoutes(RouteTable.Routes);

            // Check for important database data and create if not present
            PSSDataInitializer.Initialize();
            //// Configure automapper
            AutoMapperConfig.Configure();
            Mapper.AssertConfigurationIsValid();
        }

        protected void Application_BeginRequest()
        {

        }
    }
}
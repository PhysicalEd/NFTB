﻿using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using NFTB.API;
using Microsoft.Practices.Unity;
using NFTB.Dep;
using Unity;

namespace NFTB.API
{
    public class Global : HttpApplication, IContainerAccessor
    {
        public static IUnityContainer Container { get; set; }
        IUnityContainer IContainerAccessor.Container
        {
            get { return Container; }
        }

        void Application_Start(object sender, EventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            Dependency.Register(container);
            Container = container;
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }
    }
}
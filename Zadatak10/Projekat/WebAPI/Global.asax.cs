using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebAPI.Controllers;
using Projekat.Repository;
using Projekat.Service;
using Autofac;
using Autofac.Integration.WebApi;

namespace WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<VrstaStudijaController>();
            containerBuilder.RegisterModule<ServiceModule>();
            containerBuilder.RegisterModule<RepositoryModule>();

            var container = containerBuilder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}

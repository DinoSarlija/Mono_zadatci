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
using AutoMapper;
using WebAPI.Models;
using Projekat.Model;

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


            /*automapper:*/
            containerBuilder.RegisterType<VrstaStudija>().AsSelf();
            containerBuilder.RegisterType<VrstaStudijaRest>().AsSelf();

            containerBuilder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VrstaStudijaRest, VrstaStudija>().ReverseMap();

            })).AsSelf().SingleInstance();

            containerBuilder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();/*:automapper*/


            var container = containerBuilder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}

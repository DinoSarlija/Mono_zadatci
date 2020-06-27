using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.Service.Common;
using Autofac;


namespace Projekat.Service
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //base.Load(builder);
            builder.RegisterType<VrstaStudijaService>().As<IVrstaStudijaService>();
        }
    }
}

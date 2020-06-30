using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.Repository.Common;
using Autofac;

namespace Projekat.Repository
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VrstaStudijaRepository>().As<IVrstaStudijaRepository>().InstancePerDependency();
        }
    }
}

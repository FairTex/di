using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Builder;

namespace TagsCloud
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new ContainerBuilder();
            container.RegisterAssemblyTypes(typeof(Program).Assembly).AsImplementedInterfaces();
            container.RegisterType<CloudCreator>().AsSelf();
            var build = container.Build();
            var cloudCreator = build.Resolve<CloudCreator>();
            cloudCreator.Create("in.txt", "out.jpeg");
        }
    }
}

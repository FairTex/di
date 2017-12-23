using System;
using System.Collections.Generic;
using System.Drawing;
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
            container.Register(_ => LoadConfig())
                .SingleInstance();
            var build = container.Build();
            var cloudCreator = build.Resolve<CloudCreator>();
            cloudCreator.Create();
        }

        static Config LoadConfig()
        {
            Config config;
            try
            {
                config = new Config("in3.txt", "out.jpeg", "Times New Roma", new Size(1024, 1024), 10);
            } catch (Exception e)
            {
                throw new Exception("При загрузке конфига произошла ошибка " + e.Message);
            }
            return config;
        }
    }
}

using System.Drawing;
using Autofac;

namespace TagsCloud
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new ContainerBuilder();
            container.RegisterAssemblyTypes(typeof(Program).Assembly).AsImplementedInterfaces();
            container.RegisterType<CloudCreator>().AsSelf();
            container.Register(_ => new Config("in.txt", "out.jpeg", "Times New Roman", new Size(1024, 1024), 50))
                .SingleInstance();
            var build = container.Build();
            var cloudCreator = build.Resolve<CloudCreator>();
            cloudCreator.Create();
        }
    }
}

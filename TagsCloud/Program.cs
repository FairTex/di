using System;
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
            container.Register(_ => LoadConfig())
                .SingleInstance();
            var build = container.Build();
            var cloudCreator = build.Resolve<CloudCreator>();
            cloudCreator.Create().OnFail(HandleErrorMessage);
        }

        static Config LoadConfig()
        {
            return Result.Of(
                () => new Config("in2.txt", "out.jpeg", "Times New Roman", new Size(10, 10), 10))
                .OnFail(HandleErrorMessage).Value;
        }

        static void HandleErrorMessage(string message)
        {
            Console.WriteLine(message);
            Environment.Exit(1);
        }
    }
}

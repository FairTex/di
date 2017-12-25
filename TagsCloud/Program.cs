using System;
using System.Drawing;
using Autofac;

namespace TagsCloud
{
    class Program
    {
        static void Main(string[] args)
        {
            var configLoadingResult = LoadConfig();
            if (!configLoadingResult.IsSuccess)
            {
                Console.WriteLine(configLoadingResult.Error);
                return;
            }

            var container = new ContainerBuilder();
            container.RegisterAssemblyTypes(typeof(Program).Assembly).AsImplementedInterfaces();
            container.RegisterType<CloudCreator>().AsSelf();
            container.Register(_ => configLoadingResult.Value)
                .SingleInstance();
            var build = container.Build();
            var cloudCreator = build.Resolve<CloudCreator>();

            var result = cloudCreator.Create();
            if (!result.IsSuccess)
            {
                Console.WriteLine(result.Error);
            }
        }

        static Result<Config> LoadConfig()
        {
            return Result.Of(
                () => new Config("in2.txt", "out.jpeg", "Times New Roman", new Size(10, 10), 10));
        }
    }
}

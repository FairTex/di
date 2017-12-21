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
    public class Config
    {
        public Config(string inputFileName, string outputFileName, string tagFontName, Size imageSize, int count)
        {
            InputFileName = inputFileName;
            OutputFileName = outputFileName;
            TagFontName = tagFontName;
            ImageSize = imageSize;
            Count = count;
            Center = new Point(imageSize.Width / 2, imageSize.Height / 2);
        }

        public string InputFileName { get; }
        public string OutputFileName { get; }
        public string TagFontName { get; }
        public Size ImageSize { get; }
        public Point Center { get; }
        public int Count { get; }
    }

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
            cloudCreator.Create("in.txt", "out.jpeg");
        }
    }
}

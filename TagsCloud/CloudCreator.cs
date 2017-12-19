using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud
{
    public class CloudCreator : ICloudCreator
    {
        private IWordReader WordReader;
        private IWordHandler WordHandler;
        private IDrawer Drawer;
        private ICircularCloudLayouter CircularCloudLayouter;

        public CloudCreator(IWordReader reader, IWordHandler handler, IDrawer drawer, ICircularCloudLayouter circularCloudLayouter)
        {
            WordHandler = handler;
            WordReader = reader;
            Drawer = drawer;
            CircularCloudLayouter = circularCloudLayouter;
        }

        public void Create(string inputFilename, string outputFilename)
        {
            var words = WordReader.read(inputFilename);
            var handledWords = WordHandler.Handle(words);
            var rectangles = CircularCloudLayouter.GetRectangles(handledWords);
            Drawer.Draw(rectangles, outputFilename);
        }
    }
}

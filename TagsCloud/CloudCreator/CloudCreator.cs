using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.TagMaker;

namespace TagsCloud
{
    public class CloudCreator : ICloudCreator
    {
        private IWordReader WordReader;
        private IWordHandler WordHandler;
        private IDrawer Drawer;
        private ITagMaker TagMaker;

        public CloudCreator(IWordReader reader, IWordHandler handler, IDrawer drawer, ITagMaker tagMaker)
        {
            WordHandler = handler;
            WordReader = reader;
            Drawer = drawer;
            TagMaker = tagMaker;
        }

        public void Create(string inputFilename, string outputFilename)
        {
            var words = WordReader.read(inputFilename);
            var handledWords = WordHandler.Handle(words);
            var rectangles = TagMaker.Make(handledWords);

            Drawer.Draw(rectangles, outputFilename);
        }
    }
}

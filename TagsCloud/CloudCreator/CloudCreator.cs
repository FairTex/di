namespace TagsCloud
{
    public class CloudCreator : ICloudCreator
    {
        private IWordReader WordReader;
        private readonly Config config;
        private IWordHandler WordHandler;
        private IDrawer Drawer;
        private ITagMaker TagMaker;

        public CloudCreator(Config config, IWordReader reader, IWordHandler handler, IDrawer drawer, ITagMaker tagMaker)
        {
            this.config = config;
            WordHandler = handler;
            WordReader = reader;
            Drawer = drawer;
            TagMaker = tagMaker;
        }

        public void Create()
        {
            var words = WordReader.Read(config.InputFileName);
            var handledWords = WordHandler.Handle(words);
            var rectangles = TagMaker.Make(handledWords);

            Drawer.Draw(rectangles);
        }
    }
}

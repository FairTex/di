namespace TagsCloud
{
    public class CloudCreator : ICloudCreator
    {
        private readonly IWordReader wordReader;
        private readonly Config config;
        private readonly ITextFilter textFilter;
        private readonly IDrawer drawer;
        private readonly ITagMaker tagMaker;

        public CloudCreator(Config config, IWordReader wordReader, ITextFilter textFilter, IDrawer drawer, ITagMaker tagMaker)
        {
            this.config = config;
            this.textFilter = textFilter;
            this.wordReader = wordReader;
            this.drawer = drawer;
            this.tagMaker = tagMaker;
        }

        public void Create()
        {
            var words = wordReader.Read(config.InputFileName);
            var handledWords = textFilter.ExcludeWords(words);
            var rectangles = tagMaker.Make(handledWords);
            drawer.Draw(rectangles);
        }
    }
}

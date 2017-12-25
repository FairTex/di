using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TagsCloud
{
    public class TagMaker : ITagMaker
    {
        private readonly ICircularCloudLayouter layouter;
        private const int MaxSize = 80;
        private const int MinSize = 20;
        private readonly Config config;

        public TagMaker(Config config, ICircularCloudLayouter layouter)
        {
            this.layouter = layouter;
            this.config = config;
        }

        public Dictionary<string, Rectangle> Make(IEnumerable<string> words)
        {
            var wordsFrequencies = CalculateFrequency(words);
            return wordsFrequencies.ToDictionary(word => word.Key, word =>
            {
                var tagSize = (int)((double)word.Value / wordsFrequencies.Values.Max()
                                    * (MaxSize - MinSize) + MinSize);
                var rectangleSize = TextRenderer.MeasureText(word.Key,
                    new Font(new FontFamily(config.TagFontName), tagSize,
                        FontStyle.Regular, GraphicsUnit.Pixel));

                return layouter.PutNextRectangle(rectangleSize);
            });
        }

        private Dictionary<string, int> CalculateFrequency(IEnumerable<string> words)
        {
            return words
                .GroupBy(word => word)
                .OrderByDescending(wordList => wordList.Count())
                .Take(config.Count)
                .ToDictionary(word => word.Key, wordList => wordList.Count());
        }
    }
}
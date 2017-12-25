using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TagsCloud
{
    public class TagMaker : ITagMaker
    {
        private readonly ICircularCloudLayouter layouter;
        private int maxSize = 80;
        private int minSize = 20;
        private Config Config;

        public TagMaker(Config config, ICircularCloudLayouter layouter)
        {
            this.layouter = layouter;
            Config = config;
        }

        public Dictionary<string, Rectangle> Make(string[] words)
        {
            words = words.Take(Config.Count).ToArray();
            Dictionary<string, int> wordsFrequencies = CalculateFrequency(words);
            return wordsFrequencies.ToDictionary(word => word.Key, word =>
            {
                var tagSize = (int)((double)word.Value / wordsFrequencies.Values.Max()
                                    * (maxSize - minSize) + minSize);
                var rectangleSize = TextRenderer.MeasureText(word.Key,
                    new Font(new FontFamily(Config.TagFontName), tagSize,
                        FontStyle.Regular, GraphicsUnit.Pixel));

                return layouter.PutNextRectangle(rectangleSize);
            });
        }

        private Dictionary<string, int> CalculateFrequency(string[] words)
        {
            return words
                .GroupBy(word => word)
                .OrderByDescending(wordList => wordList.Count())
                .Take(words.Length)
                .ToDictionary(word => word.Key, wordList => wordList.Count());
        }
    }
}
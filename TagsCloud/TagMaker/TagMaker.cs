using System;
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

        public Dictionary<string, Result<Rectangle>> Make(IEnumerable<string> words)
        {
            var wordsFrequencies = CalculateFrequency(words);
            return wordsFrequencies.ToDictionary(word => word.Key, word =>
            {
                var tagSize =
                    (int) ((double) word.Value / wordsFrequencies.Values.Max() * (maxSize - minSize) + minSize);
                var font = new Font(Config.FontFamily, tagSize, FontStyle.Regular, GraphicsUnit.Pixel);
                var rectangleSize = TextRenderer.MeasureText(word.Key, font);
                return layouter.PutNextRectangle(rectangleSize);
            });
        }

        private Dictionary<string, int> CalculateFrequency(IEnumerable<string> words)
        {
            return words
                .GroupBy(word => word)
                .OrderByDescending(wordList => wordList.Count())
                .Take(Config.Count)
                .ToDictionary(word => word.Key, wordList => wordList.Count());
        }
    }
}
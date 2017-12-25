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

        public Result<Dictionary<string, Rectangle>> Make(IEnumerable<string> words)
        {
            var wordsFrequencies = CalculateFrequency(words);
            var maxValue = wordsFrequencies.Values.Max();

            var dict = new Dictionary<string, Rectangle>();
            foreach (var pair in wordsFrequencies)
            {
                var word = pair.Key;
                var frequency = pair.Value;

                var tagSize = (int)((double)frequency / maxValue * (maxSize - minSize) + minSize);
                var font = new Font(Config.FontFamily, tagSize, FontStyle.Regular, GraphicsUnit.Pixel);
                var rectangleSize = TextRenderer.MeasureText(word, font);
                var rectangle = layouter.PutNextRectangle(rectangleSize);

                if (!rectangle.IsSuccess)
                {
                    return Result.Fail<Dictionary<string, Rectangle>>(rectangle.Error);
                }
                dict.Add(word, rectangle.Value);
            }
            return dict;
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
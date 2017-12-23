using System.Drawing;

namespace TagsCloud
{
    public class Config
    {
        public Config(string inputFileName, string outputFileName, string tagFontName, Size imageSize, int count)
        {
            InputFileName = inputFileName;
            OutputFileName = outputFileName;
            FontFamily = new FontFamily(tagFontName);
            TagFontName = tagFontName;
            ImageSize = imageSize;
            Count = count;
            Canvas = new Rectangle(0, 0, ImageSize.Width, ImageSize.Height);
            Center = new Point(imageSize.Width / 2, imageSize.Height / 2);
        }

        public string InputFileName { get; }
        public string OutputFileName { get; }
        public string TagFontName { get; }
        public FontFamily FontFamily { get; }
        public Size ImageSize { get; }
        public Point Center { get; }
        public int Count { get; }
        public Rectangle Canvas { get; }
    }
}
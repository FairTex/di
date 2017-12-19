using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace TagsCloud
{
    public class Drawer : IDrawer
    {
        private int Width { get; set; }
        private int Height { get; set; }
        private Brush[] BrushesList { get; set; }
        private int BrushIndex { get; set; } = 0;

        public Drawer(int width = 1024, int height = 1024)
        {
            Width = width;
            Height = height;
            BrushesList = new[]
            {
                Brushes.Blue, Brushes.Azure, Brushes.BlueViolet, Brushes.Green, Brushes.Yellow,
                Brushes.Coral, Brushes.Turquoise, Brushes.DarkOrange, Brushes.Khaki, Brushes.Pink
            };
        }

        private Brush GetBrush()
        {
            return BrushesList[BrushIndex++ % BrushesList.Length];
        }

        public void Draw(Dictionary<string, Rectangle> cloud, string outputFilename)
        {
            var bitmap = new Bitmap(Width, Height);
            var g = Graphics.FromImage(bitmap);

            foreach (var tag in cloud)
            {
                g.DrawString(tag.Key, new Font("Times New Roman", tag.Value.Height / 2), GetBrush(),
                    tag.Value.Location);
            }

            bitmap.Save(outputFilename, ImageFormat.Jpeg);
        }
    }
}
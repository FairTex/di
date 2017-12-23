using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace TagsCloud
{
    public class Drawer : IDrawer
    {
        private readonly Config config;
        private readonly IBrushGenerator brushGenerator;

        public Drawer(Config config, IBrushGenerator brushGenerator)
        {
            this.config = config;
            this.brushGenerator = brushGenerator;
        }
        
        public void Draw(Dictionary<string, Result<Rectangle>> cloud)
        {
            var bitmap = new Bitmap(config.ImageSize.Width, config.ImageSize.Height);
            var g = Graphics.FromImage(bitmap);

            foreach (var tag in cloud)
            {
                if (!tag.Value.IsSuccess)
                {
                    throw new Exception(tag.Value.Error);
                }
                g.DrawString(tag.Key, new Font(config.TagFontName, tag.Value.Value.Height / 2), brushGenerator.GetBrush(),
                    tag.Value.Value.Location);
            }

            bitmap.Save(config.OutputFileName, ImageFormat.Jpeg);
        }
    }
}
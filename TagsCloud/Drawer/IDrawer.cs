using System.Collections.Generic;
using System.Drawing;

namespace TagsCloud
{
    public interface IDrawer
    {
        void Draw(Dictionary<string, Rectangle> cloud);
    }
}
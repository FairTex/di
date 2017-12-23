using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud
{
    public interface IDrawer
    {
        void Draw(Dictionary<string, Result<Rectangle>> cloud);
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud
{
    public interface ICircularCloudLayouter
    {
        Dictionary<string, Rectangle> GetRectangles(string[] words);
    }
}

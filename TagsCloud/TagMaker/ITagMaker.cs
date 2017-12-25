using System.Collections.Generic;
using System.Drawing;

namespace TagsCloud
{
    public interface ITagMaker
    {
        Dictionary<string, Rectangle> Make(string[] words);
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud.TagMaker
{
    public interface ITagMaker
    {
        Dictionary<string, Rectangle> Make(string[] words);
    }
}

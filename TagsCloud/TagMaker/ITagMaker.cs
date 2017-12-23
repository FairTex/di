using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud
{
    public interface ITagMaker
    {
        Dictionary<string, Result<Rectangle>> Make(IEnumerable<string> words);
    }
}

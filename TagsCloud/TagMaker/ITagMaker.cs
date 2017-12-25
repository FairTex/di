using System.Collections.Generic;
using System.Drawing;

namespace TagsCloud
{
    public interface ITagMaker
    {
        Result<Dictionary<string, Rectangle>> Make(IEnumerable<string> words);
    }
}

using System.Collections.Generic;

namespace TagsCloud
{
    public interface IWordReader
    {
        IEnumerable<string> Read(string filename);
    }
}

using System.Collections.Generic;

namespace TagsCloud
{
    public interface IWordReader
    {
        Result<IEnumerable<string>> Read(string filename);
    }
}

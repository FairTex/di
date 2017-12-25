using System.Collections.Generic;

namespace TagsCloud
{
    public interface IWordFilter
    {
        IEnumerable<string> ExcludeWords(IEnumerable<string> words);
    }
}
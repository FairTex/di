using System.Collections.Generic;

namespace TagsCloud
{
    public interface ITextFilter
    {
        IEnumerable<string> ExcludeWords(IEnumerable<string> words);
    }
}

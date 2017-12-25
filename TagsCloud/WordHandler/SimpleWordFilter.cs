using System.Collections.Generic;
using System.Linq;

namespace TagsCloud
{
    public class SimpleWordFilter : IWordFilter
    {
        public IEnumerable<string> ExcludeWords(IEnumerable<string> words)
        {
            return words
                .Where(word => word.Trim().Length > 0)
                .Select(word => word.ToLower());
        }
    }
}
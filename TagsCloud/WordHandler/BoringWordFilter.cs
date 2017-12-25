using System.Collections.Generic;
using System.Linq;

namespace TagsCloud
{
    public class BoringWordFilter : IWordFilter
    {
        public IEnumerable<string> ExcludeWords(IEnumerable<string> words)
        {
            return words.Where(word => word.Length > 3);
        }
    }
}
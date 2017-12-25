using System.Collections.Generic;
using System.Linq;

namespace TagsCloud
{
    public class TextFilter : ITextFilter
    {
        private IWordFilter[] WordFilters { get; }

        public TextFilter(IWordFilter[] wordFilters)
        {
            WordFilters = wordFilters;
        }

        public IEnumerable<string> ExludeWords(IEnumerable<string> words)
        {
            return WordFilters.Aggregate(words, (word, handler) => handler.ExcludeWords(word));
        }
    }
}
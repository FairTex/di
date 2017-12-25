using System.Collections.Generic;
using System.Linq;

namespace TagsCloud
{
    public class SimpleHandler : IHandler
    {
        public IEnumerable<string> Handle(IEnumerable<string> words)
        {
            return words
                .Where(word => word.Trim().Length > 0)
                .Select(word => word.ToLower());
        }
    }
}
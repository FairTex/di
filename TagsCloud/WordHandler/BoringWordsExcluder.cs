using System;
using System.Collections.Generic;
using System.Linq;

namespace TagsCloud
{
    public class BoringWordsExcluder : IHandler
    {
        public IEnumerable<string> Handle(IEnumerable<string> words)
        {
            return words.Where(word => word.Length > 3);
        }
    }
}
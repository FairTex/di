using System;
using System.Linq;

namespace TagsCloud
{
    public class BoringWordsExcluder : IHandler
    {
        public string[] Handle(string[] words)
        {
            return words.Where(word => word.Length > 3).ToArray();
        }
    }
}
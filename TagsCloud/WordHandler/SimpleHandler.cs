using System;
using System.Linq;

namespace TagsCloud
{
    public class SimpleHandler : IHandler
    {
        public string[] Handle(string[] words)
        {
            return words
                .Where(word => word.Trim().Length > 0)
                .Select(word => word.ToLower()).ToArray();
        }
    }
}
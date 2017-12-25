using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TagsCloud
{
    public class WordReader : IWordReader
    {
        public IEnumerable<string> Read(string filename)
        {
            return File.ReadAllLines(filename)
                .SelectMany(line => line.Split(' '))
                .Select(word => word.Trim('"', '.', ','));
        }
    }
}
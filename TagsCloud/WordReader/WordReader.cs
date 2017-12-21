using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TagsCloud
{
    public class WordReader : IWordReader
    {
        public string[] read(string filename)
        {
            var lines = File.ReadAllLines(filename);
            var words = new List<string>();
            foreach (var line in lines)
            {
                var splittedLine = line
                    .Split(' ')
                    .Select(w => w.Trim(new char[] {'"', '.', ','}))
                    .ToList();
                words = words.Concat(splittedLine).ToList();
            }

            return words.ToArray();
        }
    }
}
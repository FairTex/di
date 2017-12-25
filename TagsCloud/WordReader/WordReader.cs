using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TagsCloud
{
    public class WordReader : IWordReader
    {
        public Result<IEnumerable<string>> Read(string filename)
        {
            return Result.Of(() => File.ReadAllLines(filename))
                .Then(lines => lines
                    .SelectMany(line => line.Split(' '))
                    .Select(word => word.Trim('"', '.', ',')))
                .RefineError("Произошла ошибка при чтении файла");
        }
    }
}
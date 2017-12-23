using System.Collections.Generic;

namespace TagsCloud
{
    public interface IHandler
    {
        IEnumerable<string> Handle(IEnumerable<string> words);
    }
}
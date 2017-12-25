using System.Collections.Generic;

namespace TagsCloud
{
    public interface IWordHandler
    {
        IEnumerable<string> Handle(IEnumerable<string> words);
    }
}

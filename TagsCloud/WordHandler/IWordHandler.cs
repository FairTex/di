using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud
{
    public interface IWordHandler
    {
        IEnumerable<string> Handle(IEnumerable<string> words);
    }
}

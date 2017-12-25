using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud
{
    public interface IWordHandler
    {
        string[] Handle(string[] words);
    }
}

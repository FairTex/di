using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud
{
    public interface IWordReader
    {
        Result<IEnumerable<string>> read(string filename);
    }
}

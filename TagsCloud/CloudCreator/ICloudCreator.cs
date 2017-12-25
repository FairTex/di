using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud
{
    public interface ICloudCreator
    {
        Result<None> Create();
    }
}

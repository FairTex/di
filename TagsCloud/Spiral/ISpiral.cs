using System.Collections.Generic;
using System.Drawing;

namespace TagsCloud
{
    public interface ISpiral
    {
        Point GetNextPoint();
        IEnumerable<Point> GetPoints();
    }
}
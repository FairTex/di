using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud
{
    public class Spiral
    {
        private Point Current { get; set; }

        private int PathLength { get; set; } = 1;
        private int CurrentLength { get; set; } = 0;
        private bool IsFirst { get; set; } = true;

        private Point[] Directions { get; set; }
        private int DirectionIndex { get; set; } = 0;

        private bool isFirstRequest { get; set; } = true;

        public Spiral(Point center, int scale = 1)
        {
            if (scale < 1)
            {
                throw new ArgumentException("scale must be positive and more than 1");
            }
            Current = center;
            Directions = new[] { new Point(-1 * scale, 0), new Point(0, scale), new Point(scale, 0), new Point(0, -1 * scale) };
        }

        public void Rotate()
        {
            DirectionIndex = (DirectionIndex + 1) % Directions.Length;
        }

        private bool MustRotate()
        {
            return CurrentLength >= PathLength;
        }

        private void UpdatePathLength()
        {
            if (!IsFirst)
            {
                PathLength++;
            }
        }


        public Point GetNextPoint()
        {
            if (isFirstRequest)
            {
                isFirstRequest = false;
                return Current;
            }

            if (MustRotate())
            {
                Rotate();
                UpdatePathLength();
                CurrentLength = 0;
                IsFirst = !IsFirst;
            }

            var dir = Directions[DirectionIndex];
            Current = new Point(Current.X + dir.X, Current.Y + dir.Y);
            CurrentLength++;

            return Current;
        }

        public IEnumerable<Point> GetPoints()
        {
            while (true)
            {
                yield return GetNextPoint();
            }
        }
    }
}

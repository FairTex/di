using System;
using System.Collections.Generic;
using System.Drawing;

namespace TagsCloud
{
    public class Spiral : ISpiral
    {
        private Point Current { get; set; }

        private int PathLength { get; set; } = 1;
        private int CurrentLength { get; set; }
        private bool IsFirst { get; set; } = true;

        private Point[] Directions { get; }
        private int DirectionIndex { get; set; }

        private bool IsFirstRequest { get; set; } = true;

        public Spiral(Config config, int scale = 5)
        {
            if (scale < 1)
            {
                throw new ArgumentException("scale must be positive and more than 1");
            }
            Current = config.Center;
            Directions = new[] { new Point(-1 * scale, 0), new Point(0, scale), new Point(scale, 0), new Point(0, -1 * scale) };
        }

        private void Rotate()
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
            if (IsFirstRequest)
            {
                IsFirstRequest = false;
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

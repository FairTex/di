using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TagsCloud
{
    public class CircularCloudLayouter : ICircularCloudLayouter
    {
        private Point Center { get; }
        private ISpiral Spiral { get; }
        private List<Rectangle> Rectangles { get; }

        public CircularCloudLayouter(Config config, ISpiral spiral)
        {
            Center = config.Center;
            Spiral = spiral;
            Rectangles = new List<Rectangle>();
        }

        public Rectangle PutNextRectangle(Size rectangleSize)
        {
            while (true)
            {
                var nextPoint = Spiral.GetNextPoint();
                var rectangle = new Rectangle(Shift(nextPoint, rectangleSize), rectangleSize);

                if (!DoesIntersect(rectangle))
                {
                    if (Rectangles.Count > 0)
                        rectangle = TryShiftToCenter(rectangle);

                    Rectangles.Add(rectangle);
                    return rectangle;
                }
            }
        }

        private bool DoesIntersect(Rectangle rectangle)
        {
            return Rectangles.Any(r => r.IntersectsWith(rectangle));
        }

        private Rectangle TryShiftToCenter(Rectangle rectangle)
        {
            var center = GetCenter(rectangle);

            var direction = new Point(-1 * BoolToInt(center.X > Center.X), -1 * BoolToInt(center.Y > Center.Y));

            rectangle = ShiftWhilePossible(rectangle, new Point(direction.X, 0));
            rectangle = ShiftWhilePossible(rectangle, new Point(0, direction.Y));
            return rectangle;
        }

        private int BoolToInt(bool value)
        {
            return value ? 1 : -1;
        }

        private Rectangle ShiftWhilePossible(Rectangle r, Point direction)
        {
            while (true)
            {
                var newPoint = new Point(r.X + direction.X, r.Y + direction.Y);


                var newRectangle = new Rectangle(newPoint, r.Size);
                if (!DoesIntersect(newRectangle))
                {
                    r = newRectangle;
                }
                else
                {
                    return r;
                }

                if (NearTheCenter(newRectangle, direction))
                    return r;
            }
        }

        private bool NearTheCenter(Rectangle r, Point direction)
        {
            return (r.X == Center.X && direction.Y == 0) || (r.Y == Center.Y && direction.X == 0);
        }

        private Point GetCenter(Rectangle rectangle)
        {
            return new Point(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2);
        }

        private Point Shift(Point p, Size s)
        {
            return new Point(p.X - s.Width / 2, p.Y - s.Height / 2);
        }


        public Rectangle[] GetRectangles()
        {
            return Rectangles.ToArray();
        }
    }
}
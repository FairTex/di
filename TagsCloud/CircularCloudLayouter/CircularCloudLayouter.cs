using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TagsCloud
{
    public class CircularCloudLayouter : ICircularCloudLayouter
    {
        private readonly Config config;
        private ISpiral Spiral { get; set; }
        private List<Rectangle> Rectangles { get; set; }

        public CircularCloudLayouter(Config config, ISpiral spiral)
        {
            this.config = config;
            Spiral = spiral;
            Rectangles = new List<Rectangle>();
        }

        public Result<Rectangle> PutNextRectangle(Size rectangleSize)
        {
            while (true)
            {
                var nextPoint = Spiral.GetNextPoint();
                var rectangle = new Rectangle(Shift(nextPoint, rectangleSize), rectangleSize);

                if (!DoesIntersect(rectangle))
                {
                    if (Rectangles.Count > 0)
                        rectangle = TryShiftToCenter(rectangle);

                    if (!config.Canvas.Contains(rectangle))
                    {
                        return Result.Fail<Rectangle>("Облако тегов не влезло на изображение данного размера");
                    }

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

            var direction = new Point(-1 * BoolToInt(center.X > config.Center.X), -1 * BoolToInt(center.Y > config.Center.Y));

            rectangle = ShiftWhilePossible(rectangle, new Point(direction.X, 0));
            rectangle = ShiftWhilePossible(rectangle, new Point(0, direction.Y));
            return rectangle;
        }

        private int BoolToInt(bool value)
        {
            return value ? 1 : -1;
        }

        private Rectangle ShiftWhilePossible(Rectangle rectangle, Point direction)
        {
            while (true)
            {
                var newPoint = new Point(rectangle.X + direction.X, rectangle.Y + direction.Y);

                var newRectangle = new Rectangle(newPoint, rectangle.Size);
                if (!DoesIntersect(newRectangle))
                {
                    rectangle = newRectangle;
                }
                else
                {
                    return rectangle;
                }

                if (NearTheCenter(newRectangle, direction))
                    return rectangle;
            }
        }

        private bool NearTheCenter(Rectangle rectangle, Point direction)
        {
            return (rectangle.X == config.Center.X && direction.Y == 0) || (rectangle.Y == config.Center.Y && direction.X == 0);
        }

        private Point GetCenter(Rectangle rectangle)
        {
            return new Point(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2);
        }

        private Point Shift(Point point, Size size)
        {
            return new Point(point.X - size.Width / 2, point.Y - size.Height / 2);
        }


        public Rectangle[] GetRectangles()
        {
            return Rectangles.ToArray();
        }
    }
}
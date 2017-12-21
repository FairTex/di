using System.Drawing;

namespace TagsCloud
{
    public class BrushGenerator : IBrushGenerator
    {
        private int BrushIndex { get; set; } = 0;
        private Brush[] BrushesList { get; }

        public BrushGenerator()
        {
            BrushesList = new[]
            {
                Brushes.Blue, Brushes.Azure, Brushes.BlueViolet, Brushes.Green, Brushes.Yellow,
                Brushes.Coral, Brushes.Turquoise, Brushes.DarkOrange, Brushes.Khaki, Brushes.Pink
            };
        }

        public Brush GetBrush()
        {
            return BrushesList[BrushIndex++ % BrushesList.Length];
        }
    }
}
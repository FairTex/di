using System.Drawing;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace TagsCloud.Tests
{
    public class CircularCloudLayouter_Should
    {
        private readonly Point[] points = { new Point(0, 0) };
        private Mock<ISpiral> spiral;
        private Config config;
        [SetUp]
        public void SetUp()
        {
            spiral = new Mock<ISpiral>();
            spiral.Setup(s => s.GetNextPoint())
                .Returns(() => points[0]);
            config = new Config("", "", "", new Size(100, 100), 5);
        }


        [Test]
        public void PutNextRectangle_ShouldCallSpiralOnce()
        {
            var layouter = new CircularCloudLayouter(config, spiral.Object);
            layouter.PutNextRectangle(new Size(10, 10));

            spiral.Verify(s => s.GetNextPoint(), Times.Once);
        }

        [Test]
        public void PutNextRectangle_ShouldPutFirstRectangleOnCenter()
        {
            var layouter = new CircularCloudLayouter(config, spiral.Object);
            var rect = layouter.PutNextRectangle(new Size(10, 10));

            rect.ShouldBeEquivalentTo(new Rectangle(-5, -5, 10, 10));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace TagsCloud.Tests
{
    public class TagMaker_Should
    {
        [Test]
        public void Make_ShouldWorkCorrect()
        {
            var layouter = new Mock<ICircularCloudLayouter>();
            layouter.Setup(l => l.PutNextRectangle(It.IsAny<Size>()))
                .Returns<Size>((s) => new Rectangle(0, 0, 10, 10));

            var config = new Config("", "", "Arial", new Size(100, 100), 5);
            var tagMaker = new TagMaker(config, layouter.Object);
            var answer = new Dictionary<string, Rectangle> {{"s", new Rectangle(0, 0, 10, 10)}};

            tagMaker.Make(new[]{"s", "s", "s"}).ShouldBeEquivalentTo(answer);

        }
    }
}

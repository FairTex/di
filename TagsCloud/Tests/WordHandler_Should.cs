using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TagsCloud;

namespace TagsCloud.Tests
{
    public class WordHandler_Should
    {
        private Mock<IHandler> handler1;
        private Mock<IHandler> handler2;
        
        [SetUp]
        public void SetUp()
        {
            handler1 = new Mock<IHandler>();
            handler1.Setup(a => a.Handle(It.IsAny<string[]>()))
                .Returns<string[]>(strings => strings.Take(5).ToArray());

            handler2 = new Mock<IHandler>();
            handler2.Setup(a => a.Handle(It.IsAny<string[]>()))
                .Returns<string[]>(strings => strings.Select(s => s + ".").ToArray());
        }

        [NUnit.Framework.Test]
        public void Handle_ShouldCallHandlersOnlyOneTimes()
        {
            var handler = new WordHandler(new[] { handler1.Object, handler2.Object });
            handler.Handle(new[] { "1", "2", "2", "2", "2", "2" });

            handler1.Verify(a => a.Handle(It.IsAny<string[]>()), Times.Exactly(1));
            handler2.Verify(a => a.Handle(It.IsAny<string[]>()), Times.Exactly(1));
        }

        [Test]
        public void Handle_ShouldCallEveryHandlers()
        {
            var handler = new WordHandler(new[] { handler1.Object, handler2.Object });
            var result = handler.Handle(new[] { "1", "2", "2", "2", "2", "2" });

            result.ShouldBeEquivalentTo(new [] {"1.", "2.", "2.", "2.", "2." });
        }
    }
}

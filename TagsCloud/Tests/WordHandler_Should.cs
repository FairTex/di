using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace TagsCloud.Tests
{
    public class WordHandler_Should
    {
        private Mock<IWordFilter> handler1;
        private Mock<IWordFilter> handler2;
        
        [SetUp]
        public void SetUp()
        {
            handler1 = new Mock<IWordFilter>();
            handler1.Setup(a => a.ExcludeWords(It.IsAny<string[]>()))
                .Returns<string[]>(strings => strings.Take(5).ToArray());

            handler2 = new Mock<IWordFilter>();
            handler2.Setup(a => a.ExcludeWords(It.IsAny<string[]>()))
                .Returns<string[]>(strings => strings.Select(s => s + ".").ToArray());
        }

        [NUnit.Framework.Test]
        public void Handle_ShouldCallHandlersOnlyOneTimes()
        {
            var handler = new TextFilter(new[] { handler1.Object, handler2.Object });
            handler.ExcludeWords(new[] { "1", "2", "2", "2", "2", "2" });

            handler1.Verify(a => a.ExcludeWords(It.IsAny<string[]>()), Times.Exactly(1));
            handler2.Verify(a => a.ExcludeWords(It.IsAny<string[]>()), Times.Exactly(1));
        }

        [Test]
        public void Handle_ShouldCallEveryHandlers()
        {
            var handler = new TextFilter(new[] { handler1.Object, handler2.Object });
            var result = handler.ExcludeWords(new[] { "1", "2", "2", "2", "2", "2" });

            result.ShouldBeEquivalentTo(new [] {"1.", "2.", "2.", "2.", "2." });
        }
    }
}

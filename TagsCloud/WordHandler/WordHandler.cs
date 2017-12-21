using System;
using System.Linq;

namespace TagsCloud
{
    public class WordHandler : IWordHandler
    {
        public WordHandler(IHandler[] handlers)
        {
            Handlers = handlers;
        }

        private IHandler[] Handlers { get; }

        public string[] Handle(string[] words)
        {
            return Handlers.Aggregate(words, (word, handler) => handler.Handle(word));
        }
    }
}
using System.Linq;

namespace TagsCloud
{
    class WordHandler : IWordHandler
    {
        public string[] Handle(string[] words)
        {
            return words
                .Where(word => word.Trim().Length > 0)
                .Select(word => word.ToLower()).ToArray();
        }
    }
}
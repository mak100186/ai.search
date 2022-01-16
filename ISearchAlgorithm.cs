using System.Drawing;

namespace AI.Search
{
    public interface ISearchAlgorithm
    {
        void Add(Node node);
        bool ContainsState(Point state);
        bool Empty();
        Node Remove();
    }
}
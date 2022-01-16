using System.Drawing;

namespace AI.Search
{
    /// <summary>
    /// Used for depth first search
    /// </summary>
    public class StackFrontier : ISearchAlgorithm
    {
        protected readonly List<Node> _frontier;

        public StackFrontier()
        {
            _frontier = new List<Node>();
        }

        public void Add(Node node)
        {
            _frontier.Add(node);
        }

        public bool ContainsState(Point state)
        {
            return _frontier.Any(node => node.State.Equals(state));
        }

        public bool Empty()
        {
            return !_frontier.Any();
        }

        public virtual Node Remove()
        {
            if (Empty())
            {
                throw new Exception("empty frontier");
            }

            var node = _frontier.Last();
            _frontier.Remove(node);
            return node;
        }
    }
}
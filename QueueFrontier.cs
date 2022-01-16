namespace AI.Search
{
    /// <summary>
    /// Used for breath first search
    /// </summary>
    public class QueueFrontier : StackFrontier, ISearchAlgorithm
    {
        public override Node Remove()
        {
            if (Empty()) throw new Exception("empty frontier");

            var node = _frontier.First();
            _frontier.Remove(node);
            return node;
        }
    }
}
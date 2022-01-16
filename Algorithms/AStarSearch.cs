namespace AI.Search.Algorithms
{
    using System.Drawing;
    using Helpers;
    using Models;

    public class AStarSearch : BaseSearchAlgorithm
    {
        public AStarSearch(Point startPoint, Point endPoint) : base(startPoint, endPoint)
        {
        }

        public override Node Remove()
        {
            if (Empty()) throw new Exception("empty frontier");

            var selectedNode = Frontier.First();
            var smallestHeuristicDistance = GridHelpers.GetTotalHeuristicDistance(selectedNode, startPoint, endPoint);

            foreach (var node in Frontier)
            {
                if (node == selectedNode)
                    continue;

                var heuristicDistance = GridHelpers.GetTotalHeuristicDistance(node, startPoint, endPoint);

                if (heuristicDistance >= smallestHeuristicDistance)
                    continue;

                smallestHeuristicDistance = heuristicDistance;
                selectedNode = node;
            }

            Frontier.Remove(selectedNode);
            return selectedNode;
        }
    }
}
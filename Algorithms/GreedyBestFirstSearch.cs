using AI.Search.Models;

namespace AI.Search.Algorithms
{
    using System.Drawing;
    using Helpers;

    public class GreedyBestFirstSearch : BaseSearchAlgorithm
    {
        public GreedyBestFirstSearch(Point startPoint, Point endPoint) : base(startPoint, endPoint)
        {

        }

        public override Node Remove()
        {
            if (Empty()) throw new Exception("empty frontier");
            
            var selectedNode = Frontier.First();
            var smallestManhattanDistance = GridHelpers.GetManhattanDistance(selectedNode.State, endPoint);

            foreach (var node in Frontier)
            {
                if (node == selectedNode)
                    continue;
                
                var manhattanDistance = GridHelpers.GetManhattanDistance(node.State, endPoint);

                if (manhattanDistance >= smallestManhattanDistance) 
                    continue;

                smallestManhattanDistance = manhattanDistance;
                selectedNode = node;
            }

            Frontier.Remove(selectedNode);
            return selectedNode;
        }
    }
}
using AI.Search.Models;

namespace AI.Search.Algorithms
{
    using System.Drawing;

    public class GreedyBestFirstSearch : BaseSearchAlgorithm
    {
        public GreedyBestFirstSearch(Point startPoint, Point endPoint) : base(startPoint, endPoint)
        {

        }

        public override Node Remove()
        {
            if (Empty()) throw new Exception("empty frontier");
            
            var selectedNode = Frontier.First();
            var smallestManhattanDistance = GetManhattanDistance(selectedNode.State, endPoint);

            foreach (var node in Frontier)
            {
                if (node == selectedNode)
                    continue;
                
                var manhattanDistance = GetManhattanDistance(node.State, endPoint);

                if (manhattanDistance >= smallestManhattanDistance) 
                    continue;

                smallestManhattanDistance = manhattanDistance;
                selectedNode = node;
            }

            Frontier.Remove(selectedNode);
            return selectedNode;
        }

        private int GetManhattanDistance(Point current, Point end)
        {
            var differenceInX = Math.Abs(current.X - endPoint.X);
            var differenceInY = Math.Abs(current.Y - endPoint.Y);

            var manhattanDistance = differenceInX + differenceInY;

            return manhattanDistance;
        }
    }
}
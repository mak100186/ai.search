namespace AI.Search.Helpers
{
    using System.Drawing;
    using Models;

    public static class GridHelpers
    {
        public static int GetManhattanDistance(Point current, Point end)
        {
            var differenceInX = Math.Abs(current.X - end.X);
            var differenceInY = Math.Abs(current.Y - end.Y);

            var manhattanDistance = differenceInX + differenceInY;

            return manhattanDistance;
        }

        public static int GetHeuristicDistanceToEnd(Node node, Point end)
        {
            return GetManhattanDistance(node.State, end);
        }

        public static int GetDistanceToStart(Node node, Point start)
        {
            var distance = 0;
            while (node.State == start)
            {
                distance++;
                
                if (node.Parent == null)
                    break;

                node = node.Parent;
            }

            return distance;
        }

        public static int GetTotalHeuristicDistance(Node node, Point start, Point end)
        {
            return GetHeuristicDistanceToEnd(node, end) + GetDistanceToStart(node, start);
        }
    }
}
namespace AI.Search.Algorithms;

using System.Drawing;
using Enums;

public static class AlgorithmFactory
{
    public static ISearchAlgorithm GetAlgorithm(AlgorithmTypes type, Point startPoint, Point endPoint)
    {
        return type switch
        {
            AlgorithmTypes.BreadthFirstSearch => new BreadthFirstSearch(startPoint, endPoint),
            AlgorithmTypes.DepthFirstSearch => new DepthFirstSearch(startPoint, endPoint),
            AlgorithmTypes.GreedyBestFirstSearch => new GreedyBestFirstSearch(startPoint, endPoint),
            AlgorithmTypes.AStarSearch => new AStarSearch(startPoint, endPoint),
            _ => throw new Exception("Unknown algorithm type passed into factory"),
        };
    }
}
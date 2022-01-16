namespace AI.Search.Algorithms;

using System.Drawing;
using Enums;

public class AlgorithmFactory
{
    public ISearchAlgorithm GetAlgorithm(AlgorithmTypes type, Point startPoint, Point endPoint)
    {
        switch (type)
        {
            case AlgorithmTypes.BreadthFirstSearch:
                return new BreadthFirstSearch(startPoint, endPoint);
            
            case AlgorithmTypes.DepthFirstSearch:
                return new DepthFirstSearch(startPoint, endPoint);

            case AlgorithmTypes.GreedyBestFirstSearch:
                return new GreedyBestFirstSearch(startPoint, endPoint);

            default:
            case AlgorithmTypes.All:
                throw new Exception("Unknown algorithm type passed into factory");
            
        }
    }
}
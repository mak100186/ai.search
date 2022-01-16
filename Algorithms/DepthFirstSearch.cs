namespace AI.Search.Algorithms;

using System.Drawing;
using Models;

/// <summary>
///     Uses a stack
/// </summary>
public class DepthFirstSearch : BaseSearchAlgorithm
{
    public DepthFirstSearch(Point startPoint, Point endPoint) : base(startPoint, endPoint)
    {

    }

    public override Node Remove()
    {
        if (Empty()) throw new Exception("empty frontier");

        var node = Frontier.Last();
        Frontier.Remove(node);
        return node;
    }
}
namespace AI.Search.Algorithms;

using System.Drawing;
using Models;

/// <summary>
///     Used for breath first search
/// </summary>
public class BreadthFirstSearch : BaseSearchAlgorithm
{
    public BreadthFirstSearch(Point startPoint, Point endPoint) : base(startPoint, endPoint)
    {

    }

    public override Node Remove()
    {
        if (Empty()) throw new Exception("empty frontier");

        var node = Frontier.First();
        Frontier.Remove(node);
        return node;
    }
}
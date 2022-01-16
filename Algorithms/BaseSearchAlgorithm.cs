namespace AI.Search.Algorithms;

using System.Drawing;
using Models;

public abstract class BaseSearchAlgorithm : ISearchAlgorithm
{
    protected readonly List<Node> Frontier;
    protected readonly Point startPoint;
    protected readonly Point endPoint;

    protected BaseSearchAlgorithm(Point startPoint, Point endPoint)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        Frontier = new List<Node>();
    }

    public void Add(Node node)
    {
        Frontier.Add(node);
    }

    public bool ContainsState(Point state)
    {
        return Frontier.Any(node => node.State.Equals(state));
    }

    public bool Empty()
    {
        return !Frontier.Any();
    }

    public abstract Node Remove();
}
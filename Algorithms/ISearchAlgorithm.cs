namespace AI.Search.Algorithms;

using System.Drawing;
using Models;

public interface ISearchAlgorithm
{
    void Add(Node node);
    bool ContainsState(Point state);
    bool Empty();
    Node Remove();
}
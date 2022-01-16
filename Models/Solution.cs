namespace AI.Search.Models;

using System.Drawing;
using Enums;

public class Solution
{
    public List<ActionTypes> Actions;
    public List<Point> Cells;

    public Solution(List<ActionTypes> actions, List<Point> cells)
    {
        Actions = actions;
        Cells = cells;
    }

    public void Deconstruct(out List<ActionTypes> actions, out List<Point> cells)
    {
        actions = Actions;
        cells = Cells;
    }
}
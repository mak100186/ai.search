namespace AI.Search.Models;

using System.Drawing;
using Enums;

public class Action
{
    public Action(ActionTypes action, Point cell)
    {
        ActionType = action;
        Cell = cell;
    }

    public ActionTypes ActionType { get; set; }
    public Point Cell { get; set; }

    public void Deconstruct(out ActionTypes action, out Point cell)
    {
        action = ActionType;
        cell = Cell;
    }
}
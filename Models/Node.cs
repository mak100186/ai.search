namespace AI.Search.Models;

using System.Drawing;
using Enums;

public class Node
{
    public Node(Node? parent, Point state, ActionTypes action = ActionTypes.None)
    {
        Parent = parent;
        State = state;
        Action = action;
    }

    public Node? Parent { get; set; }

    public Point State { get; set; }

    public ActionTypes Action { get; set; }

    public static Node GetEmptyNode()
    {
        return new Node(null, new Point(-1, -1));
    }

    public static Node GetStartNode(Point state)
    {
        return new Node(null, state);
    }

    public void Deconstruct(out Node? parent, out Point state, out ActionTypes action)
    {
        action = Action;
        state = State;
        parent = Parent;
    }
}
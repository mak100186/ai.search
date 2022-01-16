using System.Drawing;

namespace AI.Search
{
    public class Node
    {
        public static Node GetEmptyNode()
        {
            return new Node(null, new Point(-1, -1), ActionType.None);
        }

        public static Node GetStartNode(Point state)
        {
            return new Node(null, state, ActionType.None);
        }

        public Node(Node? parent, Point state, ActionType action = ActionType.None)
        {
            Parent = parent;
            State = state;
            Action = action;
        }

        public Node? Parent { get; set; }

        public Point State { get; set; }

        public ActionType Action { get; set; }

        public void Deconstruct(out Node? parent, out Point state, out ActionType action)
        {
            action = Action;
            state = State;
            parent = Parent;
        }
    }
}
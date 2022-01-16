using System.Drawing;

namespace AI.Search
{
    public class Action
    {
        public ActionType ActionType { get; set; }
        public Point Cell { get; set; }

        public Action(ActionType action, Point cell)
        {
            ActionType = action;
            Cell = cell;
        }

        public void Deconstruct(out ActionType action, out Point cell)
        {
            action = ActionType;
            cell = Cell;
        }
    }
}
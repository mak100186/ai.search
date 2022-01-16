using System.Drawing;

namespace AI.Search
{
    public class Solution
    {
        public List<ActionType> Actions;
        public List<Point> Cells;

        public Solution(List<ActionType> actions, List<Point> cells)
        {
            Actions = actions;
            Cells = cells;
        }

        public void Deconstruct(out List<ActionType> actions, out List<Point> cells)
        {
            actions = Actions;
            cells = Cells;
        }
    }
}
using System.Drawing;

namespace AI.Search
{
    public class Maze
    {
        private readonly int _width;
        private readonly int _height;
        private readonly Point _start;
        private readonly Point _end;

        private readonly Grid<bool> _walls;
        private HashSet<Point> _explored;
        private int _exploredCount;

        private Solution? _solution;

        private string _filename;
        private AlgorithmType _algoType;

        public Maze(string filename)
        {
            _walls = new Grid<bool>();
            _explored = new HashSet<Point>();
            _solution = null;

            var assemblyDirectory = PathHelper.AssemblyDirectory;
            if (string.IsNullOrWhiteSpace(assemblyDirectory))
            {
                throw new Exception("Could not locate assembly directory");
            }

            _filename = filename;
            var fullFilePath = Path.Combine(assemblyDirectory, filename);
            var lines = File.ReadAllLines(fullFilePath).ToList();

            var startPoints = 0;
            var endPoints = 0;

            _height = lines.Count;
            for (var y = 0; y < _height; y++)
            {
                var line = lines[y];

                var row = line
                    .Select(c => c.ToString())
                    .Select(character => character is not (
                        Constants.EndingPointCharacter or 
                        Constants.StartingPointCharacter or 
                        Constants.EmptyCharacter))
                    .ToList();

                _walls.Add(row);

                if (line.Length > _width)
                {
                    _width = line.Length;
                }

                if (line.Contains(Constants.StartingPointCharacter))
                {
                    var x = line.IndexOf(Constants.StartingPointCharacter, StringComparison.CurrentCulture);

                    _start = new Point(x, y);

                    startPoints++;
                }

                if (line.Contains(Constants.EndingPointCharacter))
                {
                    var x = line.IndexOf(Constants.EndingPointCharacter, StringComparison.CurrentCulture);

                    _end = new Point(x, y);

                    endPoints++;
                }
            }

            if (startPoints != 1)
            {
                throw new Exception("maze must have exactly one start point");
            }

            if (endPoints != 1)
            {
                throw new Exception("maze must have exactly one end point");
            }
        }

        public void SaveImage()
        {
            var assemblyDirectory = PathHelper.AssemblyDirectory;
            if (string.IsNullOrWhiteSpace(assemblyDirectory))
            {
                throw new Exception("Could not locate assembly directory");
            }

            var filePath = Path.Combine(assemblyDirectory, $"{_algoType}-{_filename}.png");

            ImageHelper.CreateImage(_width, _height, _walls, _start, _end, _solution, _explored, filePath);
        }

        public Grid<string>? GetPrintable()
        {
            var grid = new Grid<string>();

            for (var y = 0; y < _height; y++)
            {
                var row = new List<string>();
                for (var x = 0; x < _width; x++)
                {
                    var currentPoint = new Point(x, y);
                    var isWall = _walls.Get(currentPoint);

                    if (isWall)
                    {
                        row.Add(Constants.WallCharacter);
                    }
                    else
                    {
                        if (_start == currentPoint)
                        {
                            row.Add(Constants.StartingPointCharacter);
                        }
                        else if (_end == currentPoint)
                        {
                            row.Add(Constants.EndingPointCharacter);
                        }
                        else if (_solution != null && _solution.Cells.Contains(currentPoint))
                        {
                            row.Add(Constants.PathCharacter);
                        }
                        else
                        {
                            row.Add(Constants.EmptyCharacter);
                        }
                    }
                }
                grid.Add(row);
            }

            return grid;
        }

        private List<Action> Neighbors(Point state)
        {
            var col = state.X;
            var row = state.Y;

            var candidates = new List<Action>
            {
                new (ActionType.Up, new Point(col, row - 1)),
                new (ActionType.Down, new Point(col, row + 1)),
                new (ActionType.Left, new Point(col - 1, row)),
                new (ActionType.Right, new Point(col + 1, row))
            };

            var results = new List<Action>();

            foreach (var (action, cell) in candidates)
            {
                if (0 <= cell.X && cell.X < _width && 0 <= cell.Y && cell.Y < _height && !_walls.Get(cell))
                {
                    results.Add(new Action(action, cell));
                }
            }

            return results;
        }

        public int Solve(AlgorithmType algorithm)
        {
            _algoType = algorithm;
            _exploredCount = 0;
            _explored = new HashSet<Point>();
            _solution = null;

            var startNode = Node.GetStartNode(_start);
            var frontier = new AlgorithmFactory().GetAlgorithm(algorithm);
            frontier.Add(startNode);

            while (true)
            {
                if (frontier.Empty())
                {
                    throw new Exception("no solution found");
                }

                var frontierNode = frontier.Remove();
                _exploredCount++;

                if (frontierNode.State == _end)
                {
                    var actions = new List<ActionType>();
                    var cells = new List<Point>();

                    while (frontierNode.Parent != null)
                    {
                        actions.Add(frontierNode.Action);
                        cells.Add(frontierNode.State);

                        frontierNode = frontierNode.Parent;
                    }

                    actions.Reverse();
                    cells.Reverse();

                    _solution = new Solution(actions, cells);
                    break;
                }

                _explored.Add(frontierNode.State);

                foreach (var (action, state) in Neighbors(frontierNode.State))
                {
                    if (!frontier.ContainsState(state) && !_explored.Contains(state))
                    {
                        frontier.Add(new Node(frontierNode, state, action));
                    }
                }
            }

            return _exploredCount;
        }
    }
}
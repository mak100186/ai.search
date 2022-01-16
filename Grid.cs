using System.Collections;
using System.Drawing;

namespace AI.Search
{
    public class Grid<T> : IEnumerable where T : IConvertible
    {
        private readonly List<List<T>> _grid;

        public Grid()
        {
            _grid = new List<List<T>>();
        }

        public void Add(List<T> row)
        {
            _grid.Add(row);
        }

        public T Get(Point cell)
        {
            return _grid[cell.Y][cell.X];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public GridEnumerator<T> GetEnumerator()
        {
            return new GridEnumerator<T>(_grid);
        }
    }

    public class GridEnumerator<T>: IEnumerator where T : IConvertible
    {
        private List<List<T>> _grid;
        private int position = -1;

        public GridEnumerator(List<List<T>> grid)
        {
            _grid = grid;
        }

        object IEnumerator.Current 
        {
            get
            {
                return Current;
            }
        } 

        public bool MoveNext()
        {
            position++;
            return position < _grid.Count;
        }

        public void Reset()
        {
            position = -1;
        }
        public List<T> Current
        {
            get
            {
                try
                {
                    return _grid[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
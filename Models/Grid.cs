namespace AI.Search.Models;

using System.Collections;
using System.Drawing;

public class Grid<T> : IEnumerable where T : IConvertible
{
    private readonly List<List<T>> _grid;

    public Grid()
    {
        _grid = new List<List<T>>();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(List<T> row)
    {
        _grid.Add(row);
    }

    public T Get(Point cell)
    {
        return _grid[cell.Y][cell.X];
    }

    public GridEnumerator<T> GetEnumerator()
    {
        return new GridEnumerator<T>(_grid);
    }
}

public class GridEnumerator<T> : IEnumerator where T : IConvertible
{
    private readonly List<List<T>> _grid;
    private int _position = -1;

    public GridEnumerator(List<List<T>> grid)
    {
        _grid = grid;
    }

    public List<T> Current
    {
        get
        {
            try
            {
                return _grid[_position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        _position++;
        return _position < _grid.Count;
    }

    public void Reset()
    {
        _position = -1;
    }
}
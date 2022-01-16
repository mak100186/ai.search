namespace AI.Search
{
    public static class GridExtensions
    {
        public static void Print<T>(this Grid<T>? grid) where T : IConvertible
        {
            if (grid == null) return;

            foreach (var row in grid) Console.WriteLine(string.Join("", row));
        }
    }
}
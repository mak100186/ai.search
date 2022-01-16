namespace AI.Search.Helpers;

using System.Drawing;
using System.Drawing.Imaging;
using Models;

public static class ImageHelper
{
    private const int CellSize = 50;
    private const int CellBorder = 2;
    private static readonly Color EmptyColor = Color.FromArgb(255, 237, 240, 252);
    private static readonly Color EndColor = Color.FromArgb(255, 0, 171, 28);
    private static readonly Color ExploredColor = Color.FromArgb(255, 212, 97, 85);
    private static readonly Color SolutionColor = Color.FromArgb(255, 220, 235, 113);
    private static readonly Color StartColor = Color.FromArgb(255, 255, 40, 40);
    private static readonly Color WallColor = Color.FromArgb(255, 40, 40, 40);

#pragma warning disable CA1416 // Validate platform compatibility
    public static void CreateImage(int width, int height, Grid<bool> walls, Point start, Point end, Solution? solution, HashSet<Point> explored, string outputImagePath)
    {
        var bitmap = new Bitmap(width * (CellSize + CellBorder), height * (CellSize + CellBorder), PixelFormat.Format32bppArgb);
        using (var g = Graphics.FromImage(bitmap))
        {
            for (var y = 0; y < height; y++)
            {
                var selectedColor = EmptyColor;

                for (var x = 0; x < width; x++)
                {
                    var cell = new Point(x, y);

                    if (walls.Get(cell))
                    {
                        selectedColor = WallColor;
                    }
                    else
                    {
                        if (cell == start)
                        {
                            selectedColor = StartColor;
                        }
                        else if (cell == end)
                        {
                            selectedColor = EndColor;
                        }
                        else if (solution != null)
                        {
                            if (solution.Cells.Contains(cell))
                                selectedColor = SolutionColor;
                            else if (explored.Contains(cell)) selectedColor = ExploredColor;
                        }
                    }

                    var rect = new Rectangle(
                        x * (CellSize + CellBorder),
                        y * (CellSize + CellBorder),
                        CellSize - CellBorder,
                        CellSize - CellBorder);

                    var brush = new SolidBrush(selectedColor);
                    g.FillRectangle(brush, rect);
                }
            }
        }

        bitmap.Save(outputImagePath);
    }
}
#pragma warning restore CA1416 // Validate platform compatibility
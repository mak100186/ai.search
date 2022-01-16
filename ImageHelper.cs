using System.Drawing;
using System.Drawing.Imaging;

namespace AI.Search
{
    public static class ImageHelper
    {
        private const int cellSize = 50;
        private const int cellBorder = 2;
        private static Color emptyColor = Color.FromArgb(255, 237, 240, 252);
        private static Color endColor = Color.FromArgb(255, 0, 171, 28);
        private static Color exploredColor = Color.FromArgb(255, 212, 97, 85);
        private static Color solutionColor = Color.FromArgb(255, 220, 235, 113);
        private static Color startColor = Color.FromArgb(255, 255, 40, 40);
        private static Color wallColor = Color.FromArgb(255, 40, 40, 40);

#pragma warning disable CA1416 // Validate platform compatibility
        public static void CreateImage(int width, int height, Grid<bool> walls, Point start, Point end, Solution? solution, HashSet<Point> explored, string outputImagePath)
        {
            var bitmap = new Bitmap(width * (cellSize + cellBorder), height * (cellSize + cellBorder), PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(bitmap))
            {
                for (var y = 0; y < height; y++)
                {
                    var selectedColor = emptyColor;

                    for (var x = 0; x < width; x++)
                    {
                        var cell = new Point(x, y);

                        if (walls.Get(cell))
                        {
                            selectedColor = wallColor;
                        }
                        else
                        {
                            if (cell == start)
                            {
                                selectedColor = startColor;
                            }
                            else if (cell == end)
                            {
                                selectedColor = endColor;
                            }
                            else if (solution != null)
                            {
                                if (solution.Cells.Contains(cell))
                                    selectedColor = solutionColor;
                                else if (explored.Contains(cell)) selectedColor = exploredColor;
                            }
                        }

                        var rect = new Rectangle(
                            x * (cellSize + cellBorder),
                            y * (cellSize + cellBorder),
                            (cellSize - cellBorder),
                            (cellSize - cellBorder));
                        
                        var brush = new SolidBrush(selectedColor);
                        g.FillRectangle(brush, rect);
                    }
                }
            }

            bitmap.Save(outputImagePath);
        }
    }
#pragma warning restore CA1416 // Validate platform compatibility
}
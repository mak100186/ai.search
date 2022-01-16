// See https://aka.ms/new-console-template for more information

using AI.Search;

while (true)
{
    string? filename;
    AlgorithmType algorithm;

    while (true)
    {
        while (true)
        {
            Console.WriteLine("Type 1 for StackFrontier (Depth first search) or 2 for QueueFrontier (Breadth first search) or 0 to run both:");
            var algorithmType = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(algorithmType) && Enum.TryParse(algorithmType, out AlgorithmType result))
            {
                algorithm = result;
                break;
            }
            Console.WriteLine("Invalid algorithm type.");
        }
        

        Console.WriteLine("Type maze filename with extension to run:");
        filename = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(filename))
        {
            break;
        }
    }

    try
    {
        var maze = new Maze(filename);

        maze.GetPrintable().Print();

        if (algorithm == AlgorithmType.Both)
        {
            var cost = maze.Solve(AlgorithmType.StackFrontier);
            
            maze.GetPrintable().Print();

            Console.WriteLine($"The total cost of StackFrontier (Depth first search) was: {cost}");

            cost = maze.Solve(AlgorithmType.QueueFrontier);

            Console.WriteLine($"The total cost of QueueFrontier (Breadth first search) was: {cost}");
            
        }
        else
        {
            var cost = maze.Solve(algorithm);

            Console.WriteLine($"The total cost was: {cost}");

            maze.GetPrintable().Print();

            maze.SaveImage();
        }
        
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

    Console.WriteLine("Press any key to reset or ESC to exit.");
    var keyInfo = Console.ReadKey();
    if (keyInfo.Key == ConsoleKey.Escape)
    {
        Environment.Exit(0);
    }

    Console.Clear();
}




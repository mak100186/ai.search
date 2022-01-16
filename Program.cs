using AI.Search.Enums;
using AI.Search.Extensions;
using AI.Search.Mazes;

while (true)
{
    string? filename;
    AlgorithmTypes algorithm;

    while (true)
    {
        while (true)
        {
            {
                foreach (AlgorithmTypes type in Enum.GetValues(typeof(AlgorithmTypes)))
                {
                    var intType = (int)type;
                    Console.WriteLine($"{intType} - {type}");
                }
            }
            Console.WriteLine("Type in number or name of the algorithm to run:");

            var algorithmType = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(algorithmType) && Enum.TryParse(algorithmType, out AlgorithmTypes result))
            {
                algorithm = result;
                break;
            }

            Console.WriteLine("Invalid algorithm type.");
        }


        Console.WriteLine("Type maze filename with extension to run:");
        filename = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(filename)) break;
    }

    try
    {
        var maze = new Maze(filename);

        maze.GetPrintable().Print();

        if (algorithm == AlgorithmTypes.All)
        {
            foreach (AlgorithmTypes algorithmType in Enum.GetValues(typeof(AlgorithmTypes)))
            {
                if (algorithmType == AlgorithmTypes.All)
                    continue;
                
                var cost = maze.Solve(algorithmType);

                maze.GetPrintable().Print();

                maze.SaveImage();

                Console.WriteLine($"The total cost of {algorithmType} was: {cost}");
            }
        }
        else
        {
            var cost = maze.Solve(algorithm);

            maze.GetPrintable().Print();

            maze.SaveImage();

            Console.WriteLine($"The total cost of {algorithm} was: {cost}");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

    Console.WriteLine("Press any key to reset or ESC to exit.");
    var keyInfo = Console.ReadKey();
    if (keyInfo.Key == ConsoleKey.Escape) Environment.Exit(0);

    Console.Clear();
}
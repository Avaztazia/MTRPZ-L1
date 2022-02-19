using EquationSolver.Backend.Contracts;
using EquationSolver.Backend.Models;
using EquationSolver.Backend.Processors;

internal static class Program
{
    private static readonly ISolutionProcessor _equationSolver;

    static Program()
    {
        _equationSolver = new DefaultSolverProcessor();
    }
    
    internal static void Main()
    {
        Console.Write("Enter file path or enter to use interactive mode: ");
        var filePath = Console.ReadLine();

        if (string.IsNullOrEmpty(filePath))
        {
            InteractiveMode();
        }
        else
        {
            NonInteractiveMode(filePath);
        }
    }

    private static void InteractiveMode()
    {
        var a = ReadFromConsole("Please enter A:", "A should be a real number");
        var b = ReadFromConsole("Please enter B:", "B should be a real number");
        var c = ReadFromConsole("Please enter C:", "C should be a real number");

        var solverRequest = new EquationData(a, b, c);
        var solverResponse = _equationSolver.SolveEquation(solverRequest);
        
        PrintResult(solverRequest, solverResponse);            
    }

    private static double ReadFromConsole(string requestText, string fallbackText)
    {
        var isFirstTry = true;
        var num = 0d;
        do
        {
            if (!isFirstTry)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(fallbackText);
                Console.ResetColor();
            }

            isFirstTry = false;
            Console.Write(requestText);
        } while (!double.TryParse(Console.ReadLine(), out num));

        return num;
    }

    private static void NonInteractiveMode(string filePath)
    {
        var fileInfo = new FileInfo(filePath);
        if (!fileInfo.Exists)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("File {0} is not exists", fileInfo.FullName);
            Console.ResetColor();
            
            Environment.Exit(0);
        }

        var numbersAsString = File.ReadAllLines(fileInfo.FullName)[0];

        var nums = numbersAsString.Split(' ');

        var a = GetNumber(nums[0],
            "Invalid parameter for A. It should be a number, but not a {0}");
        var b = GetNumber(nums[1],
            "Invalid parameter for A. It should be a number, but not a {0}");
        var c = GetNumber(nums[2],
            "Invalid parameter for A. It should be a number, but not a {0}");
        
        var solverRequest = new EquationData(a, b, c);
        var solverResponse = _equationSolver.SolveEquation(solverRequest);
        
        PrintResult(solverRequest, solverResponse);
    }

    private static void PrintResult(EquationData inputData, SolverResponse solverResponse)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"({inputData.A})x^2 + ({inputData.B})x + ({inputData.C}) = 0");
        Console.ResetColor();
        
        Console.WriteLine("There are " + solverResponse.RootsAmount);
        foreach (var root in solverResponse.Roots)
        {
            Console.WriteLine("Root: " + root);
        }
    }

    private static double GetNumber(string numAsString, string fallbackText)
    {
        var isParseSuccess = double.TryParse(numAsString, out var num);

        if (isParseSuccess)
        {
            return num;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(fallbackText, numAsString);
        Console.ResetColor();

        Environment.Exit(0);
        return double.NaN;
    }
}

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
        
        Console.WriteLine("There are " + solverResponse.RootsAmount);
        foreach (var root in solverResponse.Roots)
        {
            Console.WriteLine("Root: " + root);
        }
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
        throw new NotImplementedException();
    }
}

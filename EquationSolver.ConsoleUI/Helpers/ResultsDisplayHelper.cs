using EquationSolver.Backend.Models;

namespace EquationSolver.ConsoleUI.Helpers;

internal static class ResultsDisplayHelper
{
    public static void PrintResult(EquationData inputData, SolverResponse solverResponse)
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
}
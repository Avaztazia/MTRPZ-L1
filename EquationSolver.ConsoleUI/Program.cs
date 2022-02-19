using EquationSolver.ConsoleUI.Contracts;
using EquationSolver.ConsoleUI.Processors;

namespace EquationSolver.ConsoleUI;

internal static class Program
{
    internal static void Main()
    {
        IApplicationFlowProcessor applicationFlowProcessor = new ApplicationFlowProcessor();
        Console.Write("Enter file path or enter to use interactive mode: ");
        var filePath = Console.ReadLine();

        if (string.IsNullOrEmpty(filePath))
        {
            applicationFlowProcessor.InteractiveMode();
        }
        else
        {
            applicationFlowProcessor.NonInteractiveMode(filePath);
        }

        Console.ReadKey();
    }
}
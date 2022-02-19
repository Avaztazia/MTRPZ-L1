using EquationSolver.Backend.Contracts;
using EquationSolver.Backend.Models;
using EquationSolver.Backend.Processors;
using EquationSolver.ConsoleUI.Contracts;
using EquationSolver.ConsoleUI.Helpers;

namespace EquationSolver.ConsoleUI.Processors;

internal class ApplicationFlowProcessor : IApplicationFlowProcessor
{
    private readonly IEquationSolverProcessor _solverProcessor;

    public ApplicationFlowProcessor()
    {
        _solverProcessor = new DefaultEquationSolverProcessor();
    }

    public void InteractiveMode()
    {
        var a = NumbersParseHelper.ParseNumberFromConsole(
            "Please enter A:",
            "A should be a real number");
        var b = NumbersParseHelper.ParseNumberFromConsole(
            "Please enter B:",
            "B should be a real number");
        var c = NumbersParseHelper.ParseNumberFromConsole(
            "Please enter C:",
            "C should be a real number");

        var solverRequest = new EquationData(a, b, c);
        var solverResponse = _solverProcessor.Solve(solverRequest);
        
        ResultsDisplayHelper.PrintResult(solverRequest, solverResponse);            
    }

    public void NonInteractiveMode(string filePath)
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

        var a = NumbersParseHelper.ParseNumberFromString(nums[0],
            "Invalid parameter for A. It should be a number, but not a {0}");
        var b = NumbersParseHelper.ParseNumberFromString(nums[1],
            "Invalid parameter for A. It should be a number, but not a {0}");
        var c = NumbersParseHelper.ParseNumberFromString(nums[2],
            "Invalid parameter for A. It should be a number, but not a {0}");
        
        var solverRequest = new EquationData(a, b, c);
        var solverResponse = _solverProcessor.Solve(solverRequest);
        
        ResultsDisplayHelper.PrintResult(solverRequest, solverResponse);
    }
}
namespace EquationSolver.ConsoleUI.Contracts;

internal interface IApplicationFlowProcessor
{
    void InteractiveMode();
    void NonInteractiveMode(string filePath);
}
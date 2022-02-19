namespace EquationSolver.Backend.Models;

public class SolverResponse
{
    public int RootsAmount { get; }
    public List<double> Roots { get; init; }

    public SolverResponse(int rootsAmount)
    {
        RootsAmount = rootsAmount;
        Roots = new List<double>(rootsAmount);
    }
}
namespace EquationSolver.Backend.Models;

public class SolverResponse
{
    public int RootsAmount { get; set; }
    public List<double> Roots { get; set; }

    public SolverResponse()
    {
        Roots = new List<double>(0);
    }
}
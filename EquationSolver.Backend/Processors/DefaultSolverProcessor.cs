using EquationSolver.Backend.Contracts;
using EquationSolver.Backend.Models;

namespace EquationSolver.Backend.Processors;

public class DefaultSolverProcessor : ISolutionProcessor
{
    public SolverResponse SolveEquation(EquationData input)
    {
        var discriminant = Math.Pow(input.B, 2) - 4 * input.A * input.C;

        return discriminant switch
        {
            > 0 => CreateSolverResponse(2, FindRoots(input, discriminant)),
            0 => CreateSolverResponse(1, FindRoots(input, discriminant)),
            _ => CreateSolverResponse(0, FindRoots(input, discriminant))
        };
    }

    private double[] FindRoots(EquationData input, double discriminant)
    {
        return discriminant switch
        {
            > 0 => new[] {
                (-input.B - Math.Sqrt(discriminant)) / (2 * input.A),
                (-input.B + Math.Sqrt(discriminant)) / (2 * input.A)},
            0 => new[] {-input.B / (2 * input.A)},
            _ => Array.Empty<double>()
        };
    }

    private SolverResponse CreateSolverResponse(int rootsAmount, IReadOnlyCollection<double> roots)
    {
        if (roots.Count != rootsAmount)
        {
            throw new ArgumentException("Roots amount is not the same as expected");
        }

        return new SolverResponse(rootsAmount)
        {
            Roots = roots.ToList()
        };
    }
}
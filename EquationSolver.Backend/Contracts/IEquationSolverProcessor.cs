using EquationSolver.Backend.Models;

namespace EquationSolver.Backend.Contracts;

public interface IEquationSolverProcessor
{
    SolverResponse Solve(EquationData input);
}
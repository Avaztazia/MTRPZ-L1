using EquationSolver.Backend.Models;

namespace EquationSolver.Backend.Contracts;

public interface ISolutionProcessor
{
    SolverResponse SolveEquation(EquationData input);
}
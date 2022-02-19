namespace EquationSolver.Backend.Models;

public class EquationData
{
    public double A { get; }
    public double B { get; }
    public double C { get; }

    public EquationData(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }
}
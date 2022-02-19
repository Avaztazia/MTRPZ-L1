namespace EquationSolver.Backend.Models;

public class EquationData
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public EquationData(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }
}
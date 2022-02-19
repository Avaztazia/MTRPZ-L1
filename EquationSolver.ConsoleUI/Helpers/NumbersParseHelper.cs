namespace EquationSolver.ConsoleUI.Helpers;

internal static class NumbersParseHelper
{
    public static double ParseNumberFromConsole(string requestText, string fallbackText)
    {
        var isFirstTry = true;
        double num;
        do
        {
            if (!isFirstTry)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(fallbackText);
                Console.ResetColor();
            }

            isFirstTry = false;
            Console.Write(requestText);
        } while (!double.TryParse(Console.ReadLine(), out num));

        return num;
    }

    public static double ParseNumberFromString(string numAsString, string fallbackText)
    {
        var isParseSuccess = double.TryParse(numAsString, out var num);

        if (isParseSuccess)
        {
            return num;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(fallbackText, numAsString);
        Console.ResetColor();

        Environment.Exit(0);
        return double.NaN;
    }
}
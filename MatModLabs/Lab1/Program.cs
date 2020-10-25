using System;
using Lab1.Services;
using Lab1.Services.EqualityFormula;
using Lab1.Services.Generators;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = 1000;
            var ranges = 10;

            var firstMethodArray = new MiddleSquareMethod().GenerateArray(seed: 3559, size: size);

            var secondMethodArray = new MultiplyingCongruentMethod(amountM: (int) Math.Pow(2, 14), amountK: 5003)
                .GenerateArray(seed: 0.3187, size: size);

            new EqualityTester().ShowTestingDiagram(firstMethodArray, ranges);

            Console.WriteLine();

            new EqualityTester().ShowTestingDiagram(secondMethodArray, ranges);

            Console.ReadKey();
        }
    }
}

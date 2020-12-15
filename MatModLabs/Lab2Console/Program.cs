using System;
using System.Collections.Generic;
using System.Linq;
using Lab2Console.Services;
using Library.Services;
using Library.Services.EqualityFormula;
using Library.Services.Generators;
using Library.Services.IndependenceFormula;
using Library.Services.InverseFunctionMethod;

namespace Lab2Console
{
    class Program
    {
        private static int Size = 17;

        static void Main(string[] args)
        {
            var generated = Generate();

            new EqualityTester().ShowTestingDiagram(generated, 10);

            TrustIntervals(generated);

            Console.ReadKey();
        }

        private static IEnumerable<double> Generate()
        {
            var generatedX = new MultiplyingCongruentMethod((int) Math.Pow(2, 14), amountK: 5017)
                .GenerateArray(0.318, Size).ToList();

            var shiftedX = new ConvertToRangeService().Convert(generatedX, -0.5, 0.5);

            var calculatedY = new SpreadLawService().Calculate(shiftedX);

            var shiftedY = new ConvertToRangeService().Convert(calculatedY, 0, 1);

            return shiftedY;
        }

        private static void TrustIntervals(IEnumerable<double> values)
        {
            var interval1 = new MathematicalExpectationIntervalService().GetInterval(values);
            Console.WriteLine($"Доверительный интервал для мат ожидания: {interval1.Left} < M < {interval1.Right}");

            var interval2 = new DispersionIntervalsService().GetInterval(values);
            Console.WriteLine($"Доверительный интервал для дисперсии: {interval2.Left} < M < {interval2.Right}");
        }
    }
}

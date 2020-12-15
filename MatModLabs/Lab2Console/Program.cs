using System;
using System.Collections.Generic;
using System.Linq;
using Lab2Console.Services;
using Library.Services;
using Library.Services.EqualityFormula;
using Library.Services.Generators;
using Library.Services.InverseFunctionMethod;

namespace Lab2Console
{
    class Program
    {
        private static int Size = 17;

        private static int Intervals = 10;

        static void Main(string[] args)
        {
            var generated = Generate();

            new EqualityTester().ShowTestingDiagram(generated, Intervals);

            TrustIntervals(generated);
            PirsonCriteria(generated);

            Console.ReadKey();
        }

        private static IEnumerable<double> Generate()
        {
            var generatedX = new MultiplyingCongruentMethod((int) Math.Pow(2, 14), amountK: 5017)
                .GenerateArray(0.318, Size).ToList();

            var shiftedX = new ConvertToRangeService().Convert(generatedX, -0.5, 0.5);

            var calculatedY = new SpreadLawService().Calculate(shiftedX);

            return calculatedY;
        }

        private static void TrustIntervals(IEnumerable<double> values)
        {
            var average = values.Average();
            Console.WriteLine(
                $"Точечные: мат ожидание - {average}, дисперсия - {(1.0 / values.Count() - 1.0) * values.Sum(val => Math.Pow(val - average, 2))}");


            var interval1 = new MathematicalExpectationIntervalService().GetInterval(values);
            Console.WriteLine($"Доверительный интервал для мат ожидания: {interval1.Left} < M < {interval1.Right}");

            var interval2 = new DispersionIntervalsService().GetInterval(values);
            Console.WriteLine($"Доверительный интервал для дисперсии: {interval2.Left} < M < {interval2.Right}");
        }

        private static void PirsonCriteria(IEnumerable<double> values)
        {
            // K = 10 - 1 - 0 = 9
            var xi = 21.07;

            var criteria = new XiSquareCriteriaFormula().Calculate(values, Intervals);

            Console.WriteLine($"Критерий пирсона - {criteria}, из таблицы - {xi}");
        }
    }
}

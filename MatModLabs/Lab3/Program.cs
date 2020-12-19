using System;
using System.Collections.Generic;
using System.Linq;
using Lab3.Models;
using Lab3.Services;

namespace Lab3
{
    public class Program
    {
        public const int RandomArraySize = 100000;

        static void Main(string[] args)
        {
            var matrix = new RetrieveMatrixService().Matrix();

            var possibilityService = new PossibilityService();
            var rangesBuilder = new BuildRangesService();
            var pairGenerator = new PairGenerator();
            var xGenerator = new XGenerator();
            var probabilityMathService = new ProbabilityMathService();
            var covarianceService = new CovarianceService();

            Console.WriteLine($"Сумма вероятностей = {matrix.Sum(m => m.Sum())}");

            Console.WriteLine($"X = {JoinArrayToString(possibilityService.GetRowP(matrix))}");
            Console.WriteLine($"Y = {JoinArrayToString(possibilityService.GetColumnP(matrix))}");

            Console.WriteLine();
            Console.WriteLine("X");

            var rangesForX = rangesBuilder.BuildForX(possibilityService.GetRowP(matrix));
            var rangesForY = rangesBuilder.BuildForY(matrix);

            PrintRangesForX(rangesForX);

            Console.WriteLine();
            Console.WriteLine("Y");
            
            PrintRangesForY(rangesForY);
            
            Console.WriteLine();
            Console.WriteLine("Условное распределение");

            PrintConditionalSpread(rangesForY);

            Console.WriteLine();
            Console.WriteLine("Гистограммы условного распределения");

            PrintConditionalDiagrams(rangesForY);

            Console.WriteLine();

            var generatedX = xGenerator.Generate(rangesForX);
            var generatedPairs = pairGenerator.GeneratePairs(rangesForY, generatedX);

            PrintStatistics(generatedPairs, rangesForY);

            Console.WriteLine();

            Console.WriteLine($"M[X] = {probabilityMathService.GetMathExpectationForX(matrix)}");
            Console.WriteLine($"M[Y] = {probabilityMathService.GetMathExpectationForY(matrix)}");

            Console.WriteLine();

            Console.WriteLine($"D[X] = {probabilityMathService.GetDispersionForX(matrix)}");
            Console.WriteLine($"D[Y] = {probabilityMathService.GetDispersionForY(matrix)}");

            Console.WriteLine();

            Console.WriteLine($"Корреляция = {covarianceService.GetCorrelation(matrix)}");
            Console.WriteLine($"Ковариация = {covarianceService.GetCovariance(matrix)}");

            Console.ReadKey();
        }

        private static void PrintRangesForX(IEnumerable<SpreadRangeForX> ranges)
        {
            foreach (var range in ranges)
            {
                Console.WriteLine($"{ Math.Round(range.Left, 4)} < [{range.ItemXId}] < {Math.Round(range.Right, 4)}");
            }
        }

        private static void PrintRangesForY(IEnumerable<SpreadRangeForY> ranges)
        {
            foreach (var range in ranges)
            {
                Console.WriteLine($"{ Math.Round(range.Left, 4)} < [{range.ItemXId}] [{range.ItemYId}] < {Math.Round(range.Right, 4)}");
            }
        }

        private static void PrintConditionalSpread(IEnumerable<SpreadRangeForY> ranges)
        {
            var cellSize = 8;

            var xItems = ranges.GroupBy(g => g.ItemXId).Select(g => g.First().ItemXId);
            var yItems = ranges.GroupBy(g => g.ItemYId).Select(g => g.First().ItemYId);

            Console.WriteLine(string.Join(string.Empty,
                new[] {"x\\y".PadRight(cellSize)}.Concat(yItems.Select(y => $"[{y}]".PadRight(cellSize)))));

            foreach (var x in xItems)
            {
                Console.Write($"[{x}]".PadRight(cellSize));

                foreach (var y in yItems)
                {
                    var range = ranges.First(range => range.ItemXId == x && range.ItemYId == y);

                    Console.Write($"{Math.Round(range.Right - range.Left, 3)}".PadRight(cellSize));
                }

                Console.WriteLine();
            }
        }

        private static string JoinArrayToString(IEnumerable<double> values)
        {
            return string.Join("; ", values.Select(val => Math.Round(val, 2)));
        }

        private static void PrintStatistics(IEnumerable<Pair> pairs, IEnumerable<SpreadRangeForY> rangesForY)
        {
            foreach (var range in rangesForY)
            {
                var p = (double)pairs.Count(pair => pair.X == range.ItemXId && pair.Y == range.ItemYId) / (double)pairs.Count();

                Console.WriteLine($"[{range.ItemXId}],[{range.ItemYId}] {GetDiagramRow(p)}");
            }
        }

        private static void PrintConditionalDiagrams(IEnumerable<SpreadRangeForY> ranges)
        {
            var xItems = ranges.GroupBy(g => g.ItemXId).Select(g => g.First().ItemXId);

            foreach (var xItem in xItems)
            {
                Console.WriteLine($"Для Х[{xItem}]");

                foreach (var range in ranges.Where(range => range.ItemXId == xItem))
                {
                    Console.WriteLine($"[{range.ItemYId}] {GetDiagramRow(range.Right - range.Left)}");
                }

                Console.WriteLine();
            }
        }

        private static string GetDiagramRow(double p)
        {
            var size = 50;

            return $"({Math.Round(p, 3),-5}) |{new string('=', (int) (size * p)).PadRight(size, ' ')}|";
        }
    }
}

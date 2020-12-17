using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;
using Lab3.Services;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new RetrieveMatrixService().Matrix();
            
            Console.WriteLine($"Сумма вероятностей = {matrix.Sum(m => m.Sum())}");

            Console.WriteLine($"Row    = {JoinArrayToString(GetRowP(matrix))}");
            Console.WriteLine($"Column = {JoinArrayToString(GetColumnP(matrix))}");

            Console.WriteLine($"Row    = {GetRowP(matrix).Sum()}");
            Console.WriteLine($"Column = {GetColumnP(matrix).Sum()}");

            Console.WriteLine(SpreadFormula(matrix, 6, 8));

            Console.ReadKey();
        }

        private static double SpreadFormula(IEnumerable<IEnumerable<double>> matrix, int x, int y)
        {
            var sum = 0.0;

            for (int i = 0; i <= x; i++)
            {
                if (i < matrix.Count())
                {
                    var row = matrix.ElementAt(i);

                    for (int j = 0; j <= y; j++)
                    {
                        if (j < row.Count())
                        {
                            sum += row.ElementAt(j);
                        }
                    }
                }
            }

            return sum;
        }

        private static IEnumerable<double> GetColumnP(IEnumerable<IEnumerable<double>> matrix)
        {
            return matrix.First().Select((_, index) => matrix.Sum(row => row.ElementAt(index)));
        }

        private static IEnumerable<double> GetRowP(IEnumerable<IEnumerable<double>> matrix)
        {
            return matrix.Select(row => row.Sum());
        }

        private static string JoinArrayToString(IEnumerable<double> values)
        {
            return string.Join("; ", values.Select(val => Math.Round(val, 2)));
        }
    }
}

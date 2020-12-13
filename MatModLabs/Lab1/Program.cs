using System;
using System.Linq;
using Library.Services.EqualityFormula;
using Library.Services.Generators;
using Library.Services.IndependenceFormula;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = 1000;
            var ranges = 20;

            var middleSquareMethodArray = new MiddleSquareMethod().GenerateArray(seed: 3559, size: size);

            var multiplyingCongruentMethodArray =
                new MultiplyingCongruentMethod(amountM: (int) Math.Pow(2, 14), amountK: 5003)
                    .GenerateArray(seed: 0.3187, size: size);

            Console.WriteLine("Метод середины квадрата (тестирование равномерности)");

            new EqualityTester().ShowTestingDiagram(middleSquareMethodArray, ranges);

            Console.WriteLine();
            Console.WriteLine("Мультипликативный конгруэнтный метод (тестирование равномерности)");

            new EqualityTester().ShowTestingDiagram(multiplyingCongruentMethodArray, ranges);

            Console.WriteLine();
            Console.WriteLine("Тестирование независимости");

            new IndependenceTester().ShowTestingResult(
                middleSquareMethodArray.Take(middleSquareMethodArray.Count() - 3),
                middleSquareMethodArray.Skip(3));

            Console.WriteLine();
            Console.WriteLine("Тестирование независимости");

            new IndependenceTester().ShowTestingResult(
                multiplyingCongruentMethodArray.Take(multiplyingCongruentMethodArray.Count() - 3),
                multiplyingCongruentMethodArray.Skip(3));

            Console.ReadKey();
        }
    }
}

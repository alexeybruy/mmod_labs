using System;
using System.Collections.Generic;
using System.Linq;
using Library.Services;
using Library.Services.EqualityFormula;
using Library.Services.Generators;
using Library.Services.IndependenceFormula;
using Library.Services.InverseFunctionMethod;

namespace Lab2Console
{
    class Program
    {
        private static int Size = 10000;

        static void Main(string[] args)
        {
            var geneated = Generate();

            new EqualityTester().ShowTestingDiagram(geneated, 10);

            Console.WriteLine();
            Console.WriteLine("Тестирование независимости");

            new IndependenceTester().ShowTestingResult(geneated.Take(geneated.Count() - 3), geneated.Skip(3));
        }

        private static IEnumerable<double> Generate()
        {
            var generatedX = new MultiplyingCongruentMethod((int) Math.Pow(2, 14), amountK: 5017)
                .GenerateArray(0.318, Size).ToList();

            var shiftedX = new ConvertToRangeService().Convert(generatedX, -1, 1);

            return new SpreadLawService().Calculate(shiftedX);
        }
    }
}

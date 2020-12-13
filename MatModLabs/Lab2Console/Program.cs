using System;
using System.Linq;
using Library.Services;
using Library.Services.EqualityFormula;
using Library.Services.Generators;
using Library.Services.InverseFunctionMethod;

namespace Lab2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = 10000;

            var generatedX = new MultiplyingCongruentMethod((int) Math.Pow(2, 14), amountK: 5017)
                .GenerateArray(0.318, size).ToList();

            var shiftedX = new ConvertToRangeService().Convert(generatedX, -1, 1);

            var speadedY = new SpreadLawService().Calculate(shiftedX);

            new EqualityTester().ShowTestingDiagram(speadedY, 10);
        }
    }
}
